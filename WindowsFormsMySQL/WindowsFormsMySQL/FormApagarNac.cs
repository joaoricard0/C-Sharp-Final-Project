using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsMySQL
{
    public partial class FormApagarNac : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormApagarNac()
        {
            InitializeComponent();
        }

        private void FormApagarNac_Load(object sender, EventArgs e)
        {

            ligacao.ComboBoxNac(ref comboBox1);
            txtISO.ReadOnly = true;
            txtNac.ReadOnly = true;

            btnEliminar.Enabled = false;

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
            btnEliminar.Enabled = true;
            groupBox1.Enabled = true;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnEliminar.Enabled = false;
            comboBox1.Focus();
            Limpar();
        }

        private void Limpar()
        {
            txtISO.Text = "";
            txtNac.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(comboBox1.SelectedItem.ToString().Split(' ')[0]);

            DialogResult resp;

            resp = MessageBox.Show("Deseja apagar o registo?", "Eliminação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                if (ligacao.DeleteNacionalidade((id).ToString()))
                {
                    MessageBox.Show("Apagou com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao apagar!");
                }
            }
            groupBox3.Enabled = true;
            btnEliminar.Enabled = false;
            comboBox1.Focus();

            Limpar();
        }
    }
}
