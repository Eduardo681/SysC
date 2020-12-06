using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocios;

namespace CamadaDesign
{
 
    public partial class FormCategoria : Form
    {
        //variaveis
        private bool novo = false;
        private bool editar = false;
        //construtor
        public FormCategoria()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome da categoria");
            this.ttMensagem.SetToolTip(this.txtNome, "Insira a descrição da categoria");
        }

        private void MensagemOk (string msg)
        {
            MessageBox.Show(msg, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensagemErro(string msg)
        {
            MessageBox.Show(msg, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpar()
        {
            this.txtNome.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtIdCategoria.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
        }

        private void Botoes()
        {
            if (this.novo || this.editar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            } else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void ocultarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            //this.dataLista.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataLista.DataSource = NCategoria.Mostrar();
            this.ocultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);

        }

        private void BuscarNome()
        {
            this.dataLista.DataSource = NCategoria.BuscarNome(this.txtBuscar.Text);
            this.ocultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }
        private void FormCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botoes();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }
    }
}
