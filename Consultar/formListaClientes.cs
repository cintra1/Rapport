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
using TrabalhoDS.Consultar;
using TrabalhoDS.dao;
using TrabalhoDS.model;

namespace TrabalhoDS
{
    public partial class formListaClientes : Form
    {
        public formListaClientes()
        {
            InitializeComponent();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPedidos frm = new formPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
            frm.Show();
            this.Visible = false;
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        private void faturamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFaturamento frm = new formFaturamento();
            frm.Show();
            this.Visible = false;
        }

        private void listaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaClientes frm = new formListaClientes();
            frm.Show();
            this.Visible = false;
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formServicos frm = new formServicos();
            frm.Show();
            this.Visible = false;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
            frm.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
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

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            formPedidos frm = new formPedidos();
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

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            formFaturamento frm = new formFaturamento();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            TelaPrincipal frm = new TelaPrincipal();
            frm.Show();
            this.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
            frm.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
            frm.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
            frm.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
            frm.Show();
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (txtProcurar.Text == "")
            {
                Cliente cliente = new Cliente();
                ClienteDAO clienteDAO = new ClienteDAO();
                // GerarGrade();
                dt = clienteDAO.listarClientes(cliente);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["idCliente"].HeaderText = "Código";
                dataGridView1.Columns["idCliente"].Width = 55;
                dataGridView1.Columns["idCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                dataGridView1.Columns["nome"].HeaderText = "Nome";
                dataGridView1.Columns["cnpj"].HeaderText = "CNPJ";
                dataGridView1.Columns["telefone"].HeaderText = "Telefone";
                dataGridView1.Columns["email"].HeaderText = "E-mail";
                dataGridView1.Columns["endereco"].HeaderText = "Endereço";
            }
            else
            {
                DataView dv = dt.DefaultView;
                try
                {
                    dv.RowFilter = string.Format("nome like '%{0}%'", txtProcurar.Text);
                    dataGridView1.DataSource = dv.ToTable();
                }
                catch (Exception)
                {

                    MessageBox.Show("Exiba todos clientes primeiro.");
                }
                
            }
        }

        /*public void BuscarProduto()
        {
            foreach(ListViewItem item in listView1.Items){
                if(txtProcurar.Text.ToLower() == item.SubItems[1].Text.ToLower())
                {
                    listView1.Focus();
                    item.Selected = true;
                    listView1.TopItem = item;
                    break;
                }

            }
        }*/

       /* public void GerarGrade()
        {
            listView1.Columns.Add("Código", 50).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Nome", 150).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Telefone", 120).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("E-mail", 175).TextAlign = HorizontalAlignment.Center;
            listView1.View = View.Details;

            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            con.Open();
            cmd = new MySqlCommand("select * from tblCliente", con);
            adapter = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds, "testTable");
            con.Close();

            dt = ds.Tables["testTable"];
            int i;
            for(i=0; i<dt.Rows.Count - 1; i++)
            {
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                
            }
        }*/

        private void formListaClientes_Load(object sender, EventArgs e)
        {
            




        }

        MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
        MySqlCommand cmd;
        DataTable dt = new DataTable("tblCliente");
        MySqlDataAdapter adapter;
        DataSet ds;


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            formExibirCliente frm = new formExibirCliente();
            frm.textId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm.ShowDialog();
            this.Visible = false;

        }
    }
}
