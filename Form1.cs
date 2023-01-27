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
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;


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
                int Multiplicador = Convert.ToInt16(textBox2.Text);
                double ConstanteAditiva = Convert.ToDouble(textBox3.Text);
                int Modulo = Convert.ToInt16(textBox4.Text);
                int numeroDatos = Convert.ToInt16(textBox5.Text);
                if (Modulo < Semilla && Modulo < ConstanteAditiva && Modulo < Multiplicador)
                {
                    MessageBox.Show("Modulo Incorrecto");
                    return;
                }
                if (Semilla > 0 && Multiplicador > 0 && ConstanteAditiva > 0 && Modulo > 0)
                {
                    MCL algoritmo = new MCL();
                    List<double> lista = algoritmo.GenerarListaAleatoria(Semilla, Multiplicador, ConstanteAditiva, Modulo, numeroDatos);
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
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = algoritmo.ListaNumerosAleatorios[i].ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = i.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DescargaExcel(dataGridView1);
        }
        public void DescargaExcel(DataGridView data)
        {
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;
            // Llenar (construir) encabezados
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna = indiceColumna + 1;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }
            // Llenar filas

            int indiceFila = 0;
            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFila + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            exportarExcel.Visible = true;

        }

       
    }
}