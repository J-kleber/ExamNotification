using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamNotification.Controller.Controladoras;
using ExamNotification.Data;


namespace ExamNotification.View
{
    public partial class frmEvento : Form
    {
        private bool alterar = false;
        public frmEvento()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            alterar = false;
            enableCampos(true);
            enableBotoes(false);
            btnSalvar.Enabled = true;
            limparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool operacaoConcluida = false;
            if (validaCampos())
            {

                ControlEvento _controladora = new ControlEvento();
                ProvasTrabalhos oEvento = new ProvasTrabalhos();
                oEvento.ID = int.Parse(txtCodigo.Text);
                oEvento.Nome = txtNome.Text;
                oEvento.Descricao = txtDescricao.Text;
                oEvento.Id_disciplina = int.Parse(cmbDisciplina.SelectedValue.ToString());
                oEvento.Data_aviso = DateTime.Parse(dtpDataInicial.Value.ToShortDateString());
                oEvento.Data_final = DateTime.Parse(dtpDataFinal.Value.ToShortDateString());

                if (!alterar)
                {
                    if (_controladora.SelecionarPK(int.Parse(txtCodigo.Text)) == null)
                    {
                        _controladora.Incluir(oEvento);
                        operacaoConcluida = true;
                    }
                    else
                    {
                        txtCodigo_Leave(this, null);
                    }
                }
                else
                {
                    _controladora.Alterar(oEvento);
                    operacaoConcluida = true;
                }
                if (operacaoConcluida)
                {
                    limparCampos();
                    enableCampos(false);
                    enableBotoes(false);
                    alterar = false;
                    carregaGrid();
                    MessageBox.Show("Salvo com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alterar = true;
            enableCampos(true);
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string excluir = MessageBox.Show("Deseja Realmente Excluir este registro? ", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString();
            if (excluir == "OK")
            {
                ControlEvento _controladora = new ControlEvento();
                ProvasTrabalhos oEvento = new ProvasTrabalhos();

                oEvento.ID = int.Parse(txtCodigo.Text);
                oEvento.Nome = txtNome.Text;
                oEvento.Descricao = txtDescricao.Text;
                oEvento.Id_disciplina = int.Parse(cmbDisciplina.SelectedValue.ToString());
                oEvento.Data_aviso = DateTime.Parse(dtpDataInicial.Value.ToShortDateString());
                oEvento.Data_final = DateTime.Parse(dtpDataFinal.Value.ToShortDateString());


                _controladora.Excluir(oEvento);
                enableCampos(false);
                enableBotoes(false);
                limparCampos();
                carregaGrid();
                MessageBox.Show("Registro excluido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void limparCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            cmbDisciplina.SelectedIndex = -1;
            dtpDataInicial.ResetText();
            dtpDataFinal.ResetText();

        }

        private void enableCampos(bool choise)
        {
            txtNome.Enabled = choise;
            txtCodigo.Enabled = choise;
            txtDescricao.Enabled = choise;
            cmbDisciplina.Enabled = choise;
            dtpDataInicial.Enabled = choise;
            dtpDataFinal.Enabled = choise;
        }

        private void enableBotoes(bool choise)
        {
            btnSalvar.Enabled = choise;
            btnAlterar.Enabled = choise;
            btnExcluir.Enabled = choise;
        }

        private bool validaCampos()
        {
            if (txtCodigo.Text == "")
            {
                txtCodigo.Focus();
                MessageBox.Show("Preencha o campo código!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNome.Text == "")
            {
                txtNome.Focus();
                MessageBox.Show("Preencha o campo nome!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDescricao.Text == "")
            {
                txtDescricao.Focus();
                MessageBox.Show("Preencha o campo Descricao!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbDisciplina.SelectedIndex == -1)
            {
                cmbDisciplina.Focus();
                MessageBox.Show("Preencha o campo Curso!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void carregaGrid()
        {
            ControlEvento _controladora = new ControlEvento();
            grdEvento.DataSource = _controladora.SelecionarTodos();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            ControlEvento _controladora = new ControlEvento();
            ProvasTrabalhos oEvento = new ProvasTrabalhos();
            if (txtCodigo.Text != "")
            {
                oEvento = _controladora.SelecionarPK(int.Parse(txtCodigo.Text));
                if (oEvento != null)
                {
                    cmbDisciplina.SelectedValue = oEvento.Id_disciplina;
                    txtNome.Text = oEvento.Nome;
                    txtDescricao.Text = oEvento.Descricao;
                    dtpDataInicial.Value = oEvento.Data_aviso;
                    dtpDataFinal.Value = oEvento.Data_final;

                    enableCampos(false);
                    enableBotoes(true);
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int retorno;
            if (!int.TryParse(e.KeyChar.ToString(), out retorno))
            {
                if (!(Convert.ToInt16(e.KeyChar) == 8))
                {
                    e.Handled = true;
                }
            }
        }
        private void carregaComboBox()
        {
            ControlDisciplina _controladora = new ControlDisciplina();
            cmbDisciplina.DataSource = _controladora.SelecionarTodos();
            cmbDisciplina.ValueMember = "codigo";
            cmbDisciplina.DisplayMember = "nome";
            cmbDisciplina.SelectedIndex = -1;
        }

        private void frmEvento_Load(object sender, EventArgs e)
        {
            carregaComboBox();
            carregaGrid();
        }
    }
}
