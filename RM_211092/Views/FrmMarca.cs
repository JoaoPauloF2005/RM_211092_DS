using RM_211092.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM_211092.Views
{
    public partial class FrmMarca : Form
    {
        Marca c;
        public FrmMarca()
        {
            InitializeComponent();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarca form = new FrmMarca();
            form.Show();
        }

        void LimpaControles()
        {
            txtIDMarca.Clear();
            txtMarca.Clear();
            txtPesquisa.Clear();
        }
        void carregarGrid(string pesquisa)
        {
            c = new Marca();
            {
                txtMarca.Text = pesquisa;
            };
            dgvMarca.DataSource = c.Consultar();
        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            c = new Marca()
            {
                marca = txtMarca.Text,

            };
            c.Incluir();

            LimpaControles();
            carregarGrid("");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtIDMarca.Text == String.Empty) return;

            c = new Marca()
            {
                id = int.Parse(txtIDMarca.Text),
                marca = txtMarca.Text,
            };
            c.Alterar();

            LimpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIDMarca.Text == "") return;

            if (MessageBox.Show("Deseja excluir a marca?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Marca()
                {
                    id = int.Parse(txtIDMarca.Text)
                };
                c.Excluir();

                LimpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void dgvMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (dgvMarca.RowCount > 0)
                {
                    txtIDMarca.Text = dgvMarca.CurrentRow.Cells["id"].Value.ToString();
                    txtMarca.Text = dgvMarca.CurrentRow.Cells["marca"].Value.ToString();
                }
            }
        }
    }
}