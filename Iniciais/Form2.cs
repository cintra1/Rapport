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

namespace TrabalhoDS
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void faturamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formClientes frm = new formClientes();
            frm.Show();
            this.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            formServicos frm = new formServicos();
            frm.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formPedidos frm = new formPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formListaClientes frm = new formListaClientes();
            frm.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formFaturamento frm = new formFaturamento();
            frm.Show();
            this.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            formListaServicos frm = new formListaServicos();
            frm.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formFaturamento frm = new formFaturamento();
            frm.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            formListaPedidos frm = new formListaPedidos();
            frm.Show();
            this.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Visible = false;
        }
    }
}
