using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RM_211092.Views;

namespace RM_211092
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }

        

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidade form = new FrmCidade();
            form.Show();
        }

        

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarca form = new FrmMarca();
            form.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria form = new FrmCategoria();
            form.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto form = new FrmProduto();
            form.Show();
        }
    }
}
