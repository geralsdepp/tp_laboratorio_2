using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                this.InformaEstado.Invoke(this, null);
                Thread.Sleep(10000);

                if (this.Estado == EEstado.Ingesado)
                {
                    this.Estado = EEstado.EnViaje;
                }
                else if (this.Estado == EEstado.EnViaje)
                {
                    this.Estado = EEstado.Entregado;
                }
            }
            this.InformaEstado.Invoke(this, null);
            try
            {
                PaqueteDAO.Insertar(this);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }    
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {            
            return String.Format("{0} para {1} ({2})", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega, ((Paquete)elemento).Estado);
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingesado;
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public event DelegadoEstado InformaEstado;
        public delegate void DelegadoEstado(object sender, EventArgs e);
    }

    public enum EEstado
    {
        Ingesado,
        EnViaje,
        Entregado
    }
}
