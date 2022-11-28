using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ProjetoFinal2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            // Abrir form de cadastro
            this.Visible = false;
            frmCadastroUsuarios frmCadastro = new frmCadastroUsuarios();
            frmCadastro.ShowDialog();
            this.Visible = true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtBoxCPF.Text) || String.IsNullOrWhiteSpace(txtBoxSenha.Text))
                {
                    throw new Exception("Preencha todos os campos para fazer o Login, por gentileza!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Login de Usuários", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = "SELECT * FROM usuario WHERE cpf = @1 AND senha = @2";
                var dados = ConexaoBanco.selecionar(sql, new List<object> { txtBoxCPF.Text, txtBoxSenha.Text });
                dados.Read();

                if (dados.HasRows)
                {
                    ConexaoBanco.Desconectar();

                    this.Visible = false;
                    frmMenu frmMenu = new frmMenu();
                    frmMenu.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Registro não encontrado! Confira seus dados, por gentileza!.",
                                "Login de Usuários", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConexaoBanco.Desconectar();
                    return;
                }

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao realizar a pesquisa de clientes." +
                            "\n\nMais detalhes: " + ex.Message,
                            "Pesquisa de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
