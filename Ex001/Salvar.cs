using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ex001
{
    public partial class Salvar: Form
    {
        // Variável de conexão com o banco de dados
        MySqlConnection Conexao;
        // String de conexão com o banco de dados
        private string data_source = "datasource=localhost;username=root;password=;database=ex001";

        public Salvar()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao = new MySqlConnection(data_source); // Conexão com o banco de dados

                // Comando SQL para inserir os dados
                string sql = "INSERT INTO usuarios (nome, idade)" + 
                    "VALUES" + "('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "')";

                MySqlCommand insert = new MySqlCommand(sql, Conexao);
                Conexao.Open(); // Conexão aberta

                insert.ExecuteReader(); // Executa o comando SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
