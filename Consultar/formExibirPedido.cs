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
    public partial class formExibirPedido : Form
    {
        public formExibirPedido()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formListaPedidos frm = new formListaPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            TelaPrincipal frm = new TelaPrincipal();
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

        MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
        MySqlCommand cmd;
        DataTable dt = new DataTable("tblDetalhesPedido");
        MySqlDataAdapter adapter;
        DataSet ds;

        private void formExibirPedido_Load(object sender, EventArgs e)
        {
            try
            {
                DetalhesPedido detalhesPedido = new DetalhesPedido();
                DetalhesPedDAO detalhesPedDAO = new DetalhesPedDAO();
                // GerarGrade();
                detalhesPedido.setIdPedido(Convert.ToInt32(textId.Text));
                dt = detalhesPedDAO.listarDetalhesPedido(detalhesPedido);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["idServico"].HeaderText = "Código do Servico";
                dataGridView1.Columns["statusPedido"].HeaderText = "Status do Pedidos";

                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("idPedido = {0}", textId.Text);
                dataGridView1.DataSource = dv.ToTable();
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            formExibirDetalhes frm = new formExibirDetalhes();
            
            frm.txtIdPedido.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtIdServico.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();


            if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("1"))
            {
                frm.txtAtivo.Text = "Ativo";

            }
            else
            {
                frm.txtAtivo.Text = "Inativo";
            }
            frm.ShowDialog();

            try
            {
                DetalhesPedido detalhesPedido = new DetalhesPedido();
                DetalhesPedDAO detalhesPedDAO = new DetalhesPedDAO();
                // GerarGrade();
                detalhesPedido.setIdPedido(Convert.ToInt32(textId.Text));
                dt = detalhesPedDAO.listarDetalhesPedido(detalhesPedido);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["idServico"].HeaderText = "Código do Servico";
                dataGridView1.Columns["statusPedido"].HeaderText = "Status do Pedidos";

                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("idPedido = {0}", textId.Text);
                dataGridView1.DataSource = dv.ToTable();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            PedidoDAO pedidoDAO = new PedidoDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                pedido.setIdPedido(int.Parse(textId.Text));
                pedido.setIdCliente(int.Parse(textBox1.Text));
                pedido.setProfissionalResponsavel(textBox4.Text);
                pedido.setDataVenda(Convert.ToDateTime(textBox2.Text));




                pedidoDAO.atualizar(pedido);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            PedidoDAO pedidoDAO = new PedidoDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                try
                {
                    pedido.setIdPedido(int.Parse(textId.Text));
                    pedidoDAO.excluir(pedido);
                }
                catch (Exception)
                {
                    throw;

                }

                this.Visible = false;
                formListaPedidos frm = new formListaPedidos();
                frm.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
