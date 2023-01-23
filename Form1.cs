using MetodoCongruencialLineal.AlgoritmoMCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace MetodoCongruencialLineal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Paso 1: Condicíon de vacío
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
                {
                    MessageBox.Show("Los números tienen que ser MAYOR que cero, NO VACÍOS");
                    return;
                }


                int Semilla = Convert.ToInt16(textBox1.Text);
                double Multiplicador = Convert.ToDouble(textBox2.Text);
                double ConstanteAditiva = Convert.ToDouble(textBox3.Text);
                double Modulo = Convert.ToDouble(textBox4.Text);
                if (Semilla > 0 && Multiplicador > 0 && ConstanteAditiva > 0 && Modulo > 0)
                {
                    MCL algoritmo = new MCL();
                    List<double> lista = algoritmo.GenerarListaAleatoria(Semilla, Multiplicador, ConstanteAditiva, Modulo);
                    llenarGrid(algoritmo.ListaNumerosAleatorios.Count(), algoritmo);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Vuelve a intentar");
            }

        }

        public void llenarGrid(double NumeroDatosAleatorios, MCL algoritmo)
        {
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Algoritmo MCL");
            dataGridView1.Columns.Add(numeroColumna2, "ID");
            for (int i = 0; i < NumeroDatosAleatorios; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = algoritmo.ListaNumerosAleatorios.ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = i.ToString();
            }
        }

    }
}
