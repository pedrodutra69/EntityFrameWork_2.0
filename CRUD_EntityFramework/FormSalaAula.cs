using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EntityFramework
{
    public partial class FormSalaAula : Form
    {
        public FormSalaAula()
        {
            InitializeComponent();
        }

        

        public void AtualizaGrid()
        {
            using (var tb = new Contexto())
            {
                grid.DataSource = null;
                grid.DataSource = tb.ObjetoSalaAula.ToList();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                tb.ObjetoSalaAula.Add(new SalaAula { professor = txtProfessor.Text, sala = txtSala.Text , curso = txtCurso.Text , data = txtData.Text});
                tb.SaveChanges();
            }

            AtualizaGrid();
            txtProfessor.Clear();
            txtSala.Clear();
            txtCurso.Clear();
            txtData.Clear();
            MessageBox.Show("Incluido com sucesso", "Inclusão");
        }




        private void btnAlterar_Click(object sender, EventArgs e)
        {
            {
                using (var tb = new Contexto())
                {
                    try
                    {
                        var objeto = tb.ObjetoSalaAula.Find(Convert.ToInt32(txtID.Text));
                        objeto.professor = txtProfessor.Text;
                        objeto.sala = txtSala.Text;
                        objeto.curso = txtCurso.Text;
                        objeto.data = txtData.Text;

                        tb.Entry(objeto).State = EntityState.Modified;
                        tb.SaveChanges();
                        MessageBox.Show("ALTERAÇÃO REALIZADA COM SUCESSO", "AVISO");
                        AtualizaGrid();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }


                }
            }
        }

        private void gri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtProfessor.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtSala.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtCurso.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtData.Text = grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void FormSalaAula_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try
                {
                    var objeto = tb.ObjetoSalaAula.Find(Convert.ToInt32(txtID.Text));
                    tb.ObjetoSalaAula.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Excluido com Sucesso", "Aviso");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




            }
        }
    }
}
