using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EntityFramework
{
    public partial class FormAgenda : Form
    {
        public FormAgenda()
        {
            InitializeComponent();
        }

        private void cadtelefoneBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.cadtelefoneBindingSource.EndEdit();
           // this.tableAdapterManager.UpdateAll(this.cadagendaDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadagendaDataSet.cadtelefone'. Você pode movê-la ou removê-la conforme necessário.
            // this.cadtelefoneTableAdapter.Fill(this.cadagendaDataSet.cadtelefone);
            AtualizaGrid();

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                tb.ObjetoAgenda.Add(new Agenda { nome = txtNome.Text, telefone = txtTelefone.Text , CEP = txtCEP.Text});
                tb.SaveChanges();
            }

            
            txtNome.Clear();
            txtTelefone.Clear();
            txtCEP.Clear();
            MessageBox.Show("Incluido com sucesso", "Inclusão");
            AtualizaGrid();
        }


        public void AtualizaGrid()
        {
            using (var tb = new Contexto())
            {
                grid.DataSource = null;
                grid.DataSource = tb.ObjetoAgenda.ToList();
            }
        }



        private void btnAlterar_Click(object sender, EventArgs e)
        {
            {
                using (var tb = new Contexto())
                {
                    try
                    {
                        var objeto = tb.ObjetoAgenda.Find(Convert.ToInt32(txtID.Text));
                        objeto.nome = txtNome.Text;
                        objeto.telefone = txtTelefone.Text;
                        objeto.CEP = txtCEP.Text;

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

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtTelefone.Text = grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
                using (var tb = new Contexto())
                {
                    try
                    {
                        var objeto = tb.ObjetoAgenda.Find(Convert.ToInt32(txtID.Text));
                        tb.ObjetoAgenda.Remove(objeto);
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
