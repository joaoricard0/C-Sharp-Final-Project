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
    public partial class FormAtualizarNac : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormAtualizarNac()
        {
            InitializeComponent();
        }

        private void FormAtualizarNac_Load(object sender, EventArgs e)
        {
            ligacao.ComboBoxNac(ref comboBox1);
            txtISO.ReadOnly = true;
            txtNac.ReadOnly = true;

            btnAtualizar.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ligacao.ComboBoxNac(ref comboBox1);
            string[] lista;
            lista = comboBox1.SelectedItem.ToString().Split(' ');
            txtISO.Text = lista[2].ToString();
            txtNac.Text = lista[4].ToString();
            txtISO.ReadOnly = false;
            txtNac.ReadOnly = false;
            btnAtualizar.Enabled = true;
            groupBox1.Enabled = true;
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(comboBox1.SelectedItem.ToString().Split(' ')[0]);
            DialogResult resp;

            resp = MessageBox.Show("Deseja atualizar o registo?", "Atualização", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                if (ligacao.UpdateNacionalidade((id).ToString(), txtISO.Text,
                    txtNac.Text))
                {
                    MessageBox.Show("Atualizou com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar!");
                }
            }
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
            comboBox1.Focus();

            Limpar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
            comboBox1.Focus();
            Limpar();
        }

        private void Limpar()
        {
            txtISO.Text = "";
            txtNac.Text = "";
        }
    }
}
