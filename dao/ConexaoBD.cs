using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoDS.dao
{
   class ConexaoBD
    {
        private static String connString = "Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345";
        private static MySqlConnection conn = null;



        public static MySqlConnection obterConexao()
        {

            conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                // MessageBox.Show("Conexão estabelecida com sucesso!");
            }
            catch (Exception ex)
            {
                conn = null;
                MessageBox.Show("Erro: " + ex);
            }

            return conn;
        }

        public static void fecharConexao()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
