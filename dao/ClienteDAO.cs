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
    class ClienteDAO
    {
        Cliente cliente = new Cliente();

        private DataSet bdDataSet;

        MySqlConnection conn = ConexaoBD.obterConexao();
        ConexaoBD conexaoBD = new ConexaoBD();


        public void cadastrar(Cliente cliente)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlInsert = "INSERT INTO tblCliente(nome, cnpj, telefone, email, endereco) VALUES(@nome, @cnpj, @telefone, @email, @endereco);";
                    MySqlCommand command = new MySqlCommand(sqlInsert, conn);

                    command.Parameters.AddWithValue("@nome", cliente.getNome());
                    command.Parameters.AddWithValue("@cnpj", cliente.getCnpj());
                    command.Parameters.AddWithValue("@telefone", cliente.getTelefone());
                    command.Parameters.AddWithValue("@email", cliente.getEmail());
                    command.Parameters.AddWithValue("@endereco", cliente.getEndereco());


                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Cliente cadastrado.");
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

        public void excluir(Cliente cliente)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlDelete = "DELETE FROM tblCliente WHERE idCliente = @idCliente";
                    MySqlCommand command = new MySqlCommand(sqlDelete, conn);
                    command.Parameters.AddWithValue("@idCliente", cliente.getIdCliente());
                    //command.CommandType = CommandType.Text;
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Cliente Excluido.");
                        }

                    }
                    catch (Exception e)
                    {

                        MessageBox.Show("O cliente tem pedidos em aberto, delete primeiramente os pedidos.");
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

        public void atualizar(Cliente cliente)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlUpdate = "UPDATE tblCliente SET nome = @nome, cnpj = @cnpj, telefone = @telefone, email = @email, endereco = @endereco  WHERE idCliente = @idCliente";
                MySqlCommand command = new MySqlCommand(sqlUpdate, conn);
                command.Parameters.AddWithValue("@idCliente", cliente.getIdCliente());
                command.Parameters.AddWithValue("@nome", cliente.getNome());
                command.Parameters.AddWithValue("@cnpj", cliente.getCnpj());
                command.Parameters.AddWithValue("@telefone", cliente.getTelefone());
                command.Parameters.AddWithValue("@email", cliente.getEmail());
                command.Parameters.AddWithValue("@endereco", cliente.getEndereco());


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

        public Cliente selecionar(Cliente cliente)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT * FROM tblCliente WHERE idCliente = @idCliente";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idCliente", cliente.getIdCliente());
                MySqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        cliente.setIdCliente(int.Parse(reader[0].ToString()));
                        cliente.setNome(reader[1].ToString());
                        cliente.setCnpj(reader[1].ToString());
                        cliente.setTelefone(reader[1].ToString());
                        cliente.setEmail(reader[1].ToString());
                        cliente.setEndereco(reader[1].ToString());

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
            return cliente;
        }

        public DataTable listarClientes(Cliente cliente)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT idCliente,nome,cnpj,telefone,email,endereco FROM tblCliente";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idCliente", cliente.getIdCliente());

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
