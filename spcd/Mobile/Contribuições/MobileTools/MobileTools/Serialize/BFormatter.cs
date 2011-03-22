using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Globalization;

namespace MobileTools.Serialize
{
    /// <summary>
    /// Atributo para identifica que aquele campo ou método não será serializado.
    /// </summary>
    public class BNonSerializeAttribute : Attribute
    {

    }

    /// <summary>
    /// Atribute que identifica o tamanho máximo em byte que o campo pode conter.
    /// </summary>
    public class SerializableMaxLenghtAttribute : Attribute
    {
        #region Variáveis Locais

        private int _maxLenght;

        #endregion

        #region Propriedades

        /// <summary>
        /// Gets a quantidade máxima de byte que o campo suporta.
        /// </summary>
        public int MaxLenght
        {
            get { return _maxLenght; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="maxLenght">Tamanho máximo para serializar.</param>
        public SerializableMaxLenghtAttribute(int maxLenght)
        {
            _maxLenght = maxLenght;
        }

        #endregion
    }

    internal class PropertyInfoComparer : IComparer<PropertyInfo>
    {
        #region IComparer<PropertyInfo> Members

        public int Compare(PropertyInfo x, PropertyInfo y)
        {
            return Comparer.Default.Compare(x.Name, y.Name);
        }

        #endregion
    }

    internal class FieldInfoComparer : IComparer<FieldInfo>
    {
        #region IComparer<PropertyInfo> Members

        public int Compare(FieldInfo x, FieldInfo y)
        {
            return Comparer.Default.Compare(x.Name, y.Name);
        }

        #endregion
    }

    /// <summary>
    /// Serializa e deserializa um objeto em um junto de dados binários.
    /// </summary>
    public class BFormatter
    {
        #region Variáveis Locais

        /// <summary>
        /// Tipos básico suportados para serialização
        /// </summary>
        private readonly static Type[] coreTypes = 
        {
            typeof(byte[]),
            typeof(byte),
            typeof(bool),
			typeof(char),
			typeof(double),
			typeof(short),
			typeof(int),
			typeof(long),
			typeof(float),
			typeof(ushort),
			typeof(uint),
			typeof(ulong),
            typeof(string),
            typeof(DateTime)

        };

        #endregion

        #region Estruturas internas

        /// <summary>
        /// Armazena as informações sobre os tipos suportados.
        /// </summary>
        internal class InfoCoreSupport
        {
            /// <summary>
            /// Construtor padrão
            /// </summary>
            /// <param name="coreTypeSupported">Identifica se é um tipo básico suportado.</param>
            /// <param name="allowNullValue">Permite valores nulos.</param>
            public InfoCoreSupport(bool coreTypeSupported, bool allowNullValue)
            {
                this.coreTypeSupported = coreTypeSupported;
                this.allowNullValue = allowNullValue;
                fieldInfo = null;
                propertyInfo = null;
            }

            /// <summary>
            /// Identifica se o tipo do paramentro é suportado
            /// </summary>
            public bool coreTypeSupported;

            /// <summary>
            /// Identifica se o tipo do paramentro suporta valor nulos.
            /// </summary>
            public bool allowNullValue;

            /// <summary>
            /// Informações sobre o campo.
            /// </summary>
            public FieldInfo fieldInfo;

            /// <summary>
            /// Informações sobre a propriedade.
            /// </summary>
            public PropertyInfo propertyInfo;

            /// <summary>
            /// Tamanho máximo do membro.
            /// </summary>
            public int maxLenght;

            /// <summary>
            /// Recupera o valor do membro do objeto informado. 
            /// </summary>
            /// <param name="graph"></param>
            /// <returns></returns>
            public object GetValue(object graph)
            {
                if (fieldInfo != null)
                    return fieldInfo.GetValue(graph);
                else if (propertyInfo != null)
                    return propertyInfo.GetValue(graph, null);
                else
                    throw new InvalidOperationException();
            }

            /// <summary>
            /// Recupera o tipo do membro.
            /// </summary>
            /// <returns></returns>
            public Type GetMemberType()
            {
                if (fieldInfo != null)
                    return fieldInfo.FieldType;
                else if (propertyInfo != null)
                    return propertyInfo.PropertyType;
                else
                    throw new InvalidOperationException();
            }
        }

        #endregion

        #region Marshal

        /// <summary>
        /// Verifica se o tipo informado é uma estrutura.
        /// </summary>
        /// <param name="type">Tipo.</param>
        /// <returns></returns>
        public static bool IsStruct(Type type)
        {
            return type.IsValueType && !type.IsPrimitive && type.BaseType == typeof(ValueType);
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Verifica se é um tipo básico aceitável para serialização.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsCoreType(Type type)
        {
            foreach (Type t in coreTypes)
                if (t == type)
                    return true;

            return false;
        }

        /// <summary>
        /// Verifica se o tipo é suportado pela serialização.
        /// </summary>
        /// <param name="type">Tipo a ser verificado.</param>
        /// <returns>
        /// <list type="bool">
        /// <item>True: o tipo é suportado.</item>
        /// <item>False: o tipo não é suportado.</item>
        /// </list>
        /// </returns>
        private static InfoCoreSupport Support(Type type)
        {
            InfoCoreSupport icts = new InfoCoreSupport(false, false);

            // Verifica se o tipo é um nullable
            if (type.Name == "Nullable`1")
            {
                // Identifica que o tipo suporta valores nulos
                icts.allowNullValue = true;
                // Recupera o tipo base
                type = Nullable.GetUnderlyingType(type);
            }

            // Verifica se o tipo é um enumeration
            if (type.IsEnum)
            {
                // Recupera o tipo base
                type = Enum.GetUnderlyingType(type);
            }

            // Verifica se o tipo é um array
            if (type.IsArray && type.GetElementType() != typeof(object))
            {
                icts.coreTypeSupported = true;
                icts.allowNullValue = true;
                return icts;
            }
            // Verifica se o tipo é uma struct
            else if (IsStruct(type))
            {
                icts.coreTypeSupported = true;
                return icts;
            }

            foreach (Type supportedType in BFormatter.coreTypes)
                // Verifica o tipo informado faz parte do tipo padrões
                if (supportedType.IsAssignableFrom(type))
                {
                    // Identifica que o tipo é suportado
                    icts.coreTypeSupported = true;

                    if (!icts.allowNullValue && (supportedType.IsAssignableFrom(typeof(string)) || supportedType.IsAssignableFrom(typeof(byte[]))))
                        icts.allowNullValue = true;
                }

            return icts;
        }

        /// <summary>
        /// Escreve o valor do objeto na stream.
        /// </summary>
        /// <param name="stream">Stream aonde serão salvos os dados do objeto.</param>
        /// <param name="o">Objeto contendo os dados.</param>
        /// <param name="type">Tipo do valor a ser serializado.</param>
        /// <param name="maxLenght">Tamanho máximo a ser serializado.</param>
        private static void WriteData(Stream stream, object o, Type type, int maxLenght)
        {            
            if (type.IsAssignableFrom(typeof(string)) && o == null) 
                o = "";

            // Verifica se o tipo e Nullable
            if (type.Name == "Nullable`1")
            {
                // Recupera o tipo tratado pelo Nullable
                type = Nullable.GetUnderlyingType(type);

                if (o == null)
                    o = Activator.CreateInstance(type);
            }

            // Verifica se o tipo é um enumerator
            if (type.IsEnum)
            {
                type = Enum.GetUnderlyingType(type);

                switch (type.Name)
                {
                    case "Int16": o = (short)o; break;
                    case "UInt16": o = (ushort)o; break;
                    case "Int32": o = (int)o; break;
                    case "UInt32": o = (uint)o; break;
                    case "Byte": o = (byte)o; break;
                    default: o = (int)o; break;
                }
            }
            else if (IsStruct(type) && !type.IsAssignableFrom(typeof(DateTime)) && !type.IsAssignableFrom(typeof(decimal)))
            {
                // Serializa o elemento
                SerializeBase(stream, null, 0, 0, o);
                return;
            }

            // Strings são tratadas de forma especial
            if (type.IsAssignableFrom(typeof(string)))
            {
                // Recupera a string
                string s = (string)o;

                // Identifica o número de bytes usado para identifica o tamanho da string
                int size = 0;

                // Captura o tamanho oficial da string
                int lenght = s.Length;

                // Verifica se foi informado tamanho máximo a ser tratado
                if (maxLenght > 0)
                {
                    // Captura o tamanho oficial da string
                    lenght = (lenght > maxLenght ? maxLenght : lenght);

                    // Verifica a quantidade de bytes que serão gastos para identifica o tamanho da string

                    // Se a quantidade for até 255 o volume de dados da string pode ser
                    // definido apenas com um byte
                    if (maxLenght < byte.MaxValue)
                        size = 1;
                    // Se a quantidade for até 65635 o volume de dados pode ser definido por um ushort
                    else if (maxLenght < ushort.MaxValue)
                        size = sizeof(ushort);
                    else if (maxLenght < int.MaxValue)
                        size = sizeof(uint);
                }
                else
                {
                    // Quantidade de bytes para armazenar o tamanho da string
                    size = sizeof(ushort);
                    // Tamanho da string
                    lenght = s.Length;
                }

                // Salva o tamanho da variável
                stream.Write(BitConverter.GetBytes(lenght), 0, size);
                // Salva o valor da variável
                stream.Write(Encoding.Default.GetBytes(s), 0, lenght);
            }
            else if (type.IsAssignableFrom(typeof(DateTime)))
            {
                // Salva o valor da variável
                stream.Write(BitConverter.GetBytes(((DateTime)o).Ticks), 0, sizeof(long));
            }
            else if (type.IsAssignableFrom(typeof(decimal)))
            {
                // Salva o valor da variável
                stream.Write(DecimalToBytes(Convert.ToDecimal(o)), 0, sizeof(decimal));
            }
            else if (type.IsAssignableFrom(typeof(byte)))
            {
                stream.WriteByte((byte)o);
            }
            // Verifica se o tipo é um vetor de bytes
            else if (type.IsAssignableFrom(typeof(byte[])))
            {
                byte[] buffer = (byte[])o;

                // Identifica o número de bytes usado para identifica o tamanho da string
                int size = 0;
                // Captura o tamanho oficial da string
                int lenght = buffer.Length;

                if (maxLenght > 0)
                {
                    // Captura o tamanho oficial da string
                    lenght = (lenght > maxLenght ? maxLenght : lenght);

                    // Verifica a quantidade de bytes que serão gastos para identifica o tamanho da string
                    if (maxLenght < byte.MaxValue)
                        size = 1;
                    else if (maxLenght < ushort.MaxValue)
                        size = sizeof(ushort);
                    else if (maxLenght < int.MaxValue)
                        size = sizeof(uint);
                }
                else
                {
                    // Quantidade de bytes usados para armazenar o tamanho do vetor
                    size = sizeof(ushort);
                    // Tamanho do vetor
                    lenght = buffer.Length;
                }

                // Salva o tamanho da variável
                stream.Write(BitConverter.GetBytes(lenght), 0, size);
                // Salva o valor da variável
                stream.Write(buffer, 0, lenght);
            }
            // Verifica se o tipo é um vetor
            else if (type.IsArray)
            {
                SerializeBase(stream, null, 0, maxLenght, o);
            }
            else
            {
                int size;

                // Verifica se o tipo é um bool
                if (type.IsAssignableFrom(typeof(bool)))
                    size = sizeof(bool);
                else if (type.IsAssignableFrom(typeof(char)))
                    size = sizeof(char);
                else
                    // Recupera o tamanho do tipo primitivo
                    size = System.Runtime.InteropServices.Marshal.SizeOf(type);

                // O método de conversão para bytes está sendo chamado dinâmicamente, pois dessa
                // forma o cast dos tipo requerido pelo método GetBytes não permite atribuir um object
                MethodInfo m = typeof(BitConverter).GetMethod("GetBytes", BindingFlags.Public | BindingFlags.Static, null, new Type[] { type }, null);
                stream.Write((byte[])m.Invoke(null, BindingFlags.Default, null, new object[] { o }, CultureInfo.CurrentCulture), 0, size);
            }
        }

        /// <summary>
        /// Lê os dados da stream e salva no objeto
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type">Tipo de dado a ser lido.</param>
        /// <return>Valor lido.</return>
        private static object ReadData(Stream stream, Type type, int maxLenght)
        {
            if (type.Name == "Nullable`1")
                type = Nullable.GetUnderlyingType(type);

            Type typeEnum = null;

            // Verifica se o tipo é um enumerator
            if (type.IsEnum)
            {
                typeEnum = type;
                type = Enum.GetUnderlyingType(type);
            }
            // Verifica se está recupera os dados de uma struct
            else if (IsStruct(type) && !type.IsAssignableFrom(typeof(DateTime)) && !type.IsAssignableFrom(typeof(decimal)))
            {
                // Instancia o objeto
                object obj = Activator.CreateInstance(type);
                // Recupera os dados da stream
                DeserializeBase(stream, type, null, 0, 0, obj);
                return obj;
            }


            int size = 0;
            if (type.IsAssignableFrom(typeof(string)))
            {
                if (maxLenght > 0)
                {
                    // Verifica a quantidade de bytes que serão gastos para identifica o tamanho da string
                    if (maxLenght < byte.MaxValue)
                        size = 1;
                    else if (maxLenght < ushort.MaxValue)
                        size = sizeof(ushort);
                    else if (maxLenght < int.MaxValue)
                        size = sizeof(uint);
                }
                else
                {
                    size = sizeof(ushort);
                }

                byte[] bufferAux = new byte[size];
                stream.Read(bufferAux, 0, size);

                if (maxLenght > 0)
                {
                    if (maxLenght < byte.MaxValue)
                        size = (int)bufferAux[0];
                    else if (maxLenght < ushort.MaxValue)
                        size = BitConverter.ToInt16(bufferAux, 0);
                    else if (maxLenght < int.MaxValue)
                        size = BitConverter.ToInt32(bufferAux, 0);
                }
                else
                    size = BitConverter.ToUInt16(bufferAux, 0);

            }
            else if (type.IsAssignableFrom(typeof(bool)))
                size = sizeof(bool);

            else if (type.IsAssignableFrom(typeof(DateTime)))
                size = sizeof(long);

            else if (type.IsAssignableFrom(typeof(decimal)))
                size = sizeof(decimal);

            else if (type.IsAssignableFrom(typeof(char)))
                size = sizeof(char);
            else if (type.IsAssignableFrom(typeof(byte)))
                size = sizeof(byte);

            else if (type.IsAssignableFrom(typeof(byte[])))
            {
                if (maxLenght > 0)
                {
                    // Verifica a quantidade de bytes que serão gastos para identifica o tamanho da string
                    if (maxLenght < byte.MaxValue)
                        size = 1;
                    else if (maxLenght < ushort.MaxValue)
                        size = sizeof(ushort);
                    else if (maxLenght < int.MaxValue)
                        size = sizeof(uint);
                }
                else
                {
                    size = sizeof(ushort);
                }

                byte[] bufferAux = new byte[size];
                stream.Read(bufferAux, 0, size);

                if (maxLenght > 0)
                {
                    if (maxLenght < byte.MaxValue)
                        size = (int)bufferAux[0];
                    else if (maxLenght < ushort.MaxValue)
                        size = BitConverter.ToInt16(bufferAux, 0);
                    else if (maxLenght < int.MaxValue)
                        size = BitConverter.ToInt32(bufferAux, 0);
                }
                else
                    size = BitConverter.ToUInt16(bufferAux, 0);

                bufferAux = new byte[size];

                stream.Read(bufferAux, 0, size);

                return bufferAux;
            }
            else
                size = System.Runtime.InteropServices.Marshal.SizeOf(type);
            
            if (type.IsArray)
            {
                return DeserializeBase(stream, type, null, 0, maxLenght, null);
            }
            else
            {

                byte[] buffer = new byte[size];
                stream.Read(buffer, 0, size);

                if (type.IsAssignableFrom(typeof(string)))
                    return Encoding.Default.GetString(buffer, 0, size);

                else if (type.IsAssignableFrom(typeof(byte[])))
                    return buffer;

                else if (type.IsAssignableFrom(typeof(byte)))
                    return buffer[0];

                else if (type.IsAssignableFrom(typeof(DateTime)))
                    return new DateTime(BitConverter.ToInt64(buffer, 0));

                else if (type.IsAssignableFrom(typeof(decimal)))
                    return BytesToDecimal(buffer);

                else
                {
                    // O método de conversão para bytes está sendo chamado dinâmicamente, pois dessa
                    // forma o cast dos tipo requerido pelo método GetBytes não permite atribuir um object
                    MethodInfo m = typeof(BitConverter).GetMethod("To" + type.Name);

                    if (typeEnum != null)
                    {
                        return Enum.ToObject(typeEnum, m.Invoke(null, new object[] { buffer, 0 }));
                    }
                    else
                        return m.Invoke(null, new object[] { buffer, 0 });
                }
            }
        }

        /// <summary>
        /// Extrai os dados do objeto.
        /// </summary>
        /// <param name="streamOut">Stream onde será armazenado os dados extraídos.</param>
        /// <param name="supports">Informações dos membros onde estão os dados.</param>
        /// <param name="membersAllowNullCount">Quantidade de membros que aceitam valores nulos.</param>
        /// <param name="graph">Objeto de onde será estraído os dados.</param>
        private static void Export(Stream streamOut, InfoCoreSupport[] supports, short membersAllowNullCount, object graph)
        {
            // Salva a posição de onde o stream está no momento
            int beginStreamPos = (int)streamOut.Position;

            // Captura a quantidade de byte que serão utilizados para verifica a quatidade de campos
            // com suporta a valor nulo
            int nBytesAllowNull = Convert.ToInt32(Math.Ceiling(membersAllowNullCount / 8.0d));

            // Buffer onde serão armazenadas as informações sobre os campos com valores nullos
            byte[] bAllowNull = new byte[nBytesAllowNull];

            // Salva o buffer na stream
            streamOut.Write(bAllowNull, 0, bAllowNull.Length);

            // Lista para identificar os membros com valores nulos ou não
            bool[] memberNulls = new bool[membersAllowNullCount];

            int i = 0;

            foreach (InfoCoreSupport sp in supports)
            {
                // Captura o valor do membro
                object value = sp.GetValue(graph);

                // Verifica se o valor tempo suporte para valor nulo
                if (sp.allowNullValue)
                    // Define se o valor do membro é nulo ou não
                    memberNulls[i++] = (value == null);

                // Verifica se o valor não é nulo
                if (!sp.allowNullValue || value != null)
                    // Serializa os dados do membro
                    WriteData(streamOut, value, sp.GetMemberType(), sp.maxLenght);
            }

            int j = 0, x = 0;

            // Pecorre os dados que identificam se o campo tem valor nulo ou não
            for (i = 0; i < nBytesAllowNull; i++)
            {
                // Limpa o byte
                bAllowNull[i] = 0x00;

                x = 0;
                for (; (x < 8) && (j < (nBytesAllowNull * 8)) && j < membersAllowNullCount; j++)
                {
                    // Verifica o campo contem um valor null
                    if (memberNulls[j])
                    {
                        // Indica no bit x que o campo contem valor null
                        bAllowNull[i] = (byte)(bAllowNull[i] | (byte)Convert.ToInt32(Math.Pow(2.0d, (double)x)));
                    }
                    x++;
                }
            }

            int pos = (int)streamOut.Position;

            // Posiciona o ponteiro na parte onde será inserido os dados sobre os membros com valores nulos
            streamOut.Seek(beginStreamPos, SeekOrigin.Begin);

            // Salva as informações sobre os campos com valores nulos
            streamOut.Write(bAllowNull, 0, bAllowNull.Length);

            // Posiciona o cursor onde ele havia parado
            streamOut.Seek(pos, SeekOrigin.Begin);
        }

        /// <summary>
        /// Importa os dados do objeto contidos na stream.
        /// </summary>
        /// <param name="streamIn">Stream onde estão os dados a serem importados.</param>
        /// <param name="supports">Informações dos membros que mapeam os dados.</param>
        /// <param name="memberAllowNullCount">Quantidade de membros que aceitam valores nulos.</param>
        /// <param name="graph">Objeto onde os dados importados serão salvos.</param>
        private static void Import(Stream streamIn, InfoCoreSupport[] supports, short memberAllowNullCount, object graph)
        {
            // Verifica o número de bytes usados para identifica o campo com valores nulos
            int n = Convert.ToInt32(Math.Ceiling(memberAllowNullCount / 8.0d));

            // Armazena a relação dos itens que aceitam valores nulos
            bool[] fieldsNulls = new bool[memberAllowNullCount];

            // Verifica se o número de bytes que usados para armazenar
            // os dados é maior que zero
            if (n > 0)
            {
                byte[] buffer = new byte[n];
                streamIn.Read(buffer, 0, n);

                int j, x = 0;

                // Percorre os bytes procurando informações sobre os campos nulos
                for (int i = 0; i < n; i++)
                {
                    j = 0;
                    for (; j < 8 && j < memberAllowNullCount; j++)
                    {
                        // Captura o bit que indica se o campo é null
                        // Para varifica se o bit está com o estado 1, movimenta o ponteiro
                        // até o bit desejado e verifica se o resulto interio dessa operação
                        // é um número impar, dessa forma podemos identificar que o bit está com o estado 1
                        fieldsNulls[x++] = (((buffer[i] >> j) % 2) != 0);
                    }

                    memberAllowNullCount -= 8;
                }
            }

            memberAllowNullCount = 0;
            object[] attributes;
            int maxLenght = 0;

            for (int i = 0; i < supports.Length; i++)
            {
                if (supports[i].fieldInfo != null)
                {
                    if (supports[i].allowNullValue && fieldsNulls[memberAllowNullCount++])
                    {
                        supports[i].fieldInfo.SetValue(graph, null);
                        continue;
                    }

                    // Verifica se existe algum atributo relacionado que indentifica o tamanho máximo suportado
                    attributes = supports[i].fieldInfo.GetCustomAttributes(typeof(SerializableMaxLenghtAttribute), true);
                    if (attributes.Length > 0)
                        maxLenght = (int)((SerializableMaxLenghtAttribute)attributes[0]).MaxLenght;
                    else
                        maxLenght = 0;

                    supports[i].fieldInfo.SetValue(graph, ReadData(streamIn, supports[i].fieldInfo.FieldType, maxLenght));
                }
                else
                {
                    if (supports[i].allowNullValue && fieldsNulls[memberAllowNullCount++])
                    {
                        supports[i].propertyInfo.SetValue(graph, null, null);
                        continue;
                    }
                    // Verifica se existe algum atributo relacionado que indentifica o tamanho máximo suportado
                    attributes = supports[i].propertyInfo.GetCustomAttributes(typeof(SerializableMaxLenghtAttribute), true);
                    if (attributes.Length > 0)
                        maxLenght = (int)((SerializableMaxLenghtAttribute)attributes[0]).MaxLenght;
                    else
                        maxLenght = 0;

                    supports[i].propertyInfo.SetValue(graph, ReadData(streamIn, supports[i].propertyInfo.PropertyType, maxLenght), null);
                }
            }
        }

        /// <summary>
        /// Carrega as informações sobre o tipo.
        /// </summary>
        /// <param name="type">Tipo a ser examinado.</param>
        /// <param name="membersAllowNullCount">Númeor de membros que permite valores nulos.</param>
        /// <returns>Informações de suporte.</returns>
        internal static InfoCoreSupport[] LoadTypeInformation(Type type, out short membersAllowNullCount)
        {
            short allowNullCount = 0;

            // Lista as informações do membros de onde serão recuperados os dados
            List<InfoCoreSupport> supports = new List<InfoCoreSupport>();

            object[] attributes;
            int maxLenght = 0;
            InfoCoreSupport coreSupport;

            // Recupera os campos do tipo
            List<FieldInfo> fsInfo = new List<FieldInfo>(type.GetFields());
            // Ordena os campos do tipo em ordem alfabetica
            fsInfo.Sort(0, fsInfo.Count, new FieldInfoComparer());

            // Percorre os campos o tipo
            foreach (FieldInfo fi in fsInfo)
            {
                attributes = fi.GetCustomAttributes(typeof(BNonSerializeAttribute), true);
                if (attributes.Length > 0) continue;

                attributes = fi.GetCustomAttributes(typeof(SerializableMaxLenghtAttribute), true);
                if (attributes.Length > 0)
                    maxLenght = (int)((SerializableMaxLenghtAttribute)attributes[0]).MaxLenght;
                else
                    maxLenght = 0;

                // Verifica se o tipo do parametro é suportado
                coreSupport = Support(fi.FieldType);

                if (coreSupport.coreTypeSupported && !((fi.Attributes & FieldAttributes.Static) == FieldAttributes.Static))
                {
                    // Verifica se o valor tempo suporte para valor nulo
                    if (coreSupport.allowNullValue)
                        allowNullCount++;

                    // Relaciona o membro
                    coreSupport.fieldInfo = fi;
                    // Define o tamanho máximo que o membro suporta
                    coreSupport.maxLenght = maxLenght;

                    supports.Add(coreSupport);

                }
            }

            List<PropertyInfo> psInfo = new List<PropertyInfo>(type.GetProperties());
            psInfo.Sort(0, psInfo.Count, new PropertyInfoComparer());

            foreach (PropertyInfo pi in psInfo)
            {
                // Verifica se a propriedade não possui atribuidor
                if (pi.GetSetMethod() == null)
                    // Ignora a serialização da propriedade
                    continue;

                // Verifica se existe algum atributo que indica que a propriedade não será serializada
                attributes = pi.GetCustomAttributes(typeof(BNonSerializeAttribute), true);
                if (attributes.Length > 0) continue;

                attributes = pi.GetCustomAttributes(typeof(SerializableMaxLenghtAttribute), true);
                if (attributes.Length > 0)
                    maxLenght = (int)((SerializableMaxLenghtAttribute)attributes[0]).MaxLenght;
                else
                    maxLenght = 0;

                // Verifica se o tipo do parametro é suportado
                coreSupport = Support(pi.PropertyType);

                if (coreSupport.coreTypeSupported)
                {
                    // Verifica se o valor tempo suporte para valor nulo
                    if (coreSupport.allowNullValue)
                        allowNullCount++;

                    // Relaciona a propriedade com o membro
                    coreSupport.propertyInfo = pi;
                    // Define o tamanho máximo do membro
                    coreSupport.maxLenght = maxLenght;

                    supports.Add(coreSupport);
                }
            }

            membersAllowNullCount = allowNullCount;
            return supports.ToArray();
        }

        /// <summary>
        /// Deserializa os dados.
        /// </summary>
        /// <param name="stream">Stream onde os dados estão armazenados.</param>
        /// <param name="type">Tipo que será recuperado.</param>
        /// <param name="supports">Membros mapeados.</param>
        /// <param name="memberAllowNull">Quantidade de membros que aceitam valores nulos.</param>
        /// <param name="maxLenght">Tamanho máximo aceito.</param>
        /// <param name="graph">Objeto onde a deserialização será salva.</param>
        /// <returns></returns>
        internal static object DeserializeBase(Stream stream, Type type, InfoCoreSupport[] supports, short memberAllowNullCount, int maxLenght, object graph)
        {
            bool isArray = type.IsArray;

            if (isArray)
                type = type.GetElementType();

            bool isCore = IsCoreType(type);

            if (isCore && !isArray)
            {
                // Verifica se existe dados para serem lidos
                if (stream.Length > 0)
                    return ReadData(stream, type, 0);
                else
                    return null;
            }

            if (!type.IsArray && graph == null)
            {
                // Recupera o construtor do tipo
                ConstructorInfo ci = type.GetConstructor(new Type[] { });

                // Verifica se o construtor foi recuperado
                if (ci != null)
                    graph = ci.Invoke(null);
                else
                    graph = Activator.CreateInstance(type);
            }

            // Verifica se o tipo é um vetor
            if (isArray)
            {
                int size = ReadArrayLenght(stream, maxLenght);
                
                byte[] buffer = new byte[sizeof(int)];

                // Instancia o vetor onde será deserializado os dados
                Array array = Array.CreateInstance(type, size);

                // Pecorre os elementos deserializando um por um
                for (int j = 0; j < size; j++)
                {
                    if (isCore)
                    {
                        // Recupera o valor e salva no array
                        array.SetValue(ReadData(stream, type, 0), j);
                    }
                    else
                    {
                        // Recupera os dados do tamanho do elemento
                        stream.Read(buffer, 0, sizeof(int));

                        // Recupera o tamanho do item
                        int itemSize = BitConverter.ToInt32(buffer, 0);

                        // Recupera e seta o valor no array
                        array.SetValue(DeserializeBase(stream, type, supports, memberAllowNullCount, 0, null), j);
                    }
                }

                return array;
            }
            else
            {

                if (supports == null)
                    // Recupera o mapeamento do tipo
                    supports = LoadTypeInformation(type, out memberAllowNullCount);

                // Recupera os dados da instancia
                Import(stream, supports, memberAllowNullCount, graph);

                return graph;
            }
        }

        /// <summary>
        /// Serializa os dados.
        /// </summary>
        /// <param name="stream">Stream onde será salvo os dados.</param>
        /// <param name="supports">Membros mapeados.</param>
        /// <param name="membersAllowNull">Quantidade de membros que aceitam valores nulos.</param>
        /// <param name="maxLenght">Tamanho máximo aceito.</param>
        /// <param name="graph">Objeto que será serializado.</param>
        internal static void SerializeBase(Stream stream, InfoCoreSupport[] supports, short membersAllowNullCount, int maxLenght, object graph)
        {
            if (graph == null)
                throw new ArgumentException("graph");

            // Recupera o tipo que será serializado
            Type t = graph.GetType();

            // Verifica se o tipo que está sendo trabalhado é uma array
            bool isArray = t.IsArray;

            if (isArray)
            {
                t = t.GetElementType();
            }

            bool isCore = IsCoreType(t);

            // Verifica se o tipo é primitivo
            if (isCore && !isArray)
            {
                if (graph != null)
                    // Serializa os dados do tipo
                    WriteData(stream, graph, t, 0);

                return;
            }

            if (supports == null)
            {
                // Verifica se o tipo não é primitivo
                if (!isCore)
                    // Recupera as informações do mapeamento do tipo
                    supports = LoadTypeInformation(t, out membersAllowNullCount);
                else
                    supports = new InfoCoreSupport[0];
            }

            // Verifica se está sendo trabalhado um vetor
            if (isArray)
            {
                Array array = (Array)graph;

                // Armazena a quantidade de bytes usados para salvar o conteúdo do vetor
                int size = 0;
                int lenght = array.Length;

                // Verifica se o tamanho máximo do vetor foi informado
                if (maxLenght > 0)
                {
                    // Captura o tamanho oficial da string
                    lenght = (lenght > maxLenght ? maxLenght : lenght);

                    // Verifica a quantidade de bytes que serão gastos para identifica o tamanho do vetor
                    if (maxLenght < byte.MaxValue)
                        size = 1;
                    else if (maxLenght < ushort.MaxValue)
                        size = sizeof(ushort);
                    else if (maxLenght < int.MaxValue)
                        size = sizeof(uint);
                }
                else
                    // Quantidade de bytes usados para armazenar o tamanho do vetor
                    size = sizeof(ushort);

                // Salva o tamanho do vetor
                stream.Write(BitConverter.GetBytes(lenght), 0, size);

                // Serializa os objetos do vetor
                for (int i = 0; i < lenght; i++)
                {
                    object obj = array.GetValue(i);

                    // Verifica se é um tipo do núcleo
                    if (isCore)
                    {
                        WriteData(stream, obj, t, 0);
                    }
                    else
                    {
                        int pos = (int)stream.Position;

                        // Aloca o espaço onde será salva o tamanho dos dados do objeto
                        stream.Write(new byte[sizeof(int)], 0, sizeof(int));

                        // Extraí os dados do objeto
                        Export(stream, supports, membersAllowNullCount, obj);

                        // Recupera a atual posição da stream
                        int endPos = (int)stream.Position;

                        stream.Seek(pos, SeekOrigin.Begin);

                        // Salva o tamanho do objeto serializado
                        stream.Write(BitConverter.GetBytes((int)(endPos - (pos + sizeof(int)))), 0, sizeof(int));

                        // Posiciona na parte onde está antes de entrar aqui
                        stream.Seek(endPos, SeekOrigin.Begin);
                    }

                }

                return;
            }
            else
                // Extraí os dados do objeto
                Export(stream, supports, membersAllowNullCount, graph);
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Lê o tamanho do vetor serializado no stream.
        /// </summary>
        /// <param name="stream">Stream onde está armazenada os dados.</param>
        /// <param name="maxLenght">Tamanho máximo do vetor.</param>
        /// <returns>Tamanho do vetor salvo no arquivo.</returns>
        public static int ReadArrayLenght(Stream stream, int maxLenght)
        {
            int size = 0;

            // Verifica se o tamanho de armazenamento para o vetor 
            // foi especificado
            if (maxLenght > 0)
            {
                // Verifica a quantidade de bytes que serão gastos para identifica o tamanho da string
                if (maxLenght < byte.MaxValue)
                    size = 1;
                else if (maxLenght < ushort.MaxValue)
                    size = sizeof(ushort);
                else if (maxLenght < int.MaxValue)
                    size = sizeof(uint);
            }
            else
                size = sizeof(ushort);

            byte[] buffer = new byte[size];
            // Lê o buffer do tamanho
            stream.Read(buffer, 0, size);

            // Recupera o tamanho
            if (maxLenght > 0)
            {
                if (maxLenght < byte.MaxValue)
                    size = (int)buffer[0];
                else if (maxLenght < ushort.MaxValue)
                    size = BitConverter.ToInt16(buffer, 0);
                else if (maxLenght < int.MaxValue)
                    size = BitConverter.ToInt32(buffer, 0);
            }
            else
                size = BitConverter.ToUInt16(buffer, 0);

            return size;
        }

        /// <summary>
        /// Serializa o objeto passado, e armazena os dados na stream.
        /// </summary>
        /// <param name="graph">Objeto a serializado.</param>
        public static byte[] Serialize(object graph)
        {
            if (graph == null)
                throw new ArgumentException("graph");

            byte[] buffer = null;
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(stream, graph);
                stream.Seek(0, SeekOrigin.Begin);
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
            }

            return buffer;
        }

        /// <summary>
        /// Serializa o objeto passado, e armazena os dados na stream.
        /// </summary>
        /// <param name="serializationStream">Stream aonde serão armazenados os dados.</param>
        /// <param name="graph">Objeto a serializado.</param>
        /// movimentar o curso da stream para o inicio.</param>
        public static void Serialize(Stream serializationStream, object graph)
        {
            SerializeBase(serializationStream, null, 0, 0, graph);
        }

        /// <summary>
        /// Deseriliza os dados contidos na stream e retorna o objeto do tipo passado com os dados preenchidos.
        /// </summary>
        /// <param name="serializationStream">Stream onde estão os dados para serem deserializados.</param>
        /// <param name="typeReturn">Tipo de retorno do elemento.</param>
        /// <returns>Objeto com os dados dados preenchidos.</returns>
        public static object Deserialize(Stream serializationStream, Type typeReturn)
        {
            return DeserializeBase(serializationStream, typeReturn, null, 0, 0, null);
        }

        /// <summary>
        /// Deseriliza os dados contidos no buffer e retorna o objeto do tipo passado com os dados preenchidos.
        /// </summary>
        /// <param name="buffer">Buffer onde estão os dados para serem deserializados.</param>
        /// <param name="typeReturn">Tipo de retorno do elemento.</param>
        /// <returns>Objeto com os dados dados preenchidos.</returns>
        public static object Deserialize(byte[] buffer, Type typeReturn)
        {
            using (Stream stream = new MemoryStream(buffer, 0, buffer.Length))
            {
                return Deserialize(stream, typeReturn);
            }
        }

        /// <summary>
        /// Copia os dados de uma instância para a outra sem
        /// nenhum vinculo de ponteiro.
        /// </summary>
        /// <typeparam name="T">Tipo que será usado para cópia.</typeparam>
        /// <param name="source">Objeto contendo a fonte dos dados.</param>
        /// <returns>Objeto para onde dados foram copiados.</returns>
        public static T CopyInstance<T>(T source) where T : new()
        {
            T destination = new T();
            CopyInstance<T>(source, destination);
            return destination;
        }

        /// <summary>
        /// Copia os dados de uma instância para a outra sem
        /// nenhum vinculo de ponteiro.
        /// </summary>
        /// <typeparam name="T">Tipo que será usado para cópia.</typeparam>
        /// <param name="source">Objeto contendo a fonte dos dados.</param>
        /// <param name="destination">Objeto para onde será copiado os dados.</param>
        public static void CopyInstance<T>(T source, T destination) where T : new()
        {
            if (source == null)
                throw new ArgumentException("source");

            using (MemoryStream ms = new MemoryStream())
            {
                // Serializa os dados da fonte
                Serialize(ms, source);
                DeserializeBase(ms, typeof(T), null, 0, 0, destination);
            }
        }

        #endregion

        #region Métodos de conversão adicionais

        /// <summary>
        /// Converte um array de bytes para decimal.
        /// </summary>
        /// <param name="bytes">O array de bytes que será convertido.</param>
        /// <returns></returns>
        private static decimal BytesToDecimal(byte[] bytes)
        {
            int[] bits = new int[4];
            bits[0] = ((bytes[0] | (bytes[1] << 8)) | (bytes[2] << 0x10)) | (bytes[3] << 0x18); //lo
            bits[1] = ((bytes[4] | (bytes[5] << 8)) | (bytes[6] << 0x10)) | (bytes[7] << 0x18); //mid
            bits[2] = ((bytes[8] | (bytes[9] << 8)) | (bytes[10] << 0x10)) | (bytes[11] << 0x18); //hi
            bits[3] = ((bytes[12] | (bytes[13] << 8)) | (bytes[14] << 0x10)) | (bytes[15] << 0x18); //flags

            return new decimal(bits);
        }

        /// <summary>
        /// Converte um decimal para um array de bytes.
        /// </summary>
        /// <param name="d">O decimal que será convertido.</param>
        /// <returns></returns>
        private static byte[] DecimalToBytes(decimal d)
        {
            byte[] bytes = new byte[16];

            int[] bits = decimal.GetBits(d);
            int lo = bits[0];
            int mid = bits[1];
            int hi = bits[2];
            int flags = bits[3];

            bytes[0] = (byte)lo;
            bytes[1] = (byte)(lo >> 8);
            bytes[2] = (byte)(lo >> 0x10);
            bytes[3] = (byte)(lo >> 0x18);
            bytes[4] = (byte)mid;
            bytes[5] = (byte)(mid >> 8);
            bytes[6] = (byte)(mid >> 0x10);
            bytes[7] = (byte)(mid >> 0x18);
            bytes[8] = (byte)hi;
            bytes[9] = (byte)(hi >> 8);
            bytes[10] = (byte)(hi >> 0x10);
            bytes[11] = (byte)(hi >> 0x18);
            bytes[12] = (byte)flags;
            bytes[13] = (byte)(flags >> 8);
            bytes[14] = (byte)(flags >> 0x10);
            bytes[15] = (byte)(flags >> 0x18);

            return bytes;
        }

        #endregion
    }

}
