using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient();

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private MySqlConnectionStringBuilder conexaoBanco()

        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "play filmes";
            conexaoBD.UserID = "admin";
            conexaoBD.Password = "";
            conexaoBD.SslMode = 0;
            return conexaoBD;

            private void tblimpar_Click(object sender, EventArgs e)
        {
            tbnome.Clear();
            tbcategoria.Clear();
            tbano.Clear();
        }
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM filme WHERE ativofilme = 1";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgplayfilmes.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgplayfilmes.Rows[0].Clone();//FAZ UM CAST E CLONA A LINHA DA TABELA
                    row.Cells[0].Value = reader.GetInt32(0);//ID
                    row.Cells[1].Value = reader.GetString(1);//NOME
                    row.Cells[2].Value = reader.GetString(2);//CATEGORIA
                    row.Cells[3].Value = reader.GetString(3);//ANO
                    dgplayfilmes.Rows.Add(row);//ADICIONO A LINHA NA TABELA
                }

                realizaConexacoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message);
            }
             private void button1_Click(object sender, EventArgs e)
        {
               
                    MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
                    MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
                    try
                    {
                        realizaConexacoBD.Open();

                        MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                        comandoMySql.CommandText = "INSERT INTO filme (nome,categoria,ano) " +
                            "VALUES('" + tbNome.Text + "', '" + tbCategoria.Text + "', " + Convert.ToInt16(tbAno.Text) + ")";
                        comandoMySql.ExecuteNonQuery();

                        realizaConexacoBD.Close();
                        MessageBox.Show("Inserido com sucesso");
                        atualizarGrid();
                        limparCampos();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
private void button2_Click(object sender, EventArgs e)
        {
                MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
                MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
                try
                {
                    realizaConexacoBD.Open();

                    MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                    comandoMySql.CommandText = "delete INTO filme (nome,categoria,ano) " +
                        "VALUES('" + tbNome.Text + "', '" + tbCategoria.Text + "', " + Convert.ToInt16(tbAno.Text) + ")";
                    comandoMySql.ExecuteNonQuery();

                    realizaConexacoBD.Close();
                    MessageBox.Show("deletado com sucesso");
                    atualizarGrid();
                    limparCampos();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }   private void button3_Click(object sender, EventArgs e)
        {
                    MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
                    MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
                    try
                    {
                        realizaConexacoBD.Open();

                        MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                        comandoMySql.CommandText = "ALTERAR INTO filme (nome,categoria,ano) " +
                            "VALUES('" + tbNome.Text + "', '" + tbCategoria.Text + "', " + Convert.ToInt16(tbAno.Text) + ")";
                        comandoMySql.ExecuteNonQuery();

                        realizaConexacoBD.Close();
                        MessageBox.Show(" alterado com sucesso");
                        atualizarGrid();
                        limparCampos();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }