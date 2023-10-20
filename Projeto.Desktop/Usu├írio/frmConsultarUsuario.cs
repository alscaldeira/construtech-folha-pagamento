using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto.Desktop.Usuário
{
    public partial class frmConsultarUsuario : Form
    {
        public frmConsultarUsuario()
        {
            InitializeComponent();
        }

        private void frmConsultarUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'pOOIIDataSet.TB_Usuario'. Você pode movê-la ou removê-la conforme necessário.
            this.tB_UsuarioTableAdapter.Fill(this.pOOIIDataSet.TB_Usuario);

        }
    }
}
