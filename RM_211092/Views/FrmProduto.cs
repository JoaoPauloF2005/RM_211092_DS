using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RM_211092.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


namespace RM_211092.Views
{
    public partial class FrmProduto : Form
    {
        Categoria ca;
        Marca m;
        Produto p;

        public FrmProduto()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtDescricao.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtValor.Clear();
            txtEstoque.Clear();
            picFoto.ImageLocation = "";
        }

        void carregarGrid(string pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };
            dvgProdutos.DataSource = p.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                estoque = decimal.Parse(txtEstoque.Text),
                valorVenda = decimal.Parse(txtValor.Text),
                foto = picFoto.ImageLocation,
            };
            p.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            p = new Produto()
            {
                id = int.Parse(txtID.Text),
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                estoque = decimal.Parse(txtEstoque.Text),
                valorVenda = decimal.Parse(txtValor.Text),
                foto = picFoto.ImageLocation,
            };
            p.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir o produto?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p = new Produto()
                {
                    id = int.Parse(txtID.Text)
                };
                p.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            ca = new Categoria();
            cboCategoria.DataSource = ca.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";

            m = new Marca();
            cboMarca.DataSource = m.Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";

            limpaControles();
            carregarGrid("");

            dvgProdutos.Columns["idCategoria"].Visible = false;
            dvgProdutos.Columns["idMarca"].Visible = false;
            dvgProdutos.Columns["foto"].Visible = false;
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCategoria.SelectedItem;

            }

            if (cboMarca.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboMarca.SelectedItem;

            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "C:/Users/Usuario/Desktop/211069/fotos/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void dvgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgProdutos.RowCount > 0)
            {
                txtID.Text = dvgProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dvgProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboCategoria.Text = dvgProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                cboMarca.Text = dvgProdutos.CurrentRow.Cells["marca"].Value.ToString();
                txtEstoque.Text = dvgProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                txtValor.Text = dvgProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();
                picFoto.ImageLocation = dvgProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }
}