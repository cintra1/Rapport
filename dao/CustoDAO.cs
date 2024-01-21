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
    class CustoDAO
    {
        Custo custo = new Custo();

        private DataSet bdDataSet;

        MySqlConnection conn = ConexaoBD.obterConexao();
        ConexaoBD conexaoBD = new ConexaoBD();


        public void cadastrar(Custo custo)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlInsert = "INSERT INTO tblCusto(idServico, valorCusto, descricaoCusto) VALUES(@idServico, @valorCusto, @descricaoCusto);";
                    MySqlCommand command = new MySqlCommand(sqlInsert, conn);

                    command.Parameters.AddWithValue("@idServico", custo.getIdServico());
                    command.Parameters.AddWithValue("@valorCusto", custo.getValorCusto());
                    command.Parameters.AddWithValue("@descricaoCusto", custo.getDescricaoCusto());

                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Custo cadastrado.");
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

        public void excluir(Custo custo)
        {
            try
            {

                if (conn.State == ConnectionState.Open) // verifica se a conexão está aberta
                {
                    String sqlDelete = "DELETE FROM tblCusto WHERE idCusto = @idCusto";
                    MySqlCommand command = new MySqlCommand(sqlDelete, conn);
                    command.Parameters.AddWithValue("@idCusto", custo.getIdCusto());
                    //command.CommandType = CommandType.Text;
                    try
                    {
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Custo Excluido.");
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

        public void atualizar(Custo custo)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlUpdate = "UPDATE tblCusto SET valorCusto = @valorCusto, descricaoCusto = @descricaoCusto  WHERE idCusto = @idCusto";
                MySqlCommand command = new MySqlCommand(sqlUpdate, conn);
                command.Parameters.AddWithValue("@idCusto", custo.getIdCusto());
               
                command.Parameters.AddWithValue("@valorCusto", custo.getValorCusto());
                command.Parameters.AddWithValue("@descricaoCusto", custo.getDescricaoCusto());
                

                try
                {
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Custo Atualizado.");
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

        public Custo selecionar(Custo custo)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT * FROM tblCusto WHERE idCusto = @idCusto";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idCusto", custo.getIdCusto());
                MySqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        custo.setIdCusto(int.Parse(reader[0].ToString()));
                        custo.setIdServico(int.Parse(reader[1].ToString()));
                        custo.setValorCusto(double.Parse(reader[2].ToString()));
                        custo.setDescricaoCusto(reader[3].ToString());


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
            return custo;
        }

        public DataTable listarCusto(Custo custo)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Open)
            {
                String sqlSelect = "SELECT idCusto,idServico,valorCusto,descricaoCusto FROM tblCusto";
                MySqlCommand command = new MySqlCommand(sqlSelect, conn);
                command.Parameters.AddWithValue("@idCusto", custo.getIdCusto());

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
