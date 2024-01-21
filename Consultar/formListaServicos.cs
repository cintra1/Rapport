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
    public partial class formListaServicos : Form
    {
        public formListaServicos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            if (txtPesquisar.Text == "")
            {
                Servico servico = new Servico();
                ServicoDAO servicoDAO = new ServicoDAO();

                dt = servicoDAO.listarServico(servico);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["idServico"].HeaderText = "Código";
                dataGridView1.Columns["idServico"].Width = 55;
                dataGridView1.Columns["idServico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["nome"].HeaderText = "Nome";
                dataGridView1.Columns["valorServico"].HeaderText = "Valor do Serviço";
            }
            else
            {
                DataView dv = dt.DefaultView;
                try
                {
                    dv.RowFilter = string.Format("nome like '%{0}%'", txtPesquisar.Text);
                    dataGridView1.DataSource = dv.ToTable();
                }
                catch (Exception)
                {

                    MessageBox.Show("Exiba todos serviços primeiro.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formExibirServico frm = new formExibirServico();
            frm.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formExibirServico frm = new formExibirServico();
            frm.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formExibirServico frm = new formExibirServico();
            frm.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formExibirServico frm = new formExibirServico();
            frm.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formExibirServico frm = new formExibirServico();
            frm.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
        MySqlCommand cmd;
        DataTable dt = new DataTable("tblServico");
        MySqlDataAdapter adapter;
        DataSet ds;

        private void formListaServicos_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            formExibirServico frm = new formExibirServico();
            frm.textId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
            frm.ShowDialog();
            this.Visible = false;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
