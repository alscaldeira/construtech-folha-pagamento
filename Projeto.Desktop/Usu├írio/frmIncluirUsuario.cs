using Projeto.Controle;
using Projeto.Modelo;
using System;
using System.Windows.Forms;

namespace Projeto.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIncluirUsuario_Click(object sender, EventArgs e)
        {
            mdlUsuario _mdlUsuario = new mdlUsuario();
            ctlUsuario _ctlUsuario = new ctlUsuario();

            _mdlUsuario.nome = txtNome.Text;
            _mdlUsuario.rg = txtRg.Text;
            _mdlUsuario.cpf = txtCpf.Text;

            //_ctlUsuario.incluirUsuario(_mdlUsuario);
        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
