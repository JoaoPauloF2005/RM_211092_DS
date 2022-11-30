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
            mr = new Produto();
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
            c = new Produto();
            cboCategoria.DataSource = c.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";

            LimpaControles();
            carregarGrid("");

            dgvProduto.Columns["idCategoria"].Visible = false;
            dgvProduto.Columns["foto"].Visible = false;
        }
    }
}
