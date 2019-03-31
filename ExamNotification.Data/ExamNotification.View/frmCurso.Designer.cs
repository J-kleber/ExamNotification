namespace ExamNotification.View
{
    partial class frmCurso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDuracao = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDuracao = new System.Windows.Forms.TextBox();
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.grpAcoes = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.grbListagem = new System.Windows.Forms.GroupBox();
            this.grdCurso = new System.Windows.Forms.DataGridView();
            this.grpDados.SuspendLayout();
            this.grpAcoes.SuspendLayout();
            this.grbListagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(40, 63);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(77, 24);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(51, 127);
            this.lblNome.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(66, 24);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome";
            // 
            // lblDuracao
            // 
            this.lblDuracao.AutoSize = true;
            this.lblDuracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracao.Location = new System.Drawing.Point(29, 191);
            this.lblDuracao.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDuracao.Name = "lblDuracao";
            this.lblDuracao.Size = new System.Drawing.Size(88, 24);
            this.lblDuracao.TabIndex = 2;
            this.lblDuracao.Text = "Duração";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(129, 55);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(6);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(146, 32);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(129, 119);
            this.txtNome.Margin = new System.Windows.Forms.Padding(6);
            this.txtNome.Multiline = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(329, 32);
            this.txtNome.TabIndex = 4;
            // 
            // txtDuracao
            // 
            this.txtDuracao.Location = new System.Drawing.Point(129, 183);
            this.txtDuracao.Margin = new System.Windows.Forms.Padding(6);
            this.txtDuracao.Multiline = true;
            this.txtDuracao.Name = "txtDuracao";
            this.txtDuracao.Size = new System.Drawing.Size(146, 32);
            this.txtDuracao.TabIndex = 5;
            // 
            // grpDados
            // 
            this.grpDados.Controls.Add(this.txtCodigo);
            this.grpDados.Controls.Add(this.txtDuracao);
            this.grpDados.Controls.Add(this.txtNome);
            this.grpDados.Controls.Add(this.lblCodigo);
            this.grpDados.Controls.Add(this.lblNome);
            this.grpDados.Controls.Add(this.lblDuracao);
            this.grpDados.ForeColor = System.Drawing.Color.Black;
            this.grpDados.Location = new System.Drawing.Point(13, 13);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(492, 269);
            this.grpDados.TabIndex = 6;
            this.grpDados.TabStop = false;
            this.grpDados.Text = "Dados do curso";
            // 
            // grpAcoes
            // 
            this.grpAcoes.Controls.Add(this.btnExcluir);
            this.grpAcoes.Controls.Add(this.btnAlterar);
            this.grpAcoes.Controls.Add(this.btnSalvar);
            this.grpAcoes.Controls.Add(this.btnNovo);
            this.grpAcoes.Location = new System.Drawing.Point(522, 13);
            this.grpAcoes.Name = "grpAcoes";
            this.grpAcoes.Size = new System.Drawing.Size(273, 269);
            this.grpAcoes.TabIndex = 7;
            this.grpAcoes.TabStop = false;
            this.grpAcoes.Text = "Ações";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(41, 195);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(211, 32);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(41, 143);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(211, 32);
            this.btnAlterar.TabIndex = 2;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(41, 92);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(211, 32);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(41, 42);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(211, 32);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // grbListagem
            // 
            this.grbListagem.Controls.Add(this.grdCurso);
            this.grbListagem.Location = new System.Drawing.Point(0, 301);
            this.grbListagem.Name = "grbListagem";
            this.grbListagem.Size = new System.Drawing.Size(795, 207);
            this.grbListagem.TabIndex = 8;
            this.grbListagem.TabStop = false;
            this.grbListagem.Text = "Listagem";
            // 
            // grdCurso
            // 
            this.grdCurso.AllowUserToAddRows = false;
            this.grdCurso.AllowUserToDeleteRows = false;
            this.grdCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCurso.Location = new System.Drawing.Point(3, 25);
            this.grdCurso.Name = "grdCurso";
            this.grdCurso.ReadOnly = true;
            this.grdCurso.Size = new System.Drawing.Size(789, 179);
            this.grdCurso.TabIndex = 0;
            // 
            // frmCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 507);
            this.Controls.Add(this.grpAcoes);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.grbListagem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "frmCurso";
            this.Text = "frmCurso";
            this.Load += new System.EventHandler(this.frmCurso_Load);
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.grpAcoes.ResumeLayout(false);
            this.grbListagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDuracao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtDuracao;
        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.GroupBox grpAcoes;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.GroupBox grbListagem;
        private System.Windows.Forms.DataGridView grdCurso;
    }
}