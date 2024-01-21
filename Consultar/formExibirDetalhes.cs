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
    public partial class formExibirDetalhes : Form
    {
        public formExibirDetalhes()
        {
            InitializeComponent();
        }

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //mudar o bit
            DetalhesPedido detalhesPedido = new DetalhesPedido();
            DetalhesPedDAO detalhesPedDAO = new DetalhesPedDAO();

            if (txtAtivo.Text.Equals("Ativo"))
            {
                detalhesPedido.setIdPedido(Convert.ToInt32(txtIdPedido.Text));
                detalhesPedido.setIdServico(Convert.ToInt32(txtIdServico.Text));
                detalhesPedido.setStatusPedido(0);
                detalhesPedDAO.atualizar(detalhesPedido);
                txtAtivo.Text = "Inativo";
            }
            else
            {
                detalhesPedido.setIdPedido(Convert.ToInt32(txtIdPedido.Text));
                detalhesPedido.setIdServico(Convert.ToInt32(txtIdServico.Text));
                detalhesPedido.setStatusPedido(1);
                detalhesPedDAO.atualizar(detalhesPedido);
                txtAtivo.Text = "Ativo";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void formExibirDetalhes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DetalhesPedido detalhesPedido = new DetalhesPedido();
            DetalhesPedDAO detalhesPedDAO = new DetalhesPedDAO();

            if (txtIdPedido.Text.Equals(""))
            {
                MessageBox.Show("Valor Invalido.");
            }
            else
            {
                try
                {
                    detalhesPedido.setIdPedido(int.Parse(txtIdPedido.Text));
                    detalhesPedido.setIdServico(int.Parse(txtIdServico.Text));
                    detalhesPedDAO.excluir(detalhesPedido);
                }
                catch (Exception)
                {
                    throw;

                }

                this.Visible = false;
                
            }
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
            
        }
    }
}
