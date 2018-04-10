using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        { 
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";

            double aux = 0;
            int x = 1;
            string numdec = "";
            int bandera = 0;

            //for para revertir la cadena
            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (binario[i] == 1 || binario[i] == 0)
                {
                    numdec += binario[i];
                    bandera = 1;
                }
            }

            if (bandera == 1)
            {
                //for para calcular el numero decimal
                for (int i = 0; i < numdec.Length; i++)
                {
                    x = Convert.ToInt32(numdec[i]);
                    //si el caracter es 1 calcular potencia
                    if (x == 49)
                        aux += Math.Pow(2, i);
                }
            }
            //convirtiendo a string para mostrar # decimal
            if (aux>0)
	        {
		        retorno = aux.ToString();
	        }
            
            return retorno;
        }
        public string DecimalBinario(double numero)
        {
            string retorno = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        retorno = "0" + retorno;
                    }
                    else
                    {
                        retorno = "1" + retorno;
                    }
                    numero = (int)numero / 2;
                }
            }
            else if(numero == 0)
            {               
                retorno = "0"; 
            }
            else
            {
                retorno = "Valor invalido";
            }
            
            return retorno;
        }
        public string DecimalBinario(string numero)
        {
            string retorno = "";
            double aux;
            if (double.TryParse(numero, out aux))
            {
                retorno = this.DecimalBinario(aux);
            }
            else
                retorno = "Valor invalido";
            return retorno;
        }
        public Numero(){}
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = n1.numero - n2.numero;
            return retorno;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = n1.numero + n2.numero;
            return retorno;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = n1.numero / n2.numero;
            return retorno;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = n1.numero * n2.numero;
            return retorno;
        }
        public static bool operator !=(Numero n2, int cero)
        {
            bool retorno = false;

            if (n2.numero != cero)
                retorno = true;
            return retorno;
        }
        public static bool operator ==(Numero n2, int cero)
        {
            return !(n2.numero != cero);
        }
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            int num;
            if(Int32.TryParse(strNumero, out num))
                retorno = (double)num;
            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
