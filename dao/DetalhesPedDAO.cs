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
    class DetalhesPedDAO
    {
        DetalhesPedido detalhesPedido = new DetalhesPedido();

        private DataSet bdDataSet;

        MySqlConnection conn = ConexaoBD.obterConexao();
        ConexaoBD conexaoBD = new ConexaoBD();


        public void cadastrar(DetalhesPedido detalhesPedido)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlInsert = "INSERT INTO tblDetalhesPedido(idServico, idPedido, statusPedido) VALUES(@idServico, @idPedido, @statusPedido);";
                    MySqlCommand command = new MySqlCommand(sqlInsert, conn);

                    command.Parameters.AddWithValue("@idServico", detalhesPedido.getIdServico());
                    command.Parameters.AddWithValue("@idPedido", detalhesPedido.getIdPedido());
                    command.Parameters.AddWithValue("@StatusPedido", detalhesPedido.getStatusPedido());



                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Detalhes do pedido cadastrados.");
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


        public void atualizar(DetalhesPedido detalhesPedido)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlUpdate = "UPDATE tblDetalhesPedido SET statusPedido = @statusPedido WHERE idServico = @idServico and idPedido = @idPedido";
                MySqlCommand command = new MySqlCommand(sqlUpdate, conn);
                command.Parameters.AddWithValue("@idPedido", detalhesPedido.getIdPedido());
                command.Parameters.AddWithValue("@idServico", detalhesPedido.getIdServico());
                command.Parameters.AddWithValue("@statusPedido", detalhesPedido.getStatusPedido());




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

        public DataTable listarDetalhesPedido(DetalhesPedido detalhesPedido)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT idPedido, idServico, statusPedido FROM tblDetalhesPedido WHERE idPedido = @idPedido";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idPedido", detalhesPedido.getIdPedido());

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

        public void excluir(DetalhesPedido detalhesPedido)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlDelete = "DELETE FROM tblDetalhesPedido WHERE idPedido = @idPedido and idServico = @idServico";
                    MySqlCommand command = new MySqlCommand(sqlDelete, conn);
                    command.Parameters.AddWithValue("@idPedido", detalhesPedido.getIdPedido());
                    command.Parameters.AddWithValue("@idServico", detalhesPedido.getIdServico());
                    //command.CommandType = CommandType.Text;
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Detalhes do Pedido Excluidos.");
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
    }
}
