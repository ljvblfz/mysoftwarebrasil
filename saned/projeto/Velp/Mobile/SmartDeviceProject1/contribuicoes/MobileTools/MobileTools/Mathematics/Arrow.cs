using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MobileTools.Mathematics
{
    public class Arrow
    {
        #region Variáveis Locais

        private PointF[] m_Points = new PointF[3];

        private PointF m_BeginPoint;
        private PointF m_EndPoint;
        private SizeF m_Size;
        private Point m_Location;
        private bool buildPoints = false;

        #endregion

        #region Eventos

        public event EventHandler OnResize;
        public event EventHandler OnChangedPosition;
        public event EventHandler OnChangedPoints;

        #endregion

        #region Propriedades

        /// <summary>
        /// Tamanho da seta.
        /// </summary>
        public SizeF Size
        {
            get { return m_Size; }
            set
            {
                m_Size = value;

                GeneratePoints();
                if (OnResize != null)
                    OnResize(this, null);
            }
        }

        /// <summary>
        /// Larguta da seta.
        /// </summary>
        public float Width
        {
            get { return m_Size.Width; }
            set
            {
                m_Size.Width = value;

                GeneratePoints();
                if (OnResize != null)
                    OnResize(this, null);
            }
        }

        /// <summary>
        /// Altura da seta.
        /// </summary>
        public float Heigth
        {
            get { return m_Size.Height; }
            set
            {
                m_Size.Height = value;

                GeneratePoints();
                if (OnResize != null)
                    OnResize(this, null);
            }
        }

        /// <summary>
        /// Localização da Seta.
        /// </summary>
        public Point Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }

        /// <summary>
        /// Ponto inicial da seta.
        /// </summary>
        public PointF BeginPoint
        {
            get { return m_BeginPoint; }
            set
            {
                m_BeginPoint = value;

                GeneratePoints();
                if (OnChangedPosition != null)
                    OnChangedPosition(this, null);
            }
        }

        /// <summary>
        /// Ponto final da seta.
        /// </summary>
        public PointF EndPoint
        {
            get { return m_EndPoint; }
            set
            {
                m_EndPoint = value;

                GeneratePoints();
                if (OnChangedPosition != null)
                    OnChangedPosition(this, null);
            }
        }

        /// <summary>
        /// Pontos que montam a seta.
        /// </summary>
        public PointF[] PointFs
        {
            get 
            {
                if (buildPoints) 
                    BuildPointsArrow();
                return m_Points; 
            }
            set { m_Points = value; }
        }

        /// <summary>
        /// Pontos que montam a seta.
        /// </summary>
        public Point[] Points
        {
            get 
            { 
                Point[] ps = new Point[m_Points.Length];

                for (int i = 0; i < m_Points.Length; i++)
                    ps[i] = PointFs[i];

                return ps; 
            }
        }

        #endregion

        #region Métodos Publicos

        /// <summary>
        /// Rotaciona os pontos da seta.
        /// </summary>
        /// <param name="radius">Ângulo de rotação em radianos.</param>
        public void Rotate(double radius)
        {
            m_EndPoint = Transformations2D.Rotate(radius, m_BeginPoint, m_EndPoint);
            m_Points = Transformations2D.Rotate(radius, m_BeginPoint, m_Points);
        }

        /// <summary>
        /// Rotaciona os pontos da seta.
        /// </summary>
        /// <param name="degrees">Ângulo de rotação em graus.</param>
        public void RotateDegrees(double degrees)
        {
            Rotate(Transformations2D.DegreesToRadius(degrees));
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="beginPoint">Ponto inicial.</param>
        /// <param name="endPoint">Ponto final.</param>
        /// <param name="width">Largura da seta.</param>
        /// <param name="height">Altura da seta.</param>
        public Arrow(PointF beginPoint, PointF endPoint, float width, float height)
        {
            m_Size.Width = width;
            m_Size.Height = height;
            m_BeginPoint = beginPoint;
            m_EndPoint = endPoint;

            GeneratePoints();

        }

        public Arrow()
            : this(new PointF(0, 0), new PointF(0, 0), 0, 0)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Largura da seta.</param>
        /// <param name="height">Altura da seta.</param>
        public Arrow(float width, float height)
            : this(new PointF(0, 0), new PointF(0, 0), width, height)
        {

        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Gera os pontos.
        /// </summary>
        private void GeneratePoints()
        {
            buildPoints = true; // Identifica que o pontos devem ser construidos
            if (OnChangedPoints != null)
                OnChangedPoints(this, null);
        }

        /// <summary>
        /// Constroi os pontos da seta.
        /// </summary>
        private void BuildPointsArrow()
        {
            PointF[] points = m_Points;
            PointF p = new PointF();
            int j = 0;

            // Calcula a distância entre os dois pontos
            double h = Transformations2D.Distance(m_BeginPoint, m_EndPoint);
            double w; // Larguda de cada lado da seta

            // Se a largura da seta não for um número par
            if ((m_Size.Width % 2) == 0)
                w = m_Size.Width / 2;
            else
                w = (Width - 1) / 2;

            // Verifica o ângulo para a largura da seta
            double a = Math.Asin(w / m_Size.Height);

            // Calcula o cosseno e o seno dos 2 pontos informados
            double cosseno = (Math.Abs(m_EndPoint.X - m_BeginPoint.X) / h);
            double seno = (Math.Abs(m_EndPoint.Y - m_BeginPoint.Y) / h);

            // Verifica os quadrantes em se encontram os pontos
            int q = (m_EndPoint.X - m_BeginPoint.X) > 0 ? 1 : -1;
            int q2 = (m_EndPoint.Y - m_BeginPoint.Y) > 0 ? 1 : -1;

            PointF pointRef = new PointF();
            pointRef.X = m_EndPoint.X - (q * Convert.ToSingle(cosseno * (m_Size.Height * 2)));
            pointRef.Y = m_EndPoint.Y - (q2 * Convert.ToSingle(seno * (m_Size.Height * 2)));

            for (int i = -1; i <= 1; i += 2)
            {
                p = new PointF();
                p.X = m_EndPoint.X - (q * Convert.ToSingle(cosseno * (m_Size.Height)));
                p.Y = m_EndPoint.Y - (q2 * Convert.ToSingle(seno * (m_Size.Height)));

                p = Transformations2D.Rotate(((double)i) * a, pointRef, p);
                points[j++] = p;
            }

            points[2] = m_EndPoint;

            buildPoints = false; // Identifica que os pontos já foram construídos
        }

        #endregion
    }
}
