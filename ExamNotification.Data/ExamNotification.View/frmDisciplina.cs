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
    public partial class frmDisciplina : Form
    {
        private bool alterar = false;

        public frmDisciplina()
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

                ControlDisciplina _controladora = new ControlDisciplina();
                Disciplinas oDisciplina = new Disciplinas();
                oDisciplina.Codigo = int.Parse(txtCodigo.Text);
                oDisciplina.Nome = txtNome.Text;
                oDisciplina.Codigo_Curso = int.Parse(cmbCurso.SelectedValue.ToString());
                if (!alterar)
                {
                    if (_controladora.SelecionarPK(int.Parse(txtCodigo.Text)) == null)
                    {
                        _controladora.Incluir(oDisciplina);
                        operacaoConcluida = true;
                    }
                    else
                    {
                        txtCodigo_Leave(this, null);
                    }
                }
                else
                {
                    _controladora.Alterar(oDisciplina);
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
            if(excluir == "OK")
            {
                ControlDisciplina _controladora = new ControlDisciplina();
                Disciplinas oDisciplina = new Disciplinas();

                oDisciplina.Codigo = int.Parse(txtCodigo.Text);
                oDisciplina.Nome = txtNome.Text;
                oDisciplina.Codigo_Curso = int.Parse(cmbCurso.SelectedValue.ToString());

                if(_controladora.SelecionarPK(oDisciplina.Codigo).ProvasTrabalhos.ToList().Count <= 0)
                {
                    _controladora.Excluir(oDisciplina);
                    enableCampos(false);
                    enableBotoes(false);
                    limparCampos();
                    carregaGrid();
                    MessageBox.Show("Registro excluido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Esta disciplina não pode ser excluido, pois já possui um evento associada a ela", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
          
        }

        private void limparCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            cmbCurso.SelectedIndex = -1;
        }

        private void enableCampos(bool choise)
        {
            txtNome.Enabled = choise;
            txtCodigo.Enabled = choise;
            cmbCurso.Enabled = choise;
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

            if (cmbCurso.SelectedIndex == -1)
            {
                cmbCurso.Focus();
                MessageBox.Show("Preencha o campo Curso!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void carregaGrid()
        {
            ControlDisciplina _controladora = new ControlDisciplina();
            grdDisciplinas.DataSource = _controladora.SelecionarTodos();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            ControlDisciplina _controladora = new ControlDisciplina();
            Disciplinas oDisciplina = new Disciplinas();
            if (txtCodigo.Text != "")
            {
                oDisciplina = _controladora.SelecionarPK(int.Parse(txtCodigo.Text));
                if (oDisciplina != null)
                {
                    cmbCurso.SelectedValue = oDisciplina.Codigo_Curso;
                    txtNome.Text = oDisciplina.Nome;

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

        private void frmDisciplina_Load(object sender, EventArgs e)
        {
            carregaComboBox();
            carregaGrid();
        }

        private void carregaComboBox()
        {
            ControlCurso _controladora = new ControlCurso();
            cmbCurso.DataSource = _controladora.SelecionarTodos();
            cmbCurso.ValueMember = "codigo";
            cmbCurso.DisplayMember = "nome";
            cmbCurso.SelectedIndex = -1;
        }
    }
}
