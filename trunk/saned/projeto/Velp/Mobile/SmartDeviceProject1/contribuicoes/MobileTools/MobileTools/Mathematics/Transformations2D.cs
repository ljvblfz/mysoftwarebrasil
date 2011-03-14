using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MobileTools.Mathematics
{
    public class Transformations2D
    {
        /// <summary>
        /// Calcula a distância entre 2 pontos.
        /// </summary>
        /// <param name="point1">Ponto 1.</param>
        /// <param name="point2">Ponto 2.</param>
        /// <returns>Distância entre os dois pontos.</returns>
        public static double Distance(PointF point1, PointF point2)
        {
            return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
        }

        /// <summary>
        /// Converte graus para radianos.
        /// </summary>
        /// <param name="degrees">Valor em graus.</param>
        /// <returns>Valor em radianos.</returns>
        public static double DegreesToRadius(double degrees)
        {
            return (degrees * Math.PI / 180);
        }

        /// <summary>
        /// Converte radianos para graus.
        /// </summary>
        /// <param name="radius">Valor em radianos.</param>
        /// <returns>Valor em graus.</returns>
        public static double RadiusToDegrees(double radius)
        {
            return (radius / (Math.PI / 180));
        }

        /// <summary>
        /// Obtem o angulo de inclinação entre dois pontos.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Ângulo entre os dois pontos.</returns>
        public static double GetAngle(PointF point1, PointF point2)
        {
            return Math.Asin((point2.Y - point1.Y) / Distance(point1, point2));
        }

        /// <summary>
        /// Rotaciona um conjunto de pontos em um determinado ângulo apartir de um ponto de referência.
        /// </summary>
        /// <param name="angle">Ângulo de Rotação.</param>
        /// <param name="pointRef">Ponto de referência.</param>
        /// <param name="points">Conjunto de pontos a serem rotacionados.</param>
        /// <returns>Novo pontos já rotacionados.</returns>
        public static PointF[] Rotate(double angle, PointF pointRef, PointF[] points)
        {
            PointF[] p = new PointF[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                p[i] = Rotate(angle, pointRef, points[i]);
            }

            return p;
        }

        /// <summary>
        /// Rotaciona um ponto em um determinado ângulo apartir de um ponto de referência.
        /// </summary>
        /// <param name="angle">Ângulo de Rotação.</param>
        /// <param name="pointRef">Ponto de referência.</param>
        /// <param name="point">Ponto a ser rotacionado.</param>
        /// <returns>Novo ponto rotacionado.</returns>
        public static PointF Rotate(double angle, PointF pointRef, PointF point)
        {
            PointF p = new PointF();

            // Faz a transposição do ponto a ser rotacionado levando em consideração
            // que o ponto de referência seja esteja nas coordenadas (0,0)
            p.X = point.X - pointRef.X;
            p.Y = point.Y - pointRef.Y;

            p = Rotate(angle, p);

            // Faz novamente a transposição do ponto para a posição correta
            p.X += pointRef.X;
            p.Y += pointRef.Y;

            return p;
        }

        /// <summary>
        /// Rotaciona um ponto apartir do ponto (0,0) em um determinado ângulo.
        /// </summary>
        /// <param name="angle">Ângulo de Rotação.</param>
        /// <param name="point">Ponto a ser rotacionado.</param>
        /// <returns>Novo ponto rotacionado.</returns>
        public static PointF Rotate(double angle, PointF point)
        {
            double xold, yold;
            PointF newpoint = new PointF();

            double cos = Math.Cos(angle), sin = Math.Sin(angle);

            xold = point.X;
            yold = point.Y;

            newpoint.X = Convert.ToSingle(xold * cos - yold * sin);
            newpoint.Y = Convert.ToSingle(xold * sin + yold * cos);
            return newpoint;
        }

        /// <summary>
        /// Rotaciona um ponto apartir do ponto (0,0) em um determinado ângulo.
        /// </summary>
        /// <param name="angle">Ângulo de Rotação.</param>
        /// <param name="point">Ponto a ser rotacionado.</param>
        /// <returns>Novo ponto rotacionado.</returns>
        public static Point Rotate(double angle, Point point)
        {
            return Rotate(angle, point);
        }

        /// <summary>
        /// Define uma nova escala para um conjunto de pontos.
        /// </summary>
        /// <param name="scale">Escala</param>
        /// <param name="points">Conjunto de pontos.</param>
        /// <returns>Novos ponto com a nova escala.</returns>
        public static PointF[] Scale(float scale, PointF[] points)
        {
            PointF[] newPoints = new PointF[points.Length];

            for (int i = 0; i < points.Length; i++)
                newPoints[i] = Scale(scale, points[i]);

            return newPoints;
        }

        /// <summary>
        /// Define uma nova escala para o ponto.
        /// </summary>
        /// <param name="scale">Nova escala.</param>
        /// <param name="point">Ponto usado.</param>
        /// <returns>Ponto com as nova coordendas.</returns>
        public static PointF Scale(float scale, PointF point)
        {
            return new PointF(point.X * scale, point.Y * scale);
        }

        /// <summary>
        /// Calcula a área do tringulo que é composto pelo 3 pontos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public static float CalculateTriangleArea(Point p1, Point p2, Point p3)
        {
            float[] lados = new float[3];

            lados[0] = (float)Distance(p1, p2);
            lados[1] = (float)Distance(p2, p3);
            lados[2] = (float)Distance(p3, p1);

            if (lados[0] == lados[1] && lados[1] == lados[2])
            {
                return (lados[0] * lados[0] * (float)Math.Sqrt(3)) / 4;
            }
            else
            {
                // Calcula a area através do Teorema de Heron
                float p = (lados[0] + lados[1] + lados[2]) / 2;
                return (float)Math.Sqrt(p * (p - lados[0]) * (p - lados[1]) * (p - lados[2]));
            }
        }

        /// <summary>
        /// Calcula a área do poligono.
        /// </summary>
        /// <param name="points">Pontos do poligono.</param>
        /// <returns></returns>
        public static float CalculatePolygonoArea(Point[] points)
        {
            if (points.Length < 3) return 0.0f;

            if (points.Length == 3)
            {
                return CalculateTriangleArea(points[0], points[1], points[2]);
            }

            // Recupera a quantidade de triangulos no poligono
            int numberTriangles = points.Length / 2;

            float area = 0.0f;

            // Calcula a area dos triangulos do poligono
            for (int i = 2; i < points.Length - 1; i++)
            {
                area += CalculateTriangleArea(points[0], points[i - 1], points[i]);
                numberTriangles--;
            }

            // Verifica se sobrou algum triangulo para calcular a area
            if (numberTriangles > 0)
                area += CalculateTriangleArea(points[0], points[points.Length - 1], points[points.Length - 2]);

            return area;
        }
    }
}
