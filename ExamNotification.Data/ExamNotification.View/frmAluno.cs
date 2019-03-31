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
    public partial class frmAluno : Form
    {
        private bool alterar = false;
        public frmAluno()
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

                ControlAluno _controladora = new ControlAluno();
                Alunos oAluno = new Alunos();
                oAluno.Matricula = int.Parse(txtCodigo.Text);
                oAluno.Nome = txtNome.Text;
                oAluno.Email = txtEmail.Text;
                oAluno.Id_curso = int.Parse(cmbCurso.SelectedValue.ToString());
                if (!alterar)
                {
                    if (_controladora.SelecionarPK(int.Parse(txtCodigo.Text)) == null)
                    {
                        _controladora.Incluir(oAluno);
                        operacaoConcluida = true;
                    }
                    else
                    {
                        txtCodigo_Leave(this, null);
                    }
                }
                else
                {
                    _controladora.Alterar(oAluno);
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
                ControlAluno _controladora = new ControlAluno();
                Alunos oAlunos = new Alunos();

                oAlunos.Matricula = int.Parse(txtCodigo.Text);
                oAlunos.Nome = txtNome.Text;
                oAlunos.Email = txtEmail.Text;
                oAlunos.Id_curso = int.Parse(cmbCurso.SelectedValue.ToString());

                _controladora.Excluir(oAlunos);
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
            txtEmail.Clear();
            cmbCurso.SelectedIndex = -1;
        }

        private void enableCampos(bool choise)
        {
            txtNome.Enabled = choise;
            txtCodigo.Enabled = choise;
            txtEmail.Enabled = choise;
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

            if (txtEmail.Text == "")
            {
                txtEmail.Focus();
                MessageBox.Show("Preencha o campo E-mail!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ControlAluno _controladora = new ControlAluno();
            grdAlunos.DataSource = _controladora.SelecionarTodos();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            ControlAluno _controladora = new ControlAluno();
            Alunos oAluno = new Alunos();
            if (txtCodigo.Text != "")
            {
                oAluno = _controladora.SelecionarPK(int.Parse(txtCodigo.Text));
                if (oAluno != null)
                {
                    cmbCurso.SelectedValue = oAluno.Id_curso;
                    txtNome.Text = oAluno.Nome;
                    txtEmail.Text = oAluno.Email;

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
            ControlCurso _controladora = new ControlCurso();
            cmbCurso.DataSource = _controladora.SelecionarTodos();
            cmbCurso.ValueMember = "codigo";
            cmbCurso.DisplayMember = "nome";
            cmbCurso.SelectedIndex = -1;
        }

        private void frmAluno_Load(object sender, EventArgs e)
        {
            carregaGrid();
            carregaComboBox();
        }

    }
}
