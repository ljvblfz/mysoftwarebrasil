using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MobileTools.Serialize
{
    /// <summary>
    /// Representa uma fonte de dados.
    /// </summary>
    public class BFormatterSource : IDisposable
    {
        #region Variáveis Locais

        /// <summary>
        /// Stream onde os dados serão salvos.
        /// </summary>
        private Stream source;

        private int _count = 0;
        private long sourceBeginPosition = 0;

        private Type baseType = null;

        /// <summary>
        /// Identifica se a stream foi criada na atual instância.
        /// </summary>
        private bool localStream = false;

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
        /// Quantidade de itens contidos na fonte.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Instancia uma fonte que será salva na stream informada.
        /// </summary>
        /// <param name="stream">Stream onde os dados serão salvos.</param>
        /// <param name="baseType">Tipo base trabalhado pela fonte.</param>
        public BFormatterSource(Stream stream, Type baseType)
        {
            source = stream;
            localStream = false;
            this.baseType = baseType;

            Initialize();
        }

        #endregion

        #region Métodos Privados

        private void Initialize()
        {
            // Recupera as informações do tipo
            coreSupports = BFormatter.LoadTypeInformation(baseType, out memberAllowNullCount);

            sourceBeginPosition = source.Position;
            // Reserva um espaço para armazenar o tamanho da fonte
            source.Write(new byte[] { 0, 0, 0, 0 }, 0, sizeof(short));
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Força o salvamento da informação na stream.
        /// </summary>
        public void Flush()
        {
            long pos = source.Position;
            source.Seek(sourceBeginPosition, SeekOrigin.Begin);
            // Salva o tamanho da fonte
            source.Write(BitConverter.GetBytes((short)_count), 0, sizeof(short));

            // Volta para a posição que estava anteriormente
            source.Seek(pos, SeekOrigin.Begin);
        }

        /// <summary>
        /// Adiciona um item na fonte.
        /// </summary>
        /// <param name="item">Item contendo os dados.</param>
        public void Add(object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item.GetType() != baseType)
                throw new InvalidOperationException("Invalid item type.");

            long pos = source.Position;

            // Salva na stream somente para reservar espaço
            source.Write(new byte[] { 0, 0, 0, 0 }, 0, sizeof(int));

            // Serializa o item na stream
            BFormatter.SerializeBase(source, coreSupports, memberAllowNullCount, 0, item);

            // Recupera a quantidade de dados salvos
            int size = (int)(source.Position - sizeof(int) - pos);

            long endPos = source.Position;

            source.Seek(pos, SeekOrigin.Begin);
            // Salva o tamanho do item na posição correta
            source.Write(BitConverter.GetBytes(size), 0, sizeof(int));

            // Posiciona o cursor no lugar certo
            source.Seek(endPos, SeekOrigin.Begin);

            // Incrementa a quantidade de itens
            _count++;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Libera a instancia.
        /// </summary>
        public void Dispose()
        {
            Flush();

            if (localStream)
                source.Close();
        }

        #endregion
    }
}
