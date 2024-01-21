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
    public partial class formExibirCusto : Form
    {
        public formExibirCusto()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Custo custo = new Custo();
            CustoDAO custoDAO = new CustoDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                custo.setIdCusto(int.Parse(textId.Text));

                custo.setValorCusto(double.Parse(textBox1.Text));
                custo.setDescricaoCusto(textBox3.Text);




                custoDAO.atualizar(custo);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Custo custo = new Custo();
            CustoDAO custoDAO = new CustoDAO();

            if (textId.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                try
                {
                    custo.setIdCusto(int.Parse(textId.Text));
                    custoDAO.excluir(custo);
                    formListaServicos frm = new formListaServicos();
                    frm.Show();
                    this.Visible = false;

                    
                }
                catch (Exception)
                {
                    throw;

                }
                

            }
        }

        private void formExibirCusto_Load(object sender, EventArgs e)
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

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
