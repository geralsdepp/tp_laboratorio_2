using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1;

namespace Mi_Calculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            this.Text = "Calculadora de Geraldine del curso 2C";
            this.CenterToScreen();
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            cmbOperador.Text = "+";
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            lblResultado.Text = num.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            lblResultado.Text = num.BinarioDecimal(lblResultado.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = LaCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();
        }

        //Borrar los datos del text box, comboBox y Label.
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.ResetText();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            Calculadora calculadora = new Calculadora();
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            resultado = calculadora.Operar(num1, num2, operador);

            return resultado;
        }
    }
}
