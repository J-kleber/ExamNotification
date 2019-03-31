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
    public partial class frmCurso : Form
    {
        public frmCurso()
        {
            InitializeComponent();
        }

        private bool alterar = false;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool operacaoConcluida = false;
            if (validaCampos())
            {
                
                ControlCurso _controladora = new ControlCurso();
              
                Curso oCurso = new Curso();
                oCurso.Codigo = int.Parse(txtCodigo.Text);
                oCurso.Nome = txtNome.Text;
                oCurso.Duracao = txtDuracao.Text;
                if (!alterar)
                {
                    if (_controladora.SelecionarPK(int.Parse(txtCodigo.Text)) == null)
                    {
                        _controladora.Incluir(oCurso);
                        operacaoConcluida = true;
                    }
                    else
                    {
                        txtCodigo_Leave(this, null);
                    }
                }
                else
                {
                    _controladora.Alterar(oCurso);
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            alterar = false;
            enableCampos(true);
            enableBotoes(false);
            btnSalvar.Enabled = true;
            limparCampos();
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
                ControlCurso _controladora = new ControlCurso();
                Curso oCurso = new Curso();

                oCurso.Codigo = int.Parse(txtCodigo.Text);
                if(_controladora.SelecionarPK(oCurso.Codigo).Alunos.ToList().Count <= 0 && _controladora.SelecionarPK(oCurso.Codigo).Disciplinas.ToList().Count <=0)
                {
                    oCurso.Nome = txtNome.Text;
                    oCurso.Duracao = txtDuracao.Text;
                    _controladora.Excluir(oCurso);
                    enableCampos(false);
                    enableBotoes(false);
                    limparCampos();
                    carregaGrid();
                    MessageBox.Show("Registro excluido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Este curso não pode ser excluido, pois já possui alunos ou disciplinas cadastradas", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limparCampos()
        {
            txtCodigo.Clear();
            txtDuracao.Clear();
            txtNome.Clear();
        }

        private void enableCampos(bool choise)
        {
            txtNome.Enabled = choise;
            txtDuracao.Enabled = choise;
            txtCodigo.Enabled = choise;
        }

        private void enableBotoes(bool choise)
        {
            btnSalvar.Enabled = choise;
            btnAlterar.Enabled = choise;
            btnExcluir.Enabled = choise;
        }

        private bool validaCampos()
        {
            if(txtCodigo.Text == "")
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

            if (txtDuracao.Text == "")
            {
                txtDuracao.Focus();
                MessageBox.Show("Preencha o campo duração!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void frmCurso_Load(object sender, EventArgs e)
        {
            enableBotoes(false);
            enableCampos(false);
            carregaGrid();
        }

        private void carregaGrid()
        {
            ControlCurso _controladora = new ControlCurso();
            grdCurso.DataSource = _controladora.SelecionarTodos();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            ControlCurso _controladora = new ControlCurso();
            Curso oCurso = new Curso();
            if(txtCodigo.Text != "")
            {
                oCurso = _controladora.SelecionarPK(int.Parse(txtCodigo.Text));
                if (oCurso != null)
                {
                    txtNome.Text = oCurso.Nome;
                    txtDuracao.Text = oCurso.Duracao;
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
    }
}
