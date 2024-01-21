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
    public partial class formExibirServico : Form
    {
        public formExibirServico()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formListaServicos frm = new formListaServicos();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Servico servico = new Servico();
            ServicoDAO servicoDAO = new ServicoDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                servico.setIdServico(int.Parse(textId.Text));

                servico.setNome(textBox1.Text);
                servico.setValorServico(double.Parse(textBox2.Text));
                



                servicoDAO.atualizar(servico);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Servico servico = new Servico();
            ServicoDAO servicoDAO = new ServicoDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                try
                {
                    servico.setIdServico(int.Parse(textId.Text));
                    servicoDAO.excluir(servico);
                }
                catch (Exception)
                {
                    throw;

                }

                this.Visible = false;
                formListaServicos frm = new formListaServicos();
                frm.Show();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        MySqlConnection con = new MySqlConnection(@"Server = localhost; DataBase = dbControleDeGastos; UId = root; Pwd = 12345");
        MySqlCommand cmd;
        DataTable dt = new DataTable("tblCusto");
        MySqlDataAdapter adapter;
        DataSet ds;

        private void formExibirServico_Load(object sender, EventArgs e)
        {
            try
            {
                Custo custo = new Custo();
                CustoDAO custoDAO = new CustoDAO();

                dt = custoDAO.listarCusto(custo);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["idCusto"].HeaderText = "Código do Custo";
                dataGridView1.Columns["idCusto"].Width = 120;
                dataGridView1.Columns["idCusto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["idServico"].HeaderText = "Código do Serviço";
                dataGridView1.Columns["idServico"].Width = 120;
                dataGridView1.Columns["idServico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["valorCusto"].HeaderText = "Valor do Custo";
                dataGridView1.Columns["descricaoCusto"].HeaderText = "Descrição do Custo";

                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("idServico = {0}", textId.Text);

                //dv.RowFilter = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idCusto"].Value.ToString());
                dataGridView1.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {

                throw;
            }
            


        }

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            formExibirCusto frm = new formExibirCusto();
            frm.textId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.textBox1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
            frm.ShowDialog();

            try
            {
                Custo custo = new Custo();
                CustoDAO custoDAO = new CustoDAO();

                dt = custoDAO.listarCusto(custo);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["idCusto"].HeaderText = "Código";
                dataGridView1.Columns["valorCusto"].HeaderText = "Valor do Custo";
                dataGridView1.Columns["descricaoCusto"].HeaderText = "Descrição do Custo";

                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("idServico = {0}", textId.Text);

                //dv.RowFilter = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idCusto"].Value.ToString());
                dataGridView1.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
