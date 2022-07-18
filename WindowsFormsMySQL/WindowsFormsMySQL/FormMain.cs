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
    public partial class FormMain : Form
    {
        FormInserirFormandos formInserirFormandos = new FormInserirFormandos();
        FormApagarFormandos formApagarFormandos = new FormApagarFormandos();
        FormAtualizarFormandos formAtualizarFormandos = new FormAtualizarFormandos();
        ListarFormandos formListarFormandos = new ListarFormandos();

        FormInserirNac formInserirNac = new FormInserirNac();
        FormApagarNac formApagarNac = new FormApagarNac();
        FormAtualizarNac formAtualizarNac = new FormAtualizarNac();
        FormListarNac formListarNac = new FormListarNac();
        public FormMain()
        {
            InitializeComponent();
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formInserirFormandos.IsDisposed)
            {
                formInserirFormandos = new FormInserirFormandos();
            }
            formInserirFormandos.MdiParent = this;
            formInserirFormandos.StartPosition = FormStartPosition.Manual;
            formInserirFormandos.Location = new Point((this.ClientSize.Width - formInserirFormandos.Width) / 2,
                (this.ClientSize.Height - formInserirFormandos.Height) / 3);
            formInserirFormandos.Show();
            formInserirFormandos.Activate();
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formApagarFormandos.IsDisposed)
            {
                formApagarFormandos = new FormApagarFormandos();
            }
            formApagarFormandos.MdiParent = this;
            formApagarFormandos.StartPosition = FormStartPosition.Manual;
            formApagarFormandos.Location = new Point((this.ClientSize.Width - formApagarFormandos.Width) / 2,
                (this.ClientSize.Height - formApagarFormandos.Height) / 3);
            formApagarFormandos.Show();
            formApagarFormandos.Activate();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formAtualizarFormandos.IsDisposed)
            {
                formAtualizarFormandos = new FormAtualizarFormandos();
            }
            formAtualizarFormandos.MdiParent = this;
            formAtualizarFormandos.StartPosition = FormStartPosition.Manual;
            formAtualizarFormandos.Location = new Point((this.ClientSize.Width - formAtualizarFormandos.Width) / 2,
                (this.ClientSize.Height - formAtualizarFormandos.Height) / 3);
            formAtualizarFormandos.Show();
            formAtualizarFormandos.Activate();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formListarFormandos.IsDisposed)
            {
                formListarFormandos = new ListarFormandos();
            }
            formListarFormandos.MdiParent = this;
            formListarFormandos.StartPosition = FormStartPosition.Manual;
            formListarFormandos.Location = new Point((this.ClientSize.Width - formListarFormandos.Width) / 2,
                (this.ClientSize.Height - formListarFormandos.Height) / 3);
            formListarFormandos.Show();
            formListarFormandos.Activate();
        }

        private void inserirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formInserirNac.IsDisposed)
            {
                formInserirNac = new FormInserirNac();
            }
            formInserirNac.MdiParent = this;
            formInserirNac.StartPosition = FormStartPosition.Manual;
            formInserirNac.Location = new Point((this.ClientSize.Width - formInserirNac.Width) / 2,
                (this.ClientSize.Height - formInserirNac.Height) / 3);
            formInserirNac.Show();
            formInserirNac.Activate();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formApagarNac.IsDisposed)
            {
                formApagarNac = new FormApagarNac();
            }
            formApagarNac.MdiParent = this;
            formApagarNac.StartPosition = FormStartPosition.Manual;
            formApagarNac.Location = new Point((this.ClientSize.Width - formApagarNac.Width) / 2,
                (this.ClientSize.Height - formApagarNac.Height) / 3);
            formApagarNac.Show();
            formApagarNac.Activate();
        }

        private void atualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formAtualizarNac.IsDisposed)
            {
                formAtualizarNac = new FormAtualizarNac();
            }
            formAtualizarNac.MdiParent = this;
            formAtualizarNac.StartPosition = FormStartPosition.Manual;
            formAtualizarNac.Location = new Point((this.ClientSize.Width - formAtualizarNac.Width) / 2,
                (this.ClientSize.Height - formAtualizarNac.Height) / 3);
            formAtualizarNac.Show();
            formAtualizarNac.Activate();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formListarNac.IsDisposed)
            {
                formListarNac = new FormListarNac();
            }
            formListarNac.MdiParent = this;
            formListarNac.StartPosition = FormStartPosition.Manual;
            formListarNac.Location = new Point((this.ClientSize.Width - formListarNac.Width) / 2,
                (this.ClientSize.Height - formListarNac.Height) / 3);
            formListarNac.Show();
            formListarNac.Activate();
        }
    }
}
