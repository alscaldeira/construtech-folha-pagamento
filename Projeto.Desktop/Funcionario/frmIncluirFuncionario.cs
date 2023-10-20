using Projeto.Controle;
using Projeto.Modelo;
using System;
using System.Windows.Forms;

namespace Projeto.Desktop.Funcionario
{
    public partial class frmIncluirFuncionario : Form
    {
        public frmIncluirFuncionario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncluirFuncionario_Click(object sender, EventArgs e)
        {
            mdlFuncionario _mdlFuncionario = new mdlFuncionario();
            ctlFuncionario _ctlFuncionario = new ctlFuncionario();
            bool retornarInclusaofuncionario = false;

            try
            {
                if ((!String.IsNullOrEmpty(txtNome.Text)) && (!String.IsNullOrEmpty(txtIdade.Text)))
                {
                    _mdlFuncionario.nome = txtNome.Text;
                    _mdlFuncionario.idade = Convert.ToInt16(txtIdade.Text);

                    retornarInclusaofuncionario = _ctlFuncionario.incluirFuncionario(_mdlFuncionario);

                    if (retornarInclusaofuncionario)
                    {
                        MessageBox.Show("Funcionário cadastrado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar funcionário.");
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário - " + ex.Message);
            }
        }
        private void inicializarControles()
        {
            txtNome.Clear();
            txtIdade.Clear();
            txtNome.Focus();
        }
    }
}
