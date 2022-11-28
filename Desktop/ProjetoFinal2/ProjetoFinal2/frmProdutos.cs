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
    public partial class frmProdutos : Form
    {
        private NpgsqlConnection cn = new NpgsqlConnection();
        private string stringConexao = "server = pgsql.projetoscti.com.br;" +
                "database = projetoscti; port=5432; " +
                "user id = projetoscti; password = gaspar";

        public frmProdutos()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            //se usuario digitou id 
            string sql;
            //sql = "select * from cine order by nome_fantasia";
            sql = "select * from livros";

            // Criar e configurar um objeto Command - responsável por
            // processar comandos SQL contra a fonte de dados
            NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

            // Criar um DataAdapter do comando sql contra o banco
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

            // Carregar os dados do DataAdapter para o DataSet
            DataSet ds = new DataSet();

            da.Fill(ds);

            dgvProdutos.DataSource = ds.Tables[0];
        }
    }
}

