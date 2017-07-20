namespace SiscomSoft_Desktop.Views.UICONTROL
{
    partial class FrmAgregarDescuentoProducto
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlAccionesDesc = new System.Windows.Forms.Panel();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnMenosCantidad = new System.Windows.Forms.Button();
            this.btnMasCantidad = new System.Windows.Forms.Button();
            this.pnlAccionesDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(793, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(708, 343);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 44);
            this.btnAgregar.TabIndex = 128;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(184, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 127;
            this.label1.Text = "Impuesto";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 24);
            this.textBox1.TabIndex = 126;
            // 
            // pnlAccionesDesc
            // 
            this.pnlAccionesDesc.Controls.Add(this.btnRemoveRow);
            this.pnlAccionesDesc.Controls.Add(this.btnMenosCantidad);
            this.pnlAccionesDesc.Controls.Add(this.btnMasCantidad);
            this.pnlAccionesDesc.Location = new System.Drawing.Point(20, 13);
            this.pnlAccionesDesc.Name = "pnlAccionesDesc";
            this.pnlAccionesDesc.Size = new System.Drawing.Size(104, 192);
            this.pnlAccionesDesc.TabIndex = 125;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.White;
            this.btnRemoveRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRow.ForeColor = System.Drawing.Color.DimGray;
            this.btnRemoveRow.Location = new System.Drawing.Point(0, 132);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(104, 60);
            this.btnRemoveRow.TabIndex = 22;
            this.btnRemoveRow.Text = "x";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            // 
            // btnMenosCantidad
            // 
            this.btnMenosCantidad.BackColor = System.Drawing.Color.White;
            this.btnMenosCantidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenosCantidad.Enabled = false;
            this.btnMenosCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenosCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosCantidad.ForeColor = System.Drawing.Color.DimGray;
            this.btnMenosCantidad.Location = new System.Drawing.Point(0, 66);
            this.btnMenosCantidad.Name = "btnMenosCantidad";
            this.btnMenosCantidad.Size = new System.Drawing.Size(104, 60);
            this.btnMenosCantidad.TabIndex = 21;
            this.btnMenosCantidad.Text = "-";
            this.btnMenosCantidad.UseVisualStyleBackColor = false;
            // 
            // btnMasCantidad
            // 
            this.btnMasCantidad.BackColor = System.Drawing.Color.White;
            this.btnMasCantidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasCantidad.ForeColor = System.Drawing.Color.DimGray;
            this.btnMasCantidad.Location = new System.Drawing.Point(0, 0);
            this.btnMasCantidad.Name = "btnMasCantidad";
            this.btnMasCantidad.Size = new System.Drawing.Size(104, 60);
            this.btnMasCantidad.TabIndex = 20;
            this.btnMasCantidad.Text = "+";
            this.btnMasCantidad.UseVisualStyleBackColor = false;
            // 
            // FrmAgregarDescuentoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(831, 408);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pnlAccionesDesc);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAgregarDescuentoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlAccionesDesc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnlAccionesDesc;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnMenosCantidad;
        private System.Windows.Forms.Button btnMasCantidad;
    }
}