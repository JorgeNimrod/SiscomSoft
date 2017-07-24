namespace SiscomSoft_Desktop.Views
{
    partial class FrmPeriodoTrabajo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPeriodoTrabajo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.dgvPeriodos = new System.Windows.Forms.DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciarPeriodo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFinalizarPeriodo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pkPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sFechaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(12, 698);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(1337, 18);
            this.label7.TabIndex = 137;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.BackColor = System.Drawing.Color.DarkCyan;
            this.btnMenuPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPrincipal.ForeColor = System.Drawing.Color.White;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(1191, 719);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(158, 37);
            this.btnMenuPrincipal.TabIndex = 136;
            this.btnMenuPrincipal.Text = "MENU PRINCIPAL";
            this.btnMenuPrincipal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuPrincipal.UseVisualStyleBackColor = false;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // dgvPeriodos
            // 
            this.dgvPeriodos.AllowUserToDeleteRows = false;
            this.dgvPeriodos.AllowUserToResizeColumns = false;
            this.dgvPeriodos.AllowUserToResizeRows = false;
            this.dgvPeriodos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriodos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPeriodos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkPeriodo,
            this.sFechaInicio,
            this.sFechaFinal});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeriodos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeriodos.GridColor = System.Drawing.Color.DimGray;
            this.dgvPeriodos.Location = new System.Drawing.Point(12, 50);
            this.dgvPeriodos.MultiSelect = false;
            this.dgvPeriodos.Name = "dgvPeriodos";
            this.dgvPeriodos.ReadOnly = true;
            this.dgvPeriodos.RowHeadersVisible = false;
            this.dgvPeriodos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeriodos.ShowCellErrors = false;
            this.dgvPeriodos.ShowCellToolTips = false;
            this.dgvPeriodos.ShowEditingIcon = false;
            this.dgvPeriodos.ShowRowErrors = false;
            this.dgvPeriodos.Size = new System.Drawing.Size(1037, 587);
            this.dgvPeriodos.TabIndex = 135;
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.DimGray;
            this.lblFecha.Location = new System.Drawing.Point(743, 26);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFecha.Size = new System.Drawing.Size(609, 18);
            this.lblFecha.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1055, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 16);
            this.label1.TabIndex = 138;
            this.label1.Text = "INICIE UN PERIODO PARA HABILITAR EL POS";
            // 
            // btnIniciarPeriodo
            // 
            this.btnIniciarPeriodo.BackColor = System.Drawing.Color.DarkCyan;
            this.btnIniciarPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarPeriodo.ForeColor = System.Drawing.Color.White;
            this.btnIniciarPeriodo.Location = new System.Drawing.Point(1055, 69);
            this.btnIniciarPeriodo.Name = "btnIniciarPeriodo";
            this.btnIniciarPeriodo.Size = new System.Drawing.Size(294, 37);
            this.btnIniciarPeriodo.TabIndex = 139;
            this.btnIniciarPeriodo.Text = "INICIAR PERIODO";
            this.btnIniciarPeriodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIniciarPeriodo.UseVisualStyleBackColor = false;
            this.btnIniciarPeriodo.Click += new System.EventHandler(this.btnIniciarPeriodo_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnFinalizarPeriodo
            // 
            this.btnFinalizarPeriodo.BackColor = System.Drawing.Color.Firebrick;
            this.btnFinalizarPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarPeriodo.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarPeriodo.Location = new System.Drawing.Point(1055, 112);
            this.btnFinalizarPeriodo.Name = "btnFinalizarPeriodo";
            this.btnFinalizarPeriodo.Size = new System.Drawing.Size(294, 37);
            this.btnFinalizarPeriodo.TabIndex = 140;
            this.btnFinalizarPeriodo.Text = "FINALIZAR PERIODO";
            this.btnFinalizarPeriodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFinalizarPeriodo.UseVisualStyleBackColor = false;
            this.btnFinalizarPeriodo.Click += new System.EventHandler(this.btnFinalizarPeriodo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 133;
            this.pictureBox1.TabStop = false;
            // 
            // pkPeriodo
            // 
            this.pkPeriodo.DataPropertyName = "pkPeriodo";
            this.pkPeriodo.HeaderText = "No.";
            this.pkPeriodo.Name = "pkPeriodo";
            this.pkPeriodo.ReadOnly = true;
            this.pkPeriodo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pkPeriodo.Visible = false;
            // 
            // sFechaInicio
            // 
            this.sFechaInicio.DataPropertyName = "dtInicio";
            this.sFechaInicio.HeaderText = "Fecha Inicio";
            this.sFechaInicio.Name = "sFechaInicio";
            this.sFechaInicio.ReadOnly = true;
            this.sFechaInicio.Width = 517;
            // 
            // sFechaFinal
            // 
            this.sFechaFinal.DataPropertyName = "dtFinal";
            this.sFechaFinal.HeaderText = "Fecha Final";
            this.sFechaFinal.Name = "sFechaFinal";
            this.sFechaFinal.ReadOnly = true;
            this.sFechaFinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sFechaFinal.Width = 517;
            // 
            // FrmPeriodoTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.btnFinalizarPeriodo);
            this.Controls.Add(this.btnIniciarPeriodo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.dgvPeriodos);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPeriodoTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPeriodoTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.DataGridView dgvPeriodos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciarPeriodo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnFinalizarPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn sFechaFinal;
    }
}