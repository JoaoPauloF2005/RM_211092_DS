using System;
using System.Windows.Forms;
using Org.BouncyCastle.Tls;
using RM_211092.Models;

namespace RM_211092.Views
{
    public partial class FrmCidade : Form
    {
        Cidade c;
        public FrmCidade()
        {
            InitializeComponent();
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidade form =  new FrmCidade();
            form.Show();
        }
       void LimpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisa.Clear();    
        }
    
        void carregarGrid(string pesquisa)
        {
            c = new Cidade();
            {
                txtNome.Text = pesquisa;
            };
            dgvCidades.DataSource = c.Consultar();
        }
         

        private void btnIncluir_Click_1(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            c = new Cidade()
            {
                nome = txtNome.Text,
                uf = txtUF.Text,
            };
            c.Incluir();

            LimpaControles();
            carregarGrid("");
        }

        private void dgvCidade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();
            }
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Alterar();

            LimpaControles();
            carregarGrid("");
        }
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();

                LimpaControles();
                carregarGrid("");
            }
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCidade_Load(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

    }
}
