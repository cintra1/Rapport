using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoDS.dao;
using TrabalhoDS.model;

namespace TrabalhoDS.Consultar
{
    public partial class formExibirCliente : Form
    {
        public formExibirCliente()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formListaClientes frm = new formListaClientes();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            TelaPrincipal frm = new TelaPrincipal();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            formFaturamento frm = new formFaturamento();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            formPedidos frm = new formPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            formServicos frm = new formServicos();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            formListaClientes frm = new formListaClientes();
            frm.Show();
            this.Visible = false;
        }

        private void listaDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaServicos frm = new formListaServicos();
            frm.Show();
            this.Visible = false;
        }

        private void listaDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaPedidos frm = new formListaPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteDAO clienteDAO = new ClienteDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                cliente.setIdCliente(int.Parse(textId.Text));

                cliente.setNome(textBox1.Text);
                cliente.setCnpj(textBox2.Text);
                cliente.setTelefone(textBox3.Text);
                cliente.setEmail(textBox4.Text);
                cliente.setEndereco(textBox5.Text);



                clienteDAO.atualizar(cliente);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteDAO clienteDAO = new ClienteDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                try
                {
                    cliente.setIdCliente(int.Parse(textId.Text));
                    clienteDAO.excluir(cliente);
                }
                catch (Exception)
                {
                    throw;

                }
                
                this.Visible = false;
                formListaClientes frm = new formListaClientes();
                frm.Show();
            }
        }

        MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");

        DataSet ds;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtDate.Text.Equals("  /  /") || txtDate2.Text.Equals("  /  /"))
            {
                try { 
                con.Open();
                int id = Convert.ToInt32(textId.Text);



                string query2 = ("select sum(valorServico) from tblServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where statusPedido = 1 and idCliente = '" + id + "' ;");

                MySqlCommand sqcon2 = new MySqlCommand(query2, con);

                MySqlDataAdapter ad = new MySqlDataAdapter(sqcon2);

                ad.Fill(dt2);
                foreach (DataRow row in dt2.Rows)
                {
                    txtServico.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");
                }

                string query3 = ("select sum(valorCusto) from tblCusto inner join tblServico on tblCusto.idServico=tblServico.idServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where idCliente = '" + id + "' ;");

                MySqlCommand sqcon3 = new MySqlCommand(query3, con);

                MySqlDataAdapter ada = new MySqlDataAdapter(sqcon3);

                ada.Fill(dt3);
                foreach (DataRow row in dt3.Rows)
                {
                    txtCusto.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");


                }

                double auxServi = Convert.ToDouble(txtServico.Text.Remove(0, 3));
                double auxCusto = Convert.ToDouble(txtCusto.Text.Remove(0, 3));

                txtFaturamento.Text = (auxServi - auxCusto).ToString("C");
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("O Cliente não tem pedidos em aberto, crie um para visualizar o faturamento.");
            }
        }
            else
            {
                con.Open();
                int id = Convert.ToInt32(textId.Text);
                DateTime date1 = Convert.ToDateTime(txtDate.Text);
                DateTime date2 = Convert.ToDateTime(txtDate2.Text);


                string query2 = ("select sum(valorServico) from tblServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where statusPedido = 1 and idCliente = '" + id + "' and dataVenda between '" + date1.Year + "-" + date1.Month + "-" + date1.Day + "' and '" + date2.Year + "-" + date2.Month + "-" + date2.Day + "' ;");

                MySqlCommand sqcon2 = new MySqlCommand(query2, con);

                MySqlDataAdapter ad = new MySqlDataAdapter(sqcon2);

                ad.Fill(dt2);
                try
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        txtServico.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");
                    }
                }
                catch (Exception)
                {

                    
                }
                

                string query3 = ("select sum(valorCusto) from tblCusto inner join tblServico on tblCusto.idServico=tblServico.idServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where idCliente = '" + id + "' and dataVenda between '" + date1.Year + "-" + date1.Month + "-" + date1.Day + "' and '" + date2.Year + "-" + date2.Month + "-" + date2.Day + "' ;");

                MySqlCommand sqcon3 = new MySqlCommand(query3, con);

                MySqlDataAdapter ada = new MySqlDataAdapter(sqcon3);

                ada.Fill(dt3);
                try
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        txtCusto.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");


                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Nenhuma venda realizada na data informada.");
                }
                

                double auxServi = Convert.ToDouble(txtServico.Text.Remove(0, 3));
                double auxCusto = Convert.ToDouble(txtCusto.Text.Remove(0, 3));

                txtFaturamento.Text = (auxServi - auxCusto).ToString("C");
                con.Close();
            }
            
        }

        private void formExibirCliente_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int id = Convert.ToInt32(textId.Text);



                string query2 = ("select sum(valorServico) from tblServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where statusPedido = 1 and idCliente  = '" + id + "' ;");

                MySqlCommand sqcon2 = new MySqlCommand(query2, con);

                MySqlDataAdapter ad = new MySqlDataAdapter(sqcon2);

                ad.Fill(dt2);
                foreach (DataRow row in dt2.Rows)
                {
                    txtServico.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");
                }

                string query3 = ("select sum(valorCusto) from tblCusto inner join tblServico on tblCusto.idServico=tblServico.idServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where idCliente = '" + id + "' ;");

                MySqlCommand sqcon3 = new MySqlCommand(query3, con);

                MySqlDataAdapter ada = new MySqlDataAdapter(sqcon3);

                ada.Fill(dt3);
                foreach (DataRow row in dt3.Rows)
                {
                    txtCusto.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");


                }

                double auxServi = Convert.ToDouble(txtServico.Text.Remove(0, 3));
                double auxCusto = Convert.ToDouble(txtCusto.Text.Remove(0, 3));

                txtFaturamento.Text = (auxServi - auxCusto).ToString("C");
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("O Cliente não tem pedidos em aberto, crie um para visualizar o faturamento.");
            }
            
        }
    }
}
