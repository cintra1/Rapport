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
    public partial class formListaPedidos : Form
    {
        public formListaPedidos()
        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            formExibirPedido frm = new formExibirPedido();
            frm.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formExibirPedido frm = new formExibirPedido();
            frm.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formExibirPedido frm = new formExibirPedido();
            frm.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formExibirPedido frm = new formExibirPedido();
            frm.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formExibirPedido frm = new formExibirPedido();
            frm.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formExibirPedido frm = new formExibirPedido();
            frm.Show();
            this.Visible = false;
        }

        private void formListaPedidos_Load(object sender, EventArgs e)
        {
            
            

        }

        MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
        MySqlCommand cmd;
        DataTable dt = new DataTable("tblPedido");
        MySqlDataAdapter adapter;
        DataSet ds;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            formExibirPedido frm = new formExibirPedido();
            frm.textId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.ShowDialog();
            this.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            if (txtProcurar.Text.Equals(""))
            {
                Pedido pedido = new Pedido();
                PedidoDAO pedidoDAO = new PedidoDAO();
                // GerarGrade();
                dt = pedidoDAO.listarPedido(pedido);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["idPedido"].HeaderText = "Código do Pedido";
                dataGridView1.Columns["idPedido"].Width = 127;
                dataGridView1.Columns["idPedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["idCliente"].HeaderText = "Código do Cliente";
                dataGridView1.Columns["idCliente"].Width = 130;
                dataGridView1.Columns["idCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["dataVenda"].HeaderText = "Data da Venda";
                dataGridView1.Columns["profissionalResponsavel"].HeaderText = "Profissional responsável";
            }
            else
            {
                try
                {
                    dv.RowFilter = string.Format("idPedido = {0}", txtProcurar.Text);
                    dataGridView1.DataSource = dv.ToTable();
                }
                catch (Exception)
                {

                    MessageBox.Show("Exiba todos pedidos primeiro.");
                }
                
            }
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
