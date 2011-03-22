using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace MobileTools.Controls
{
    public interface IImageSource : IDisposable
    {
        /// <summary>
        /// Nome da image.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Fonte da imagem.
        /// </summary>
        Bitmap CreateSource();

        /// <summary>
        /// Fecha a  fonte se ela estiver aberta.
        /// </summary>
        void CloseSource();
    }

    public class ImageSource : IImageSource, IDisposable
    {
        #region Variáveis Locais

        private Bitmap _source;

        private string _name;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Nome da imagem.</param>
        /// <param name="imageStream">Stream onde a imagem está inserida.</param>
        public ImageSource(string name, Stream imageStream)
        {
            _name = name;
            _source = new Bitmap(imageStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Nome da imagem.</param>
        /// <param name="filename">Caminho do arquivo da imagem.</param>
        public ImageSource(string name, string filename)
        {
            _name = name;

            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                _source = new Bitmap(fs);
            }
        }

       

        #region IImageSource Members

        public string Name
        {
            get { return _name; }
        }

        public Bitmap CreateSource()
        {
            return _source;
        }

        public void CloseSource()
        {
            lock(this)
                if (_source != null)
                {
                    _source.Dispose();
                    _source = null;
                }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_source != null)
                _source.Dispose();
        }

        #endregion
    }

}
