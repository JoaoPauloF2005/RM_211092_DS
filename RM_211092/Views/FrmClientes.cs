﻿using System;
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
    public partial class FrmClientes : Form
    {
        Cidade ci;
        Cliente cl;
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.Show();
        }

        void LimpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            cboCidades.SelectedIndex = -1;
            txtUF.Clear();
            mskCPF.Clear();
            txtRenda.Clear();
            dtpDataNasc.Value = DateTime.Now;
            picFoto.ImageLocation = "";
            chkVenda.Checked = false;
        }

        void carregarGrid(string pesquisa)
        {
            cl = new Cliente();
            {
                txtNome.Text = pesquisa;
            };
            dgvClientes.DataSource = cl.Consultar();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ci = new Cidade();
            cboCidades.DataSource = ci.Consultar();
            cboCidades.DisplayMember = "nome";
            cboCidades.ValueMember = "id";

            LimpaControles();
            carregarGrid("");

            dgvClientes.Columns["idCidade"].Visible = false;
            dgvClientes.Columns["foto"].Visible = false;

        }
        private void cboCidades_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cboCidades.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCidades.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }

        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;


        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            cl = new Cliente()
            {
                nome = txtNome.Text,
                idCidade = (int)cboCidades.SelectedValue,
                dataNasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked
            };
            cl.Incluir();

            LimpaControles();
            carregarGrid("");
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                txtID.Text = dgvClientes.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvClientes.CurrentRow.Cells["nome"].Value.ToString();
                cboCidades.Text = dgvClientes.CurrentRow.Cells["cidade"].Value.ToString();
                txtUF.Text = dgvClientes.CurrentRow.Cells["uf"].Value.ToString();
                chkVenda.Checked = (bool)dgvClientes.CurrentRow.Cells["venda"].Value;
                mskCPF.Text = dgvClientes.CurrentRow.Cells["cpf"].Value.ToString();
                dtpDataNasc.Text = dgvClientes.CurrentRow.Cells["dataNasc"].Value.ToString();
                txtRenda.Text = dgvClientes.CurrentRow.Cells["renda"].Value.ToString();
                picFoto.ImageLocation = dgvClientes.CurrentRow.Cells["foto"].Value.ToString();

            }
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            cl = new Cliente()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                idCidade = (int)cboCidades.SelectedValue,
                dataNasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked
            };
            cl.Alterar();

            LimpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if(MessageBox.Show("Deseja excluir o cliente?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cl = new Cliente()
                {
                    id = int.Parse(txtID.Text)
                };
                cl.Excluir();

                LimpaControles();
                carregarGrid("");

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
