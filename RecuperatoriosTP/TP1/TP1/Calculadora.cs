using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = -1;
            switch (operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        retorno = num1 / num2;
                    }
                    break;
            }
            return retorno;
        }

        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            switch (operador)
            {
                case "+":
                    retorno = operador;
                    break;
                case "-":
                    retorno = operador;
                    break;
                case "*":
                    retorno = operador;
                    break;
                case "/":
                    retorno = operador;
                    break;
            }
            return retorno;
        }
    }
}
