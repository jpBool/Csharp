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
    public partial class frmCadastroUsuarios : Form
    {
        public frmCadastroUsuarios()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool sucesso = true;
            if (String.IsNullOrEmpty(txtBoxNome.Text) || String.IsNullOrEmpty(txtBoxIdade.Text) || String.IsNullOrEmpty(txtBoxTelefone.Text) || String.IsNullOrEmpty(txtBoxCPF.Text) || String.IsNullOrEmpty(txtBoxSenha.Text))
            {
                MessageBox.Show("Preencha todos os campos corretamente!",
                                "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            else if (txtBoxSenha.Text.Length < 8 || txtBoxSenha.Text.Length > 10)
            {
                MessageBox.Show("Coloque uma senha de no mínimo 8 e no máximo 10 caracteres, por favor!.",
                                "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            else if (txtBoxCPF.Text.Length < 11 || txtBoxCPF.Text.Length > 11)
            {
                MessageBox.Show("Preencha corretamente o campo de CPF.",
                                "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                string sql = "INSERT INTO usuario (nome, cpf, telefone, idade, senha) VALUES (@1, @2, @3, @4)";
                ConexaoBanco.executar(sql, new List<object> { txtBoxNome.Text, txtBoxCPF, txtBoxTelefone.Text, txtBoxIdade, txtBoxSenha.Text });
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ocorreu um erro no cadastro!" +
                            "\n\nMais detalhes: " + ex.Message,
                            "Cadastro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sucesso = false;
            }

            if (sucesso)
            {
                MessageBox.Show("Cadastro realizado com êxito!",
                            "Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxNome.Clear();
                txtBoxIdade.Clear();
                txtBoxCPF.Clear();
                txtBoxTelefone.Clear();
                txtBoxSenha.Clear();
            }
        }
    }
}
