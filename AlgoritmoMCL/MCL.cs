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

        public List <double> GenerarListaAleatoria (int Semilla, double Multiplicador, double ConstanteAditiva, double Modulo, int numeroDatos) 
        {
            double NumeroDatosAleatorios;

            ListaNumerosAleatorios.Add(Semilla);
            //int n = Semilla;
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
        

    }
}
