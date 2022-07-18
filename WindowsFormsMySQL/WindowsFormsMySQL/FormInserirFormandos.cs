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
    public partial class FormInserirFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormInserirFormandos()
        {
            InitializeComponent();
        }

        private void FormInserirFormandos_Load(object sender, EventArgs e)
        {
            NUID.Value = ligacao.MaxID() + 1;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                //MessageBox.Show("Podemos iniciar o processo de gravação");
                ligacao.InsertForm((NUID.Value).ToString(), txtNome.Text,
                    txtMorada.Text, mtxtContacto.Text, txtIBAN.Text, Genero(), DateTime.Parse(mtxtDataNasc.Text).ToString("yyyy-MM-dd"));
                MessageBox.Show("Formando inserido com sucesso!");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro na Inserção");
            }

        }

        private void Limpar()
        {
            NUID.Value = ligacao.MaxID() + 1;
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
            if (NUID.Value < 1)
            {
                MessageBox.Show("Erro no campo ID!");
                NUID.Focus();
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
