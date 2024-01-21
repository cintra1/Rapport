using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoDS.model;

namespace TrabalhoDS.dao
{
    class ServicoDAO
    {
        Servico servico = new Servico();

        private DataSet bdDataSet;

        MySqlConnection conn = ConexaoBD.obterConexao();
        ConexaoBD conexaoBD = new ConexaoBD();


        public void cadastrar(Servico servico)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlInsert = "INSERT INTO tblServico(nome, valorServico) VALUES(@nome, @valorServico);";
                    MySqlCommand command = new MySqlCommand(sqlInsert, conn);

                    command.Parameters.AddWithValue("@nome", servico.getNome());
                    command.Parameters.AddWithValue("@valorServico", servico.getValorServico());

                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Serviço cadastrado.");
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro: " + e.ToString());
                        throw;
                    }

                    finally
                    {
                        ConexaoBD.fecharConexao();
                    }
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("Erro: " + e);
            }

        }

        public void excluir(Servico servico)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlDelete = "DELETE FROM tblServico WHERE idServico = @idServico";
                    MySqlCommand command = new MySqlCommand(sqlDelete, conn);
                    command.Parameters.AddWithValue("@idServico", servico.getIdServico());
                    //command.CommandType = CommandType.Text;
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Serviço Excluido.");
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("O serviço tem custos/pedidos em aberto, delete primeiramente eles.");
                    }

                    finally
                    {
                        ConexaoBD.fecharConexao();
                    }

                }

            }
            catch (Exception e)
            {

                MessageBox.Show("Erro: " + e);
            }
        }

        public void atualizar(Servico servico)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlUpdate = "UPDATE tblServico SET nome = @nome, valorServico = @valorServico  WHERE idServico = @idServico";
                MySqlCommand command = new MySqlCommand(sqlUpdate, conn);
                command.Parameters.AddWithValue("@idServico", servico.getIdServico());
                command.Parameters.AddWithValue("@nome", servico.getNome());
                command.Parameters.AddWithValue("@valorServico", servico.getValorServico());


                try
                {
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro Atualizado.");
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro: " + e.ToString());
                    throw;
                }

                finally
                {
                    ConexaoBD.fecharConexao();
                }
            }
        }

        public Servico selecionar(Servico servico)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT * FROM tblServico WHERE idServico = @idServico";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idServico", servico.getIdServico());
                MySqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        servico.setIdServico(int.Parse(reader[0].ToString()));
                        servico.setNome(reader[1].ToString());
                        servico.setValorServico(double.Parse(reader[2].ToString()));


                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado com o ID informado.");
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro: " + e.ToString());
                }

                finally
                {
                    ConexaoBD.fecharConexao();
                }

            }
            return servico;
        }
        public DataTable listarServico(Servico servico)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT idServico,nome,valorServico FROM tblServico";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idServico", servico.getIdServico());

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                try
                {
                    adapter.Fill(dt);
                    //DataGrid.DataSouce = listarDetalhesPedido;

                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro: " + e.ToString());
                }

                finally
                {
                    ConexaoBD.fecharConexao();
                }

            }
            return dt;
        }
    }
}
