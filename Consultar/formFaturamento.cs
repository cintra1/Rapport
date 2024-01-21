using Microsoft.Recognizers.Text.Number.Arabic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoDS.Consultar;
using TrabalhoDS.dao;
using TrabalhoDS.model;
using static System.Windows.Forms.DataFormats;

namespace TrabalhoDS
{
    public partial class formFaturamento : Form
    {
        public formFaturamento()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPedidos frm = new formPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formServicos frm = new formServicos();
            frm.Show();
            this.Visible = false;
        }

        private void listaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaClientes frm = new formListaClientes();
            frm.Show();
            this.Visible = false;
        }

        private void faturamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFaturamento frm = new formFaturamento();
            frm.Show();
            this.Visible = false;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
       
        DataSet ds;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        private void formFaturamento_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = ("select tblCliente.nome as 'Cliente',tblDetalhesPedido.statusPedido as 'Status',tblServico.nome as 'Serviço',tblPedido.dataVenda as 'Data da Venda',tblPedido.profissionalResponsavel as 'Profissional',tblServico.valorServico as 'Valor do serviço', tblCusto.valorCusto as 'Valor do custo' from tblCliente inner join tblPedido on tblCliente.idCliente=tblPedido.idCliente inner join tblDetalhesPedido on tblPedido.idPedido=tblDetalhesPedido.idPedido inner join tblServico on tblDetalhesPedido.idServico=tblServico.idServico inner join tblCusto on tblCusto.idServico=tblServico.idServico where statusPedido = 1");

            MySqlCommand sqcon = new MySqlCommand(query, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqcon);
            
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;


            string query2 = ("select sum(valorServico) from tblServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico where statusPedido = 1;");

            MySqlCommand sqcon2 = new MySqlCommand(query2,con);

            MySqlDataAdapter ad = new MySqlDataAdapter(sqcon2);
            
            ad.Fill(dt2);
            foreach(DataRow row in dt2.Rows)
            {
                txtServico.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");
                
                
            }

            string query3 = ("select sum(valorCusto) from tblCusto;");

            MySqlCommand sqcon3 = new MySqlCommand(query3, con);

            MySqlDataAdapter ada = new MySqlDataAdapter(sqcon3);

            ada.Fill(dt3);
            foreach (DataRow row in dt3.Rows)
            {
                txtCusto.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");


            }


            double auxServi = Convert.ToDouble(txtServico.Text.Remove(0,3));
            double auxCusto = Convert.ToDouble(txtCusto.Text.Remove(0, 3));

            txtFaturamento.Text = (auxServi - auxCusto).ToString("C");

            con.Close();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtDate.Text.Equals("  /  /") && txtDate2.Text.Equals("  /  /"))
                {
                    con.Open();
                    dt.Clear();
                    string query = ("select tblCliente.nome as 'Cliente',tblDetalhesPedido.statusPedido as 'Status',tblServico.nome as 'Serviço',tblPedido.dataVenda as 'Data da Venda',tblPedido.profissionalResponsavel as 'Profissional',tblServico.valorServico as 'Valor do serviço', tblCusto.valorCusto as 'Valor do custo' from tblCliente inner join tblPedido on tblCliente.idCliente=tblPedido.idCliente inner join tblDetalhesPedido on tblPedido.idPedido=tblDetalhesPedido.idPedido inner join tblServico on tblDetalhesPedido.idServico=tblServico.idServico inner join tblCusto on tblCusto.idServico=tblServico.idServico where statusPedido = 1");

                    MySqlCommand sqcon = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sqcon);

                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;


                    string query2 = ("select sum(valorServico) from tblServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico where statusPedido = 1;");

                    MySqlCommand sqcon2 = new MySqlCommand(query2, con);

                    MySqlDataAdapter ad = new MySqlDataAdapter(sqcon2);

                    ad.Fill(dt2);
                    foreach (DataRow row in dt2.Rows)
                    {
                        txtServico.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");


                    }

                    string query3 = ("select sum(valorCusto) from tblCusto;");

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
                else
                {
                    con.Open();
                    DateTime date1 = Convert.ToDateTime(txtDate.Text);
                    DateTime date2 = Convert.ToDateTime(txtDate2.Text);

                    string query = ("select tblCliente.nome as 'Cliente',tblDetalhesPedido.statusPedido as 'Status',tblServico.nome as 'Serviço',tblPedido.dataVenda as 'Data da Venda',tblPedido.profissionalResponsavel as 'Profissional',tblServico.valorServico as 'Valor do serviço', tblCusto.valorCusto as 'Valor do custo' from tblCliente inner join tblPedido on tblCliente.idCliente=tblPedido.idCliente inner join tblDetalhesPedido on tblPedido.idPedido=tblDetalhesPedido.idPedido inner join tblServico on tblDetalhesPedido.idServico=tblServico.idServico inner join tblCusto on tblCusto.idServico=tblServico.idServico where statusPedido = 1 and dataVenda between '" + date1.Year + "-" + date1.Month + "-" + date1.Day + "' and '" + date2.Year + "-" + date2.Month + "-" + date2.Day + "' ;");

                    MySqlCommand sqcon = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sqcon);

                    sqcon.ExecuteNonQuery();
                    dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    string query2 = ("select sum(valorServico) from tblServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where statusPedido = 1 and dataVenda between '" + date1.Year + "-" + date1.Month + "-" + date1.Day + "' and '" + date2.Year + "-" + date2.Month + "-" + date2.Day + "' ;");

                    MySqlCommand sqcon2 = new MySqlCommand(query2, con);

                    MySqlDataAdapter ad = new MySqlDataAdapter(sqcon2);

                    ad.Fill(dt2);
                    foreach (DataRow row in dt2.Rows)
                    {
                        txtServico.Text = Convert.ToDecimal(row[0].ToString()).ToString("C");


                    }

                    string query3 = ("select sum(valorCusto) from tblCusto inner join tblServico on tblCusto.idServico=tblServico.idServico inner join tblDetalhesPedido on tblServico.idServico=tblDetalhesPedido.idServico inner join tblPedido on tblDetalhesPedido.idPedido=tblPedido.idPedido where dataVenda between '" + date1.Year + "-" + date1.Month + "-" + date1.Day + "' and '" + date2.Year + "-" + date2.Month + "-" + date2.Day + "' ;");

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
            }
            catch (Exception ex)
             {

                MessageBox.Show("Você não informou uma das datas.");
            }
            
        }

        private void txtServico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
