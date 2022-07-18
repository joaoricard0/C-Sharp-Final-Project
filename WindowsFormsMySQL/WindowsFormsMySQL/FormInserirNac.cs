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
    public partial class FormInserirNac : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormInserirNac()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ligacao.InsertNacionalidade( txtISO.Text, txtNac.Text);
            MessageBox.Show("Nacionalidade inserida com sucesso!");
            Limpar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Limpar()
        {
            txtISO.Text = "";
            txtNac.Text = "";
        }

    }


}
