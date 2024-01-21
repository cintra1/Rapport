using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoDS.dao;

namespace TrabalhoDS.dao
{
    class loginDAO
    {
        public bool tem = false;
        public String mensagem;
        MySqlConnection conn = ConexaoBD.obterConexao();
        ConexaoBD conexaoBD = new ConexaoBD();
        MySqlDataReader dr;


        public bool verificarLogin(String loginUsuario, String senhaUsuario)
        {
          
                string comando = "SELECT * FROM tblUsuario where loginUsuario = @loginUsuario and senhaUsuario = @senhaUsuario";

                MySqlCommand cmd = new MySqlCommand(comando, conn);
                cmd.Parameters.AddWithValue("@loginUsuario", loginUsuario);
                cmd.Parameters.AddWithValue("@senhaUsuario", senhaUsuario);


                try
                {
                if (conn.State == ConnectionState.Open)
                {
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        tem = true;
                    }
                }
                    conn.Close();
                }
                catch (SqlException)
                {

                    this.mensagem = "DEU RUIM!";
                }

                return tem;

            
        }

        public String cadastrar(String loginUsuario, String senhaUsuario, String confSenhaUsuario)
        {
            
            tem = false;
            if (senhaUsuario.Equals(confSenhaUsuario))
            {
                String sqlInsert = "INSERT INTO tblUsuario(loginUsuario,senhaUsuario) VALUES(@l,@s);";
                MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);


                cmd.Parameters.AddWithValue("@l", loginUsuario);
                cmd.Parameters.AddWithValue("@s", senhaUsuario);

                try
                {
                    cmd.Connection = ConexaoBD.obterConexao();
                    cmd.ExecuteNonQuery();
                    ConexaoBD.fecharConexao();
                    this.mensagem = "Cadastrado com sucesso!";
                    tem = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro: " + e.ToString());
                    throw;
                }
            }
            else
            {
                this.mensagem = "Senhas não correspondem!";
            }
            return mensagem;
        }
    }
}
