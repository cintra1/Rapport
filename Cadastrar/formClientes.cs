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
using TrabalhoDS;
using TrabalhoDS.model;
using TrabalhoDS.dao;

namespace TrabalhoDS.Consultar
{
    public partial class formClientes : Form
    {
        public formClientes()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formServicos frm = new formServicos();
            frm.Show();
            this.Visible = false;
        }

        private void vendasToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void formClientes_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaPrincipal frm = new TelaPrincipal();
            frm.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteDAO clienteDAO = new ClienteDAO();

            cliente.setNome(txtNome.Text);
            cliente.setCnpj(txtCnpj.Text);
            cliente.setTelefone(txtTelefone.Text);
            cliente.setEmail(txtEmail.Text);
            cliente.setEndereco(txtEndereco.Text);


            clienteDAO.cadastrar(cliente);

            txtNome.Clear();
            txtCnpj.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listaDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaPedidos frm = new formListaPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void listaDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListaServicos frm = new formListaServicos();
            frm.Show();
            this.Visible = false;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
