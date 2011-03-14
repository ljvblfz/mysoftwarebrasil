using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;

namespace MobileTools.Mathematics
{
    public struct PointF
    {
        #region Variáveis Locais

        public static readonly PointF Empty;
        private float x;
        private float y;

        #endregion

        #region Construtores

        public PointF(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        static PointF()
        {
            Empty = new PointF();
        }

        #endregion

        #region Propriedades

        public bool IsEmpty
        {
            get
            {
                if (this.x == 0f)
                {
                    return (this.y == 0f);
                }
                return false;
            }
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        #endregion

        #region Operadores Sobrecarregados

        /// <summary>
        /// Converte o PointF especificado para um Point.
        /// </summary>
        /// <param name="p">PointF a ser convertido.</param>
        /// <returns>Point do resultado da conversão.</returns>
        public static implicit operator Point(PointF p)
        {
            return new Point((int)Math.Round(p.X), (int)Math.Round(p.Y));
        }

        public static implicit operator PointF(Point p)
        {
            return new PointF((float)p.X, (float)p.Y);
        }

        public static PointF operator +(PointF pt, Size sz)
        {
            return Add(pt, sz);
        }

        public static PointF operator -(PointF pt, Size sz)
        {
            return Subtract(pt, sz);
        }

        public static PointF operator +(PointF pt, SizeF sz)
        {
            return Add(pt, sz);
        }

        public static PointF operator -(PointF pt, SizeF sz)
        {
            return Subtract(pt, sz);
        }

        public static bool operator ==(PointF left, PointF right)
        {
            if (left.X == right.X)
            {
                return (left.Y == right.Y);
            }
            return false;
        }

        public static bool operator !=(PointF left, PointF right)
        {
            return !(left == right);
        }

        #endregion

        #region Métodos Públicos

        public static PointF Add(PointF pt, Size sz)
        {
            return new PointF(pt.X + sz.Width, pt.Y + sz.Height);
        }

        public static PointF Subtract(PointF pt, Size sz)
        {
            return new PointF(pt.X - sz.Width, pt.Y - sz.Height);
        }

        public static PointF Add(PointF pt, SizeF sz)
        {
            return new PointF(pt.X + sz.Width, pt.Y + sz.Height);
        }

        public static PointF Subtract(PointF pt, SizeF sz)
        {
            return new PointF(pt.X - sz.Width, pt.Y - sz.Height);
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj is PointF)
            {
                PointF tf = (PointF)obj;
                if ((tf.X == this.X) && (tf.Y == this.Y))
                {
                    return tf.GetType().Equals(base.GetType());
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{X={0}, Y={1}}}", new object[] { this.x, this.y });
        }
 
    }
}
