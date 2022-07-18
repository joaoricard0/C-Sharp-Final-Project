using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMySQL
{
    public partial class Form1 : Form
    {
        DBConnect ligacao = new DBConnect();
        FormInserirFormandos formInserirFormandos = new FormInserirFormandos();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DBConnect ligacao = new DBConnect();
            MessageBox.Show("Nº Total de Formandos: " + ligacao.Count());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ligacao.Insert();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ligacao.Insert2())
            {
                MessageBox.Show("Inseriu com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro na inserção!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ligacao.Update("12", "Rui Bento")) 
                {
                    MessageBox.Show("Atualizou com sucesso!");
                }
            else
                {
                    MessageBox.Show("Erro na atualização!");
                }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resp;

            resp = MessageBox.Show("Deseja apagar o registo?", "Eliminação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            { 
                if (ligacao.Delete("2"))
                {
                    MessageBox.Show("Apagou com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao apagar!");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (formInserirFormandos.IsDisposed)
            {
                formInserirFormandos = new FormInserirFormandos();
            }
            formInserirFormandos.Show();
            formInserirFormandos.Activate();
        }
    }
}
