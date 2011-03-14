using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MobileTools.Serialize
{
    /// <summary>
    /// Navegador de registros serializados.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BFormatterNavigate
    {
        #region Variáveis Locais

        private Stream navStream;
        private int _count;

        /// <summary>
        /// Tipo base do navegador.
        /// </summary>
        private Type baseType;

        /// <summary>
        /// Tamanho do atual item.
        /// </summary>
        private int sizeCurrentItem = 0;

        private long beginStreamPosition = 0;
        private long currentStreamPosition = 0;
        private int currentPosition = -1;

        private byte[] bufferSize = new byte[sizeof(int)];

        /// <summary>
        /// Informações dos dados de suporte para trabalhar a os dados.
        /// </summary>
        private BFormatter.InfoCoreSupport[] coreSupports;

        /// <summary>
        /// Númer de membros da tipo que permite valores nulos.
        /// </summary>
        private short memberAllowNullCount;  

        #endregion

        #region Propriedades

        /// <summary>
        /// Quantidade de itens contidos no navegador.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="stream">Stream onde os dados estão armazenados.</param>
        /// <param name="baseType">Tipo base do navegador.</param>
        public BFormatterNavigate(Stream stream, Type baseType)
        {
            beginStreamPosition = stream.Position;
            navStream = stream;
            this.baseType = baseType;
            Initialize();
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Inicializa a instância.
        /// </summary>
        private void Initialize()
        {
            navStream.Seek(beginStreamPosition, SeekOrigin.Begin);
            currentPosition = -1;
            currentStreamPosition = 0;
            sizeCurrentItem = 0;

            // Recupera as informações do tipo
            coreSupports = BFormatter.LoadTypeInformation(baseType, out memberAllowNullCount);

            if (navStream.Length > 0)
            {
                // Recupera o tamanho do vetor
                _count = BFormatter.ReadArrayLenght(navStream, 0);
                currentStreamPosition = navStream.Position;
            }
            else
                _count = 0;

        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Reseta a navegação.
        /// </summary>
        public void Reset()
        {
            Initialize();
        }

        /// <summary>
        /// Recupera o item.
        /// </summary>
        /// <returns></returns>
        public object GetItem()
        {
            if (currentPosition < 0)
                throw new InvalidOperationException("Item not ready.");

            navStream.Seek(currentStreamPosition, SeekOrigin.Begin);
            return BFormatter.DeserializeBase(navStream, baseType, coreSupports, memberAllowNullCount, 0, null);
        }

        /// <summary>
        /// Lê o próximo registro.
        /// </summary>
        /// <returns>True caso o registro tenha sido lido.</returns>
        public bool Read()
        {
            if ((currentPosition + 1) >= _count || _count == 0) return false;

            navStream.Seek(currentStreamPosition + sizeCurrentItem, SeekOrigin.Begin);
            // Recupera o buffer com o dados do tamanho do registro
            navStream.Read(bufferSize, 0, bufferSize.Length);
            int size = BitConverter.ToInt32(bufferSize, 0);

            sizeCurrentItem = size;
            currentStreamPosition = navStream.Position;
            currentPosition++;
            return true;
        }

        #endregion
    }
}
