using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EntityFramework
{
    public partial class FormSistema : Form
    {
        public FormSistema()
        {
            InitializeComponent();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormAgenda = new FormAgenda();
            FormAgenda.Show();
        }

        private void salaAulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormSalaAula = new FormSalaAula();
            FormSalaAula.Show();
        }
    }
}
