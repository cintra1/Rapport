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
    class PedidoDAO
    {
        Pedido pedido = new Pedido();

        private DataSet bdDataSet;

        MySqlConnection conn = ConexaoBD.obterConexao();
        ConexaoBD conexaoBD = new ConexaoBD();


        public void cadastrar(Pedido pedido)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlInsert = "INSERT INTO tblPedido(idCliente, dataVenda, profissionalResponsavel) VALUES(@idCliente, @dataVenda, @profissionalResponsavel);";
                    MySqlCommand command = new MySqlCommand(sqlInsert, conn);

                    command.Parameters.AddWithValue("@idCliente", pedido.getIdCliente());
                    command.Parameters.AddWithValue("@dataVenda", pedido.getDataVenda());
                    command.Parameters.AddWithValue("@profissionalResponsavel", pedido.getProfissionalResponsavel());

                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Pedido cadastrado.");
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

        public void excluir(Pedido pedido)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlDelete = "DELETE FROM tblPedido WHERE idPedido = @idPedido";
                    MySqlCommand command = new MySqlCommand(sqlDelete, conn);
                    command.Parameters.AddWithValue("@idPedido", pedido.getIdPedido());
                    //command.CommandType = CommandType.Text;
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Pedido Excluido.");
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("O pedido está em aberto, delete os detalhes do pedido.");
                        
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

        public void atualizar(Pedido pedido)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlUpdate = "UPDATE tblPedido SET idCliente = @idCliente, dataVenda = @dataVenda, profissionalResponsavel = @profissionalResponsavel  WHERE idPedido = @idPedido";
                MySqlCommand command = new MySqlCommand(sqlUpdate, conn);
                command.Parameters.AddWithValue("@idPedido", pedido.getIdPedido());
                command.Parameters.AddWithValue("@idCliente", pedido.getIdCliente());
                command.Parameters.AddWithValue("@dataVenda", pedido.getDataVenda());
                command.Parameters.AddWithValue("@profissionalResponsavel", pedido.getProfissionalResponsavel());

                try
                {
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Pedido Atualizado.");
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Nenhum Cliente com o ID informado.");
                }

                finally
                {
                    ConexaoBD.fecharConexao();
                }
            }
        }

        public Pedido selecionar(Pedido pedido)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT * FROM tblPedido WHERE idPedido = @idPedido";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idPedido", pedido.getIdPedido());
                MySqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        pedido.setIdPedido(int.Parse(reader[0].ToString()));
                        pedido.setIdCliente(int.Parse(reader[1].ToString()));
                        pedido.setDataVenda(Convert.ToDateTime(reader[2].ToString()));
                        pedido.setProfissionalResponsavel(reader[3].ToString());


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
            return pedido;
        }

        

        public DataTable listarPedido(Pedido pedido)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT idPedido,idCliente, dataVenda,profissionalResponsavel FROM tblPedido";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idPedido", pedido.getIdPedido());

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

        public DataTable pedidoF(Pedido pedido)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT dataVenda,profissionalResponsavel FROM tblPedido";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idPedido", pedido.getIdPedido());

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
