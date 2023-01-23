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
        public double NumeroDatosAleatorios;

        //Constructor
        public MCL()
        {
         
        }

        public List <double> GenerarListaAleatoria (double Semilla, double Multiplicador, double ConstanteAditiva, double Modulo) 
        {
            double NumeroDatosAleatorios;

            ListaNumerosAleatorios.Add(Semilla);

            for (int n = 0; n == ListaNumerosAleatorios[n]; n++) 
            {
                double SigNumeroAleatorio = ((Multiplicador * ListaNumerosAleatorios[n]) + ConstanteAditiva) % Modulo;
                ListaNumerosAleatorios.Add(SigNumeroAleatorio);
            }

            NumeroDatosAleatorios = ListaNumerosAleatorios.Count();
            return ListaNumerosAleatorios;
        
        }
        

    }
}
