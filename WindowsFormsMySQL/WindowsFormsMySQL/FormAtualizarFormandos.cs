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
    public partial class FormAtualizarFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormAtualizarFormandos()
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
                btnAtualizar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
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
        bool VerificarCampos()
        {
            if (nuID.Value < 1)
            {
                MessageBox.Show("Erro no campo ID!");
                nuID.Focus();
                return false;
            }
            txtNome.Text = Geral.TirarEspacos(txtNome.Text);
            if (txtNome.Text.Length <= 2)
            {
                MessageBox.Show("Erro no campo Nome!");
                txtNome.Focus();
                return false;
            }
            txtMorada.Text = Geral.TirarEspacos(txtMorada.Text);
            if (txtMorada.Text.Length <= 3)
            {
                MessageBox.Show("Erro no campo Morada!");
                txtMorada.Focus();
                return false;
            }
            mtxtContacto.Text = Geral.TirarEspacos(mtxtContacto.Text);
            if (mtxtContacto.Text.Length != 9)
            {
                MessageBox.Show("Erro no campo Contacto!");
                mtxtContacto.Focus();
                return false;
            }
            txtIBAN.Text = Geral.TirarEspacos(txtIBAN.Text);
            if (txtIBAN.Text.Length < 25)
            {
                MessageBox.Show("Erro no campo IBAN!");
                txtIBAN.Focus();
                return false;
            }

            if (Genero() == 'T')
            {
                MessageBox.Show("Erro no campo genero!");
                rbFeminino.Focus();
                return false;
            }

            if (mtxtDataNasc.Text.Length != 10 || Geral.CheckDate(mtxtDataNasc.Text) == false)
            {
                MessageBox.Show("Erro no campo Data de Nascimento!");
                mtxtDataNasc.Focus();
                return false;
            }

            return true;
        }

        private char Genero()
        {
            char genero = 'T';

            if (rbFeminino.Checked) { genero = 'F'; }
            else if (rbMasculino.Checked) { genero = 'M'; }
            else if (rbOutro.Checked) { genero = 'O'; }
            return genero;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
             ligacao.UpdateForm((nuID.Value).ToString(), txtNome.Text,
                    txtMorada.Text, mtxtContacto.Text, txtIBAN.Text, Genero(), DateTime.Parse(mtxtDataNasc.Text).ToString("yyyy-MM-dd"));
                MessageBox.Show("Atualizou com sucesso!");
            }
            else
            {
                    MessageBox.Show("Erro na atualização!");
            }
            
                
        }
    }
}
