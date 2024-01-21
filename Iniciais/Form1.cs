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
    public partial class Form1 : Form
    {
        String usuario;
        String senha;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(textBox1.Text, textBox2.Text);
            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show("Logado com sucesso!", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TelaPrincipal frm = new TelaPrincipal();
                    frm.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                }

                /*if ((textBox1.Text == usuario) &&
                    (textBox2.Text == senha))
                    {
                    TelaPrincipal frm = new TelaPrincipal();
                    frm.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos");
                }*/
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cadastrar frm = new Cadastrar();
            frm.Show();
            this.Visible = false;


            /*usuario = textBox1.Text;
             senha = textBox2.Text;
             MessageBox.Show("Usuário Cadastrado!");
             textBox1.Clear();
             textBox2.Clear();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Senha")
            {
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;
                textBox2.ForeColor = Color.Black;
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
