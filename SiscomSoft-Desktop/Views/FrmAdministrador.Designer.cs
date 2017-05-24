namespace SiscomSoft_Desktop.Views
{
    partial class FrmAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministrador));
            this.btnMenu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.btnCategorialist = new System.Windows.Forms.Button();
            this.btnImpuestolist = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnPreciolist = new System.Windows.Forms.Button();
            this.btnProductolist = new System.Windows.Forms.Button();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRollist = new System.Windows.Forms.Button();
            this.btnUserlist = new System.Windows.Forms.Button();
            this.tbcGeneral = new System.Windows.Forms.TabControl();
            this.tbpProducto = new System.Windows.Forms.TabPage();
            this.tbpPrecio = new System.Windows.Forms.TabPage();
            this.tbpImpuestos = new System.Windows.Forms.TabPage();
            this.tbpCategoria = new System.Windows.Forms.TabPage();
            this.tbpUsuario = new System.Windows.Forms.TabPage();
            this.tbpRol = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlProducto.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.tbcGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(1291, 676);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(55, 49);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.btnProductos);
            this.pnlPrincipal.Controls.Add(this.btnUser);
            this.pnlPrincipal.Controls.Add(this.pnlProducto);
            this.pnlPrincipal.Location = new System.Drawing.Point(12, 50);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(159, 577);
            this.pnlPrincipal.TabIndex = 22;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.DarkCyan;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.Location = new System.Drawing.Point(-1, 491);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(162, 44);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.DarkCyan;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.Location = new System.Drawing.Point(-1, 532);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(162, 44);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Usuarios";
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // pnlProducto
            // 
            this.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProducto.Controls.Add(this.btnCategorialist);
            this.pnlProducto.Controls.Add(this.btnImpuestolist);
            this.pnlProducto.Controls.Add(this.lblNombre);
            this.pnlProducto.Controls.Add(this.btnPreciolist);
            this.pnlProducto.Controls.Add(this.btnProductolist);
            this.pnlProducto.Location = new System.Drawing.Point(-1, -1);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new System.Drawing.Size(159, 204);
            this.pnlProducto.TabIndex = 4;
            this.pnlProducto.Visible = false;
            // 
            // btnCategorialist
            // 
            this.btnCategorialist.BackColor = System.Drawing.Color.White;
            this.btnCategorialist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCategorialist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorialist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorialist.ForeColor = System.Drawing.Color.Black;
            this.btnCategorialist.Location = new System.Drawing.Point(-2, 159);
            this.btnCategorialist.Name = "btnCategorialist";
            this.btnCategorialist.Size = new System.Drawing.Size(161, 44);
            this.btnCategorialist.TabIndex = 8;
            this.btnCategorialist.Text = "Lista de Categorias";
            this.btnCategorialist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorialist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorialist.UseVisualStyleBackColor = false;
            this.btnCategorialist.Click += new System.EventHandler(this.btnCategorialist_Click);
            this.btnCategorialist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCategorialist_MouseClick);
            // 
            // btnImpuestolist
            // 
            this.btnImpuestolist.BackColor = System.Drawing.Color.White;
            this.btnImpuestolist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImpuestolist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImpuestolist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpuestolist.ForeColor = System.Drawing.Color.Black;
            this.btnImpuestolist.Location = new System.Drawing.Point(-2, 116);
            this.btnImpuestolist.Name = "btnImpuestolist";
            this.btnImpuestolist.Size = new System.Drawing.Size(161, 44);
            this.btnImpuestolist.TabIndex = 7;
            this.btnImpuestolist.Text = "Lista de Impuestos";
            this.btnImpuestolist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImpuestolist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImpuestolist.UseVisualStyleBackColor = false;
            this.btnImpuestolist.Click += new System.EventHandler(this.btnImpuestolist_Click);
            this.btnImpuestolist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnImpuestolist_MouseClick);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(3, 7);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(77, 18);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Productos";
            // 
            // btnPreciolist
            // 
            this.btnPreciolist.BackColor = System.Drawing.Color.White;
            this.btnPreciolist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPreciolist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreciolist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreciolist.ForeColor = System.Drawing.Color.Black;
            this.btnPreciolist.Location = new System.Drawing.Point(-2, 75);
            this.btnPreciolist.Name = "btnPreciolist";
            this.btnPreciolist.Size = new System.Drawing.Size(161, 44);
            this.btnPreciolist.TabIndex = 6;
            this.btnPreciolist.Text = "Lista de Precios";
            this.btnPreciolist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreciolist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreciolist.UseVisualStyleBackColor = false;
            this.btnPreciolist.Click += new System.EventHandler(this.btnPreciolist_Click);
            this.btnPreciolist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPreciolist_MouseClick);
            // 
            // btnProductolist
            // 
            this.btnProductolist.BackColor = System.Drawing.Color.White;
            this.btnProductolist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProductolist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductolist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductolist.ForeColor = System.Drawing.Color.Black;
            this.btnProductolist.Location = new System.Drawing.Point(-2, 34);
            this.btnProductolist.Name = "btnProductolist";
            this.btnProductolist.Size = new System.Drawing.Size(160, 44);
            this.btnProductolist.TabIndex = 5;
            this.btnProductolist.Text = "Lista de Productos";
            this.btnProductolist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductolist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductolist.UseVisualStyleBackColor = false;
            this.btnProductolist.Click += new System.EventHandler(this.btnProductolist_Click);
            this.btnProductolist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnProductolist_MouseClick);
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.White;
            this.pnlUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsuario.Controls.Add(this.label1);
            this.pnlUsuario.Controls.Add(this.btnRollist);
            this.pnlUsuario.Controls.Add(this.btnUserlist);
            this.pnlUsuario.Location = new System.Drawing.Point(12, 260);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(159, 120);
            this.pnlUsuario.TabIndex = 11;
            this.pnlUsuario.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuarios";
            // 
            // btnRollist
            // 
            this.btnRollist.BackColor = System.Drawing.Color.White;
            this.btnRollist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRollist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollist.ForeColor = System.Drawing.Color.Black;
            this.btnRollist.Location = new System.Drawing.Point(-1, 75);
            this.btnRollist.Name = "btnRollist";
            this.btnRollist.Size = new System.Drawing.Size(160, 44);
            this.btnRollist.TabIndex = 6;
            this.btnRollist.Text = "Lista de Roles";
            this.btnRollist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRollist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRollist.UseVisualStyleBackColor = false;
            this.btnRollist.Click += new System.EventHandler(this.btnRollist_Click);
            this.btnRollist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnRollist_MouseClick);
            // 
            // btnUserlist
            // 
            this.btnUserlist.BackColor = System.Drawing.Color.White;
            this.btnUserlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUserlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserlist.ForeColor = System.Drawing.Color.Black;
            this.btnUserlist.Location = new System.Drawing.Point(-1, 34);
            this.btnUserlist.Name = "btnUserlist";
            this.btnUserlist.Size = new System.Drawing.Size(161, 44);
            this.btnUserlist.TabIndex = 5;
            this.btnUserlist.Text = "Lista de Usuarios";
            this.btnUserlist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserlist.UseVisualStyleBackColor = false;
            this.btnUserlist.Click += new System.EventHandler(this.btnUserlist_Click);
            this.btnUserlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnUserlist_MouseClick);
            // 
            // tbcGeneral
            // 
            this.tbcGeneral.Controls.Add(this.tbpProducto);
            this.tbcGeneral.Controls.Add(this.tbpPrecio);
            this.tbcGeneral.Controls.Add(this.tbpImpuestos);
            this.tbcGeneral.Controls.Add(this.tbpCategoria);
            this.tbcGeneral.Controls.Add(this.tbpUsuario);
            this.tbcGeneral.Controls.Add(this.tbpRol);
            this.tbcGeneral.Location = new System.Drawing.Point(179, 50);
            this.tbcGeneral.Name = "tbcGeneral";
            this.tbcGeneral.SelectedIndex = 0;
            this.tbcGeneral.Size = new System.Drawing.Size(1159, 577);
            this.tbcGeneral.TabIndex = 23;
            this.tbcGeneral.Visible = false;
            // 
            // tbpProducto
            // 
            this.tbpProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpProducto.Location = new System.Drawing.Point(4, 27);
            this.tbpProducto.Name = "tbpProducto";
            this.tbpProducto.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProducto.Size = new System.Drawing.Size(1151, 546);
            this.tbpProducto.TabIndex = 0;
            this.tbpProducto.Text = "Productos";
            this.tbpProducto.UseVisualStyleBackColor = true;
            // 
            // tbpPrecio
            // 
            this.tbpPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpPrecio.Location = new System.Drawing.Point(4, 27);
            this.tbpPrecio.Name = "tbpPrecio";
            this.tbpPrecio.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPrecio.Size = new System.Drawing.Size(1151, 546);
            this.tbpPrecio.TabIndex = 1;
            this.tbpPrecio.Text = "Precios";
            this.tbpPrecio.UseVisualStyleBackColor = true;
            // 
            // tbpImpuestos
            // 
            this.tbpImpuestos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpImpuestos.Location = new System.Drawing.Point(4, 27);
            this.tbpImpuestos.Name = "tbpImpuestos";
            this.tbpImpuestos.Size = new System.Drawing.Size(1151, 546);
            this.tbpImpuestos.TabIndex = 2;
            this.tbpImpuestos.Text = "Impuestos";
            this.tbpImpuestos.UseVisualStyleBackColor = true;
            // 
            // tbpCategoria
            // 
            this.tbpCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpCategoria.Location = new System.Drawing.Point(4, 27);
            this.tbpCategoria.Name = "tbpCategoria";
            this.tbpCategoria.Size = new System.Drawing.Size(1151, 546);
            this.tbpCategoria.TabIndex = 3;
            this.tbpCategoria.Text = "Categorias";
            this.tbpCategoria.UseVisualStyleBackColor = true;
            // 
            // tbpUsuario
            // 
            this.tbpUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpUsuario.Location = new System.Drawing.Point(4, 27);
            this.tbpUsuario.Name = "tbpUsuario";
            this.tbpUsuario.Size = new System.Drawing.Size(1151, 546);
            this.tbpUsuario.TabIndex = 4;
            this.tbpUsuario.Text = "Usuarios";
            this.tbpUsuario.UseVisualStyleBackColor = true;
            // 
            // tbpRol
            // 
            this.tbpRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpRol.Location = new System.Drawing.Point(4, 27);
            this.tbpRol.Name = "tbpRol";
            this.tbpRol.Size = new System.Drawing.Size(1151, 546);
            this.tbpRol.TabIndex = 5;
            this.tbpRol.Text = "Roles";
            this.tbpRol.UseVisualStyleBackColor = true;
            // 
            // FrmAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.tbcGeneral);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmAdministrador";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAdministrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlProducto.ResumeLayout(false);
            this.pnlProducto.PerformLayout();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.tbcGeneral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Panel pnlProducto;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRollist;
        private System.Windows.Forms.Button btnUserlist;
        private System.Windows.Forms.Button btnCategorialist;
        private System.Windows.Forms.Button btnImpuestolist;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnPreciolist;
        private System.Windows.Forms.Button btnProductolist;
        private System.Windows.Forms.TabControl tbcGeneral;
        private System.Windows.Forms.TabPage tbpProducto;
        private System.Windows.Forms.TabPage tbpPrecio;
        private System.Windows.Forms.TabPage tbpImpuestos;
        private System.Windows.Forms.TabPage tbpCategoria;
        private System.Windows.Forms.TabPage tbpUsuario;
        private System.Windows.Forms.TabPage tbpRol;
    }
}