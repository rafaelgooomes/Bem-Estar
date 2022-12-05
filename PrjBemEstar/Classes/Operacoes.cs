using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjBemEstar.Classes
{
    public class Operacoes
    {
        public static double CalculoIMC(double p, double a)
        {
            return p / (a * a);
        }

        public static string AvisoIMC(double p, double a, double imc)
        {
            double calcMin, calcMax, pi;

            if (imc < 18.6) // calculando e mostrando quantos pesos está abaixo do peso mínimo ideal para a altura
            {
                calcMin = (a * a) * 18.6;
                calcMax = (a * a) * 24.9;

                pi = calcMin - p;

                return "O seu peso ideal deve ficar entre " + calcMin.ToString("n2") + " kg e " + calcMax.ToString("n2") + " kg (Está " + pi.ToString("n2") + " kg abaixo do peso mínimo ideal para a sua altura).";
            }
            else if (imc >= 18.6 && imc <= 24.9) // calculando e mostrando quantos pesos está na obesidade 2
            {
                calcMin = (a * a) * 18.6;
                calcMax = (a * a) * 24.9;

                return "O seu peso está entre " + calcMin.ToString("n2") + " kg e " + calcMax.ToString("n2") + " kg do peso ideal para a sua altura.";
            }
            else // calculando e mostrando quantos pesos está na obesidade 2
            {
                calcMin = (a * a) * 18.6;
                calcMax = (a * a) * 24.9;

                pi = p - calcMax;

                return "O seu peso ideal deve ficar entre " + calcMin.ToString("n2") + " kg e " + calcMax.ToString("n2") + " kg (Está " + pi.ToString("n2") + " kg acima do peso máximo ideal para a sua altura).";
            }
        }
    }
}