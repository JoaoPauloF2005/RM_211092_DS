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
    public partial class FrmCategoria : Form
    {
        Categoria c;
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria form = new FrmCategoria();
            form.Show();
        }

        void LimpaControles()
        {
            txtIDCategoria.Clear();
            txtDescricao.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Categoria();
            {
                txtDescricao.Text = pesquisa;
            };
            dgvCategoria.DataSource = c.Consultar();
        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == String.Empty) return;

            c = new Categoria()
            {
                descricao = txtDescricao.Text,

            };
            c.Incluir();

            LimpaControles();
            carregarGrid("");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtIDCategoria.Text == String.Empty) return;

            c = new Categoria()
            {
                id = int.Parse(txtIDCategoria.Text),
                descricao = txtDescricao.Text,
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
            if (txtIDCategoria.Text == "") return;

            if (MessageBox.Show("Deseja excluir a marca?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Categoria()
                {
                    id = int.Parse(txtIDCategoria.Text)
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

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (dgvCategoria.RowCount > 0)
                {
                    txtIDCategoria.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
                    txtDescricao.Text = dgvCategoria.CurrentRow.Cells["descricao"].Value.ToString();
                }
            }
        }
    }
}