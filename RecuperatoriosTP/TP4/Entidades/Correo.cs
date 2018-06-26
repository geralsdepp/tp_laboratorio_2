using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        public void FinEntregas()
        {
            foreach (var item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
                
            }
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            if (elementos is Correo)
            {
                foreach (var item in this.Paquetes)
                {
                    sb.AppendFormat("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
                    sb.AppendLine();
                }
            }
            
            return sb.ToString();
        }
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (var item in c.paquetes)
            {
                if (p == item)
                {
                    throw new TrackingIdRepetidoException("El paquete se encuentra en la lista");
                }
            }

            if (!c.Paquetes.Contains(p))
            {
                c.paquetes.Add(p);
                try
                {
                    Thread t = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(t);
                    t.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }            
            return c;
        }
    }
}
