using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal2
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            frmCadastroUsuarios cadastro = new frmCadastroUsuarios();
            cadastro.ShowDialog();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProdutos livro = new frmProdutos();
            livro.ShowDialog();
        }
    }
}
