using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_Teste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Calcular_Click(object sender, EventArgs e)
        {
            SalarioCalculo.Calcular();
        }
    }

    class SalarioCalculo
    {
        private static double txtSalBru;
        private static double txtINSS;
        private static double txtIR;

        static void Calcular()
        {
            double salarioBruto = txtSalBru; // Substituir pelo valor do salário bruto
            double inss = txtINSS;
            double irrf = txtIR;

            // Cálculo do INSS
            if (salarioBruto <= 1045.0)
            {
                inss = salarioBruto * 0.075;
            }
            else if (salarioBruto <= 2089.6)
            {
                inss = salarioBruto * 0.09;
            }
            else if (salarioBruto <= 3134.4)
            {
                inss = salarioBruto * 0.12;
            }
            else if (salarioBruto <= 6101.06)
            {
                inss = salarioBruto * 0.14;
            }
            else
            {
                inss = 6101.06 * 0.14; // Para salários acima do teto, considera o INSS máximo
            }

            // Cálculo do IRRF 
            if (salarioBruto <= 3000.0) //Exemplo
            {
                irrf = 0.0;
            }
            else if (salarioBruto <= 6000.0)
            {
                irrf = salarioBruto * 0.1;
            }
            else
            {
                irrf = salarioBruto * 0.2;
            }

            double salarioLiquido = salarioBruto - inss - irrf;

            Console.WriteLine($"Salário Bruto: R${salarioBruto}");
            Console.WriteLine($"INSS: R${inss}");
            Console.WriteLine($"IRRF: R${irrf}");
            Console.WriteLine($"Salário Líquido: R${salarioLiquido}");
        }
    }

    

















}

            



