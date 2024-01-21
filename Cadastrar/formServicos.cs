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
    public partial class formServicos : Form
    {
        public formServicos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaClientes frm = new formListaClientes();
            frm.Show();
            this.Visible = false;
        }

        private void cadastrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formServicos frm = new formServicos();
            frm.Show();
            this.Visible = false;
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPedidos frm = new formPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void faturamentoToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            formListaClientes frm = new formListaClientes();
            frm.Show();
            this.Visible = false;
        }

        private void listaDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaPedidos frm = new formListaPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            formServicos frm = new formServicos();
            frm.Show();
            this.Visible = false;
        }

        private void listaDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaServicos frm = new formListaServicos();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Servico servico = new Servico();
            ServicoDAO servicoDAO = new ServicoDAO();

            servico.setNome(txtNome.Text);
            servico.setValorServico(double.Parse(txtValor.Text));
           
            servicoDAO.cadastrar(servico);

            txtNome.Clear();
            txtValor.Clear();
            cbAtualizar();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void cb()
        {
            MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
            try
            {
                con.Open();
            }
            catch (MySqlException sqle)
            {
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }

            comboBox1.Items.Clear();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblServico";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "idServico";
            comboBox1.DisplayMember = "nome";

            comboBox1.SelectedIndex = -1;

            con.Close();
        }

        public void cbAtualizar()
        {
            MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
            try
            {
                con.Open();
            }
            catch (MySqlException sqle)
            {
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }

            
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblServico";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "idServico";
            comboBox1.DisplayMember = "nome";

            comboBox1.SelectedIndex = -1;

            con.Close();
        }
        private void formServicos_Load(object sender, EventArgs e)
        {
            cb();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Custo custo = new Custo();
            CustoDAO custoDAO = new CustoDAO();

            custo.setIdServico(Convert.ToInt32(comboBox1.SelectedValue));
            custo.setValorCusto(double.Parse(txtValorCusto.Text));
            custo.setDescricaoCusto(txtDescricao.Text);


            custoDAO.cadastrar(custo);

           
            txtValorCusto.Clear();
            txtDescricao.Clear();
        }
    }
}
