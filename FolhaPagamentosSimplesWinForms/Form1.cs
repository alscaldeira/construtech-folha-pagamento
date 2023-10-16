using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolhaPagamentosSimplesWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            int horas, horasextra=0;
            double valhoras, salariomes;

            horas = int.Parse(txt_qtdhoras.Text);
            valhoras = double.Parse(txt_valhora.Text);

            
            horasextra = horas - 160; //Total de horas extra
            salariomes = (horas-horasextra) * valhoras + horasextra*valhoras*1.5;
           

            txt_valorsalfinal.Text = salariomes.ToString("F2");
            



        }

        private void txt_valhora_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
