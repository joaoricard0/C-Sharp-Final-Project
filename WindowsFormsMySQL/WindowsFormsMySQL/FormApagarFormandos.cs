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
    public partial class FormApagarFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormApagarFormandos()
        {
            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", morada = "", contacto = "", iban = "", data_nascimento = "";
            char genero = ' ';

            if (ligacao.SearchForm(nuID.Value.ToString(), ref nome, ref morada,
                ref contacto, ref iban, ref genero, ref data_nascimento))
            {
                txtNome.Text = nome;
                txtMorada.Text = morada;
                mtxtContacto.Text = contacto;
                txtIBAN.Text = iban;
                if (genero == 'F')
                {
                    rbFeminino.Checked = true;
                }
                else if (genero == 'M')
                {
                    rbMasculino.Checked = true;
                }
                else if (genero == 'O')
                {
                    rbOutro.Checked = true;
                }
                mtxtDataNasc.Text = data_nascimento;
                groupBox3.Enabled = false;
                btnEliminar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
            }

        }

        private void FormApagarFormandos_Load(object sender, EventArgs e)
        {
            txtNome.ReadOnly = true;
            txtMorada.ReadOnly = true;
            mtxtContacto.ReadOnly = true;
            txtIBAN.ReadOnly = true;
            rbFeminino.Enabled = false;
            rbMasculino.Enabled = false;
            rbOutro.Enabled = false;
            mtxtDataNasc.ReadOnly = true;

            btnEliminar.Enabled = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnEliminar.Enabled = false;
            nuID.Focus();

            Limpar();
        }

        private void Limpar()
        {
            nuID.Value = 0;
            txtNome.Text = "";
            txtMorada.Text = "";
            mtxtContacto.Clear();
            txtIBAN.Clear();
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;
            mtxtDataNasc.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = nuID.Text;
            DialogResult resp;

            resp = MessageBox.Show("Deseja apagar o registo?", "Eliminação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                if (ligacao.DeleteForm(id))
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
            nuID.Focus();

            Limpar();
        }
    }
}
