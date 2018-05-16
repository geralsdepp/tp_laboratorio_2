using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks:Producto
    {
        public Snacks(EMarca marca, string codigoDeBarras, ConsoleColor color)
            : base(marca, codigoDeBarras, color) { }
       
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("");
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
