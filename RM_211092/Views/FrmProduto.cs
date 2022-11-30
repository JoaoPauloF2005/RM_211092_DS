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
        Categoria c;
        Marca mr;
        Produto p;
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto form = new FrmProduto();
            form.Show();
        }

        void LimpaControles()
        {
            txtIDProduto.Clear();
            txtDescricao.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtValorVenda.Clear();
            txtEstoque.Clear();
            picFotoProduto.ImageLocation = "";
        }

        void carregarGrid(string pesquisa)
        {
            p = new Produto();
            {
                txtDescricao.Text = pesquisa;
            };
            dgvProduto.DataSource = mr.Consultar();
        }

        private void DgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            p = new Produto();
            cboCategoria.DataSource = c.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";
            cboMarca.DataSource = mr.Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";

            LimpaControles();
            carregarGrid("");

            dgvProduto.Columns["idCategoria"].Visible = false;
            dgvProduto.Columns["idMarca"].Visible = false;
            dgvProduto.Columns["foto"].Visible = false;
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCategoria.SelectedItem;
            }
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboMarca.SelectedItem;
            }
        }

        private void picFotoProduto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFotoProduto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                valorVenda = decimal.Parse(txtValorVenda.Text,
                Estoque = decimal.Parse(txtEstoque.Text))
            };
            p.Incluir();

            LimpaControles();
            carregarGrid("");
        }
    }
}
