using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoDS.model;

namespace TrabalhoDS
{
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            String mensagem = controle.cadastrar(textBox1.Text, textBox2.Text, textBox3.Text);
            if (controle.tem)
            {
                MessageBox.Show(mensagem,"Cadastro",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Visible = false;
                Form1 frm = new Form1();
                frm.Show();
                
            }
            else
            {
                MessageBox.Show(controle.mensagem);
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Visible = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Usuario")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Usuario";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Senha";
                textBox2.UseSystemPasswordChar = false;
                textBox2.ForeColor = Color.Silver;

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Senha")
            {
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;
                textBox2.ForeColor = Color.Black;
                
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Confirmar Senha")
            {

                textBox3.Text = "";
                textBox3.UseSystemPasswordChar = true;

                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Confirmar Senha";
                textBox3.UseSystemPasswordChar = false;
                textBox3.ForeColor = Color.Silver;
                
            }
        }
    }
}
