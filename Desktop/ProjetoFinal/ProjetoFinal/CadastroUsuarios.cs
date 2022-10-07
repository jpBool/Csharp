using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProjetoFinal
{
    public partial class CadastroUsuarios : Form
    {
        public CadastroUsuarios()
        {
            InitializeComponent();


            //Inclua o código embaixo do InitializeComponent();


            //Instanciando o formulário

            FormSplashScreen frmSplashScreen = new FormSplashScreen();


            //Exibindo o SplashScreen

            frmSplashScreen.Show();


            //Inclua o namespace

            //Tempo que irá aparecer em milisegundos

            Thread.Sleep(3000);


            //Fechando o SplashScreen

            frmSplashScreen.Close();



          
        }

        private void CadastroUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
