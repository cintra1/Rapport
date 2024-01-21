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
    public partial class formPedidos : Form
    {
        public formPedidos()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPedidos frm = new formPedidos();
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
            cmd.CommandText = "select * from tblCliente";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "idCliente";
            comboBox1.DisplayMember = "nome";

            comboBox1.SelectedIndex = -1;

            con.Close();
        }

        public void cb2()
        {
            MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
            try
            {
                con.Open();
                comboBox2.Items.Clear();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tblServico";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);

                comboBox2.DataSource = dt;
                comboBox2.ValueMember = "idServico";
                comboBox2.DisplayMember = "nome";

                comboBox2.SelectedIndex = -1;

                con.Close();
            }
            catch (MySqlException sqle)
            {
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }

            
        }

        public void cb3()
        {
            MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
            try
            {
                con.Open();

                comboBox3.Items.Clear();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tblPedido";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);

                comboBox3.DataSource = dt;
                comboBox3.ValueMember = "idPedido";
                comboBox3.DisplayMember = "idPedido";

                comboBox2.SelectedIndex = -1;

                con.Close();
            }
            catch (MySqlException sqle)
            {
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }

        }

        public void cb3Atualizar()
        {
            MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
            try
            {
                con.Open();

                
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tblPedido";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);

                comboBox3.DataSource = dt;
                comboBox3.ValueMember = "idPedido";
                comboBox3.DisplayMember = "idPedido";

                comboBox2.SelectedIndex = -1;

                con.Close();
            }
            catch (MySqlException sqle)
            {
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }

        }

        private void formPedidos_Load(object sender, EventArgs e)
        {
            cb();
            cb2();
            cb3();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Pedido pedido = new Pedido();
            PedidoDAO pedidoDAO = new PedidoDAO();

            pedido.setIdCliente(Convert.ToInt32(comboBox1.SelectedValue));
            pedido.setDataVenda(Convert.ToDateTime(txtDate.Text));
            pedido.setProfissionalResponsavel(txtProfissional.Text);


            pedidoDAO.cadastrar(pedido);


            txtDate.Clear();
            txtProfissional.Clear();
            cb3Atualizar();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalhesPedido detalhesPedido = new DetalhesPedido();
            DetalhesPedDAO detalhesPedDAO = new DetalhesPedDAO();

            detalhesPedido.setIdPedido(Convert.ToInt32(comboBox3.SelectedValue));
            detalhesPedido.setIdServico(Convert.ToInt32(comboBox2.SelectedValue));
            detalhesPedido.setStatusPedido(1);

            detalhesPedDAO.cadastrar(detalhesPedido);
        }
    }
}
