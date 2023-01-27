using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MetodoCongruencialLineal.AlgoritmoMCL
{
    public class MCL
    {
        public List <double> ListaNumerosAleatorios = new List<double>();

        //Cambio #1: Agregué una lista para guardar los valores esperados con índice i
        //public List <double> ListaNumerosEsperados = new List<double>();

        public double NumeroDatosAleatorios;

        //Cambio #2: Agregue una variable para guardar el numero de observaciones y asi calcular el valor esperado; (N)
        //public double NumerodeObservaciones; // N

        //public double DatoEsperado;

        //Constructor
        public MCL()
        {
         
        }

        public List <double> GenerarListaAleatoria (int Semilla, int Multiplicador, double ConstanteAditiva, int Modulo, int numeroDatos) 
        {
            double NumeroDatosAleatorios;

            ListaNumerosAleatorios.Add(Semilla);
            for (int n = 0; n < numeroDatos; n++)
            //while (n != ListaNumerosAleatorios[n])
            {
                double SigNumeroAleatorio = ((Multiplicador * ListaNumerosAleatorios[n]) + ConstanteAditiva) % Modulo;
                ListaNumerosAleatorios.Add(SigNumeroAleatorio);
                if (SigNumeroAleatorio == Semilla) 
                {
                    break;
                }
            }

            NumeroDatosAleatorios = ListaNumerosAleatorios.Count();
            return ListaNumerosAleatorios;
        }
        // Cambio #4 Creé nuevo método para calcular el dato esperado.
        /*public void DatosEsperados(double NumeroDatosAleatorios,int Multiplicador, int Modulo) 
        {
            IEnumerable<int> range = Enumerable.Range(Multiplicador, Modulo)

            DatoEsperado = NumeroDatosAleatorios / (NumeroDatosAleatorios / (Modulo - 1));   */



        

    }
}
