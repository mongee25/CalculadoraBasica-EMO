using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraBasica_EMO
{
    public partial class MainPage : ContentPage
    {
        double numUno = 0;
        double numActual = 0;
        string Operacion    ;
        bool operador = false;
        bool muestra = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Boton_Nums(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            string digito = boton.Text;

            if (lbResultado.Text == "0" || operador || muestra)
            {
                lbResultado.Text = digito;
                operador = false;
                muestra = false;
            }
            else
            {
                lbResultado.Text += digito;
            }
            double.TryParse(lbResultado.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("es-ES"), out numActual);
        }


        private void Boton_Resultado(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(lbResultado.Text))
            {
                double numDos = numActual;

                double result = 0;

                switch (Operacion)
                {
                    case "+":
                        result = numUno + numDos;
                        break;
                    case "-":
                        result = numUno - numDos;
                        break;
                    case "*":
                        result = numUno * numDos;
                        break;
                    case "÷":
                        if (numDos != 0)
                        {
                            result = numUno / numDos;
                        }
                        else
                        {
                            lbResultado.Text = "Error";
                            return;
                        }
                        break;
                }
                lbResultado.Text = result.ToString(CultureInfo.GetCultureInfo("es-ES"));
                muestra = true;
            }
        }

        private void Boton_Limpiar(object sender, EventArgs e)
        {
            numActual = 0;
            numUno = 0;
            lbResultado.Text = "0";
            Operacion = null;
            muestra = false;
        }

        private void Boton_Eliminar(object sender, EventArgs e)
        {
            string operacionPantalla = lbResultado.Text;

            if (!string.IsNullOrEmpty(operacionPantalla))
            {
                lbResultado.Text = operacionPantalla.Substring(0, operacionPantalla.Length - 1);
                numActual = double.TryParse(lbResultado.Text, NumberStyles.Any, CultureInfo.GetCultureInfo("es-ES"), out double result) ? result : 0;
            }
            else
            {
                lbResultado.Text = "0";
                numActual = 0;
            }
        }

        private void Boton_Decimal(object sender, EventArgs e)
        {
            if (!lbResultado.Text.Contains(","))
            {
                lbResultado.Text += ",";
            }
        }

        private void Boton_Dividir(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbResultado.Text))
            {
                numUno = numActual;
                Operacion = "÷";
                operador = true;
            }
        }

        private void Boton_Multiplicacion(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbResultado.Text))
            {
                numUno = numActual;
                Operacion = "*";
                operador = true;
            }
        }

        private void Boton_Resta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbResultado.Text))
            {
                numUno = numActual;
                Operacion = "-";
                operador = true;
            }
        }

        private void Boton_Suma(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbResultado.Text))
            {
                numUno = numActual;
                Operacion = "+";
                operador = true;
            }
        }
    }
}
