using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        Paquete paquete;
        public FrmPpal()
        {
            InitializeComponent();
            this.Text = "Correos UTN Geraldine.Meza.2C";
            rtbMostrar.Enabled = false;
            correo = new Correo();
        }

        private void ActualizarEstados()
        {
            lstEstadoEntregado.ResetText();
            lstEstadoEnViaje.ResetText();
            lstEstadoIngresado.ResetText();

            foreach (var item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case EEstado.Ingesado:
                        if (!lstEstadoIngresado.Items.Contains(item.ToString()))
                        {
                            lstEstadoIngresado.Items.Add(item.ToString());
                        }
                        break;
                    case EEstado.EnViaje:
                        if (!lstEstadoEnViaje.Items.Contains(item.ToString()))
                        {
                            lstEstadoEnViaje.Items.Add(item.MostrarDatos(item));
                            lstEstadoIngresado.Items.Clear();
                        }
                        break;
                    case EEstado.Entregado:
                        if (!lstEstadoEntregado.Items.Contains(item.MostrarDatos(item)))
                        {
                            lstEstadoEntregado.Items.Add(item.MostrarDatos(item));
                            lstEstadoEnViaje.Items.Clear();
                        }
                        break;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo += paquete;
                
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                if (elemento is Paquete)
                {
                    rtbMostrar.Text = ((Paquete)elemento).ToString();
                }
                else if (elemento is Correo)
                {

                    rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                }
                
                GuardaString.Guardar(elemento.MostrarDatos(elemento), "salida.txt");
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado); 
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

       
    }
}
