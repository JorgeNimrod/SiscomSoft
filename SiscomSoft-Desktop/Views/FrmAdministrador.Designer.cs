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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministrador));
            this.btnMenu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRollist = new System.Windows.Forms.Button();
            this.btnUserlist = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.btnCategorialist = new System.Windows.Forms.Button();
            this.btnImpuestolist = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnPreciolist = new System.Windows.Forms.Button();
            this.btnProductolist = new System.Windows.Forms.Button();
            this.tbcGeneral = new System.Windows.Forms.TabControl();
            this.tbpProducto = new System.Windows.Forms.TabPage();
            this.tbpPrecio = new System.Windows.Forms.TabPage();
            this.tbpImpuestos = new System.Windows.Forms.TabPage();
            this.tbpCategoria = new System.Windows.Forms.TabPage();
            this.tbpUsuario = new System.Windows.Forms.TabPage();
            this.tbpRol = new System.Windows.Forms.TabPage();
            this.pnlCatalogoRoles = new System.Windows.Forms.Panel();
            this.btnRegistrarRol = new System.Windows.Forms.Button();
            this.dgvDatosRol = new System.Windows.Forms.DataGridView();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizarRol = new System.Windows.Forms.Button();
            this.btnBorrarRol = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.ckbStatusRol = new System.Windows.Forms.CheckBox();
            this.txtBuscarRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpAddRol = new System.Windows.Forms.TabPage();
            this.pnlAddRol = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.pnlAddRolesPermisos = new System.Windows.Forms.Panel();
            this.btnPnlAddPermises = new System.Windows.Forms.Button();
            this.btnPnlAddRoles = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlAddPermisos = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbpUpdateRol = new System.Windows.Forms.TabPage();
            this.pnlUpdateRol = new System.Windows.Forms.Panel();
            this.pnlUpdatePermisos = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtUpdateComentario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUpdateNombre = new System.Windows.Forms.TextBox();
            this.PnlUpdteRolesPermisos = new System.Windows.Forms.Panel();
            this.btnUpdatePermisos = new System.Windows.Forms.Button();
            this.btnUpdateRol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.pnlProducto.SuspendLayout();
            this.tbcGeneral.SuspendLayout();
            this.tbpRol.SuspendLayout();
            this.pnlCatalogoRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosRol)).BeginInit();
            this.tbpAddRol.SuspendLayout();
            this.pnlAddRol.SuspendLayout();
            this.pnlAddRolesPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.pnlAddPermisos.SuspendLayout();
            this.tbpUpdateRol.SuspendLayout();
            this.pnlUpdateRol.SuspendLayout();
            this.pnlUpdatePermisos.SuspendLayout();
            this.PnlUpdteRolesPermisos.SuspendLayout();
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
            this.pnlPrincipal.Controls.Add(this.pnlUsuario);
            this.pnlPrincipal.Controls.Add(this.btnProductos);
            this.pnlPrincipal.Controls.Add(this.btnUser);
            this.pnlPrincipal.Controls.Add(this.pnlProducto);
            this.pnlPrincipal.Location = new System.Drawing.Point(12, 50);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(159, 577);
            this.pnlPrincipal.TabIndex = 22;
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.White;
            this.pnlUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsuario.Controls.Add(this.label1);
            this.pnlUsuario.Controls.Add(this.btnRollist);
            this.pnlUsuario.Controls.Add(this.btnUserlist);
            this.pnlUsuario.Location = new System.Drawing.Point(-1, 209);
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
            // tbcGeneral
            // 
            this.tbcGeneral.Controls.Add(this.tbpProducto);
            this.tbcGeneral.Controls.Add(this.tbpPrecio);
            this.tbcGeneral.Controls.Add(this.tbpImpuestos);
            this.tbcGeneral.Controls.Add(this.tbpCategoria);
            this.tbcGeneral.Controls.Add(this.tbpUsuario);
            this.tbcGeneral.Controls.Add(this.tbpRol);
            this.tbcGeneral.Controls.Add(this.tbpAddRol);
            this.tbcGeneral.Controls.Add(this.tbpUpdateRol);
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
            this.tbpRol.Controls.Add(this.pnlCatalogoRoles);
            this.tbpRol.Location = new System.Drawing.Point(4, 27);
            this.tbpRol.Name = "tbpRol";
            this.tbpRol.Size = new System.Drawing.Size(1151, 546);
            this.tbpRol.TabIndex = 5;
            this.tbpRol.Text = "Roles";
            this.tbpRol.UseVisualStyleBackColor = true;
            // 
            // pnlCatalogoRoles
            // 
            this.pnlCatalogoRoles.Controls.Add(this.btnRegistrarRol);
            this.pnlCatalogoRoles.Controls.Add(this.dgvDatosRol);
            this.pnlCatalogoRoles.Controls.Add(this.btnActualizarRol);
            this.pnlCatalogoRoles.Controls.Add(this.btnBorrarRol);
            this.pnlCatalogoRoles.Controls.Add(this.lblRegistros);
            this.pnlCatalogoRoles.Controls.Add(this.ckbStatusRol);
            this.pnlCatalogoRoles.Controls.Add(this.txtBuscarRol);
            this.pnlCatalogoRoles.Controls.Add(this.label2);
            this.pnlCatalogoRoles.Location = new System.Drawing.Point(3, 2);
            this.pnlCatalogoRoles.Name = "pnlCatalogoRoles";
            this.pnlCatalogoRoles.Size = new System.Drawing.Size(1143, 539);
            this.pnlCatalogoRoles.TabIndex = 0;
            // 
            // btnRegistrarRol
            // 
            this.btnRegistrarRol.Location = new System.Drawing.Point(802, 32);
            this.btnRegistrarRol.Name = "btnRegistrarRol";
            this.btnRegistrarRol.Size = new System.Drawing.Size(120, 41);
            this.btnRegistrarRol.TabIndex = 78;
            this.btnRegistrarRol.Text = "Registrar rol";
            this.btnRegistrarRol.UseVisualStyleBackColor = true;
            this.btnRegistrarRol.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDatosRol
            // 
            this.dgvDatosRol.AllowUserToDeleteRows = false;
            this.dgvDatosRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rol,
            this.sNombre,
            this.sComentario});
            this.dgvDatosRol.Location = new System.Drawing.Point(6, 32);
            this.dgvDatosRol.Name = "dgvDatosRol";
            this.dgvDatosRol.ReadOnly = true;
            this.dgvDatosRol.RowHeadersVisible = false;
            this.dgvDatosRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosRol.Size = new System.Drawing.Size(790, 481);
            this.dgvDatosRol.TabIndex = 77;
            this.dgvDatosRol.DataSourceChanged += new System.EventHandler(this.dgvDatosRol_DataSourceChanged_1);
            // 
            // Rol
            // 
            this.Rol.DataPropertyName = "pkRol";
            this.Rol.HeaderText = "No.";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.Name = "sNombre";
            this.sNombre.ReadOnly = true;
            this.sNombre.Width = 200;
            // 
            // sComentario
            // 
            this.sComentario.DataPropertyName = "sComentario";
            this.sComentario.HeaderText = "Comentario";
            this.sComentario.Name = "sComentario";
            this.sComentario.ReadOnly = true;
            this.sComentario.Width = 487;
            // 
            // btnActualizarRol
            // 
            this.btnActualizarRol.Location = new System.Drawing.Point(802, 79);
            this.btnActualizarRol.Name = "btnActualizarRol";
            this.btnActualizarRol.Size = new System.Drawing.Size(120, 41);
            this.btnActualizarRol.TabIndex = 75;
            this.btnActualizarRol.Text = "Actualizar rol";
            this.btnActualizarRol.UseVisualStyleBackColor = true;
            this.btnActualizarRol.Click += new System.EventHandler(this.btnActualizarRol_Click);
            // 
            // btnBorrarRol
            // 
            this.btnBorrarRol.Location = new System.Drawing.Point(802, 126);
            this.btnBorrarRol.Name = "btnBorrarRol";
            this.btnBorrarRol.Size = new System.Drawing.Size(120, 41);
            this.btnBorrarRol.TabIndex = 76;
            this.btnBorrarRol.Text = "Borrar Rol";
            this.btnBorrarRol.UseVisualStyleBackColor = true;
            this.btnBorrarRol.Click += new System.EventHandler(this.btnBorrarRol_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(3, 516);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 74;
            this.lblRegistros.Text = "Registro:";
            // 
            // ckbStatusRol
            // 
            this.ckbStatusRol.AutoSize = true;
            this.ckbStatusRol.Checked = true;
            this.ckbStatusRol.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatusRol.Location = new System.Drawing.Point(727, 4);
            this.ckbStatusRol.Name = "ckbStatusRol";
            this.ckbStatusRol.Size = new System.Drawing.Size(69, 22);
            this.ckbStatusRol.TabIndex = 71;
            this.ckbStatusRol.Text = "Status";
            this.ckbStatusRol.UseVisualStyleBackColor = true;
            this.ckbStatusRol.CheckedChanged += new System.EventHandler(this.ckbStatusRol_CheckedChanged);
            // 
            // txtBuscarRol
            // 
            this.txtBuscarRol.Location = new System.Drawing.Point(68, 2);
            this.txtBuscarRol.Name = "txtBuscarRol";
            this.txtBuscarRol.Size = new System.Drawing.Size(653, 24);
            this.txtBuscarRol.TabIndex = 70;
            this.txtBuscarRol.TextChanged += new System.EventHandler(this.txtBuscarRol_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "Buscar:";
            // 
            // tbpAddRol
            // 
            this.tbpAddRol.Controls.Add(this.pnlAddRol);
            this.tbpAddRol.Controls.Add(this.pnlAddRolesPermisos);
            this.tbpAddRol.Location = new System.Drawing.Point(4, 27);
            this.tbpAddRol.Name = "tbpAddRol";
            this.tbpAddRol.Size = new System.Drawing.Size(1151, 546);
            this.tbpAddRol.TabIndex = 6;
            this.tbpAddRol.Text = "Registrar Rol";
            this.tbpAddRol.UseVisualStyleBackColor = true;
            // 
            // pnlAddRol
            // 
            this.pnlAddRol.BackColor = System.Drawing.Color.White;
            this.pnlAddRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddRol.Controls.Add(this.pnlAddPermisos);
            this.pnlAddRol.Controls.Add(this.btnRegistrar);
            this.pnlAddRol.Controls.Add(this.txtComentario);
            this.pnlAddRol.Controls.Add(this.label4);
            this.pnlAddRol.Controls.Add(this.label3);
            this.pnlAddRol.Controls.Add(this.txtNombre);
            this.pnlAddRol.Location = new System.Drawing.Point(158, 0);
            this.pnlAddRol.Name = "pnlAddRol";
            this.pnlAddRol.Size = new System.Drawing.Size(993, 546);
            this.pnlAddRol.TabIndex = 25;
            this.pnlAddRol.Visible = false;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(39, 202);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(116, 32);
            this.btnRegistrar.TabIndex = 7;
            this.btnRegistrar.Text = "Guardar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(39, 120);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(321, 76);
            this.txtComentario.TabIndex = 5;
            this.txtComentario.TextChanged += new System.EventHandler(this.txtComentario_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comentario";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(39, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(321, 24);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // pnlAddRolesPermisos
            // 
            this.pnlAddRolesPermisos.BackColor = System.Drawing.Color.White;
            this.pnlAddRolesPermisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddRolesPermisos.Controls.Add(this.btnPnlAddPermises);
            this.pnlAddRolesPermisos.Controls.Add(this.btnPnlAddRoles);
            this.pnlAddRolesPermisos.Location = new System.Drawing.Point(0, 0);
            this.pnlAddRolesPermisos.Name = "pnlAddRolesPermisos";
            this.pnlAddRolesPermisos.Size = new System.Drawing.Size(159, 546);
            this.pnlAddRolesPermisos.TabIndex = 23;
            // 
            // btnPnlAddPermises
            // 
            this.btnPnlAddPermises.BackColor = System.Drawing.Color.White;
            this.btnPnlAddPermises.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPnlAddPermises.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPnlAddPermises.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPnlAddPermises.ForeColor = System.Drawing.Color.Black;
            this.btnPnlAddPermises.Location = new System.Drawing.Point(-2, 41);
            this.btnPnlAddPermises.Name = "btnPnlAddPermises";
            this.btnPnlAddPermises.Size = new System.Drawing.Size(160, 44);
            this.btnPnlAddPermises.TabIndex = 24;
            this.btnPnlAddPermises.Text = "Permisos";
            this.btnPnlAddPermises.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPnlAddPermises.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPnlAddPermises.UseVisualStyleBackColor = false;
            this.btnPnlAddPermises.Click += new System.EventHandler(this.btnPnlAddPermises_Click);
            this.btnPnlAddPermises.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPnlAddPermises_MouseClick);
            // 
            // btnPnlAddRoles
            // 
            this.btnPnlAddRoles.BackColor = System.Drawing.Color.White;
            this.btnPnlAddRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPnlAddRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPnlAddRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPnlAddRoles.ForeColor = System.Drawing.Color.Black;
            this.btnPnlAddRoles.Location = new System.Drawing.Point(-1, -1);
            this.btnPnlAddRoles.Name = "btnPnlAddRoles";
            this.btnPnlAddRoles.Size = new System.Drawing.Size(159, 44);
            this.btnPnlAddRoles.TabIndex = 24;
            this.btnPnlAddRoles.Text = "Roles";
            this.btnPnlAddRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPnlAddRoles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPnlAddRoles.UseVisualStyleBackColor = false;
            this.btnPnlAddRoles.Click += new System.EventHandler(this.btnPnlAddRoles_Click);
            this.btnPnlAddRoles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPnlAddRoles_MouseClick);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // pnlAddPermisos
            // 
            this.pnlAddPermisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddPermisos.Controls.Add(this.label5);
            this.pnlAddPermisos.Location = new System.Drawing.Point(85, 90);
            this.pnlAddPermisos.Name = "pnlAddPermisos";
            this.pnlAddPermisos.Size = new System.Drawing.Size(993, 550);
            this.pnlAddPermisos.TabIndex = 8;
            this.pnlAddPermisos.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "PERMISOS";
            // 
            // tbpUpdateRol
            // 
            this.tbpUpdateRol.Controls.Add(this.pnlUpdateRol);
            this.tbpUpdateRol.Controls.Add(this.PnlUpdteRolesPermisos);
            this.tbpUpdateRol.Location = new System.Drawing.Point(4, 27);
            this.tbpUpdateRol.Name = "tbpUpdateRol";
            this.tbpUpdateRol.Size = new System.Drawing.Size(1151, 546);
            this.tbpUpdateRol.TabIndex = 7;
            this.tbpUpdateRol.Text = "Actualizar Rol";
            this.tbpUpdateRol.UseVisualStyleBackColor = true;
            // 
            // pnlUpdateRol
            // 
            this.pnlUpdateRol.BackColor = System.Drawing.Color.White;
            this.pnlUpdateRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateRol.Controls.Add(this.pnlUpdatePermisos);
            this.pnlUpdateRol.Controls.Add(this.btnUpdate);
            this.pnlUpdateRol.Controls.Add(this.txtUpdateComentario);
            this.pnlUpdateRol.Controls.Add(this.label7);
            this.pnlUpdateRol.Controls.Add(this.label8);
            this.pnlUpdateRol.Controls.Add(this.txtUpdateNombre);
            this.pnlUpdateRol.Location = new System.Drawing.Point(158, 0);
            this.pnlUpdateRol.Name = "pnlUpdateRol";
            this.pnlUpdateRol.Size = new System.Drawing.Size(993, 546);
            this.pnlUpdateRol.TabIndex = 27;
            this.pnlUpdateRol.Visible = false;
            // 
            // pnlUpdatePermisos
            // 
            this.pnlUpdatePermisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdatePermisos.Controls.Add(this.label6);
            this.pnlUpdatePermisos.Location = new System.Drawing.Point(85, 90);
            this.pnlUpdatePermisos.Name = "pnlUpdatePermisos";
            this.pnlUpdatePermisos.Size = new System.Drawing.Size(993, 550);
            this.pnlUpdatePermisos.TabIndex = 8;
            this.pnlUpdatePermisos.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "PERMISOS";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(39, 202);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 32);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Guardar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtUpdateComentario
            // 
            this.txtUpdateComentario.Location = new System.Drawing.Point(39, 120);
            this.txtUpdateComentario.Multiline = true;
            this.txtUpdateComentario.Name = "txtUpdateComentario";
            this.txtUpdateComentario.Size = new System.Drawing.Size(321, 76);
            this.txtUpdateComentario.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Comentario";
            // 
            // txtUpdateNombre
            // 
            this.txtUpdateNombre.Location = new System.Drawing.Point(39, 60);
            this.txtUpdateNombre.Name = "txtUpdateNombre";
            this.txtUpdateNombre.Size = new System.Drawing.Size(321, 24);
            this.txtUpdateNombre.TabIndex = 4;
            // 
            // PnlUpdteRolesPermisos
            // 
            this.PnlUpdteRolesPermisos.BackColor = System.Drawing.Color.White;
            this.PnlUpdteRolesPermisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlUpdteRolesPermisos.Controls.Add(this.btnUpdatePermisos);
            this.PnlUpdteRolesPermisos.Controls.Add(this.btnUpdateRol);
            this.PnlUpdteRolesPermisos.Location = new System.Drawing.Point(0, 0);
            this.PnlUpdteRolesPermisos.Name = "PnlUpdteRolesPermisos";
            this.PnlUpdteRolesPermisos.Size = new System.Drawing.Size(159, 546);
            this.PnlUpdteRolesPermisos.TabIndex = 26;
            // 
            // btnUpdatePermisos
            // 
            this.btnUpdatePermisos.BackColor = System.Drawing.Color.White;
            this.btnUpdatePermisos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdatePermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePermisos.ForeColor = System.Drawing.Color.Black;
            this.btnUpdatePermisos.Location = new System.Drawing.Point(-2, 41);
            this.btnUpdatePermisos.Name = "btnUpdatePermisos";
            this.btnUpdatePermisos.Size = new System.Drawing.Size(160, 44);
            this.btnUpdatePermisos.TabIndex = 24;
            this.btnUpdatePermisos.Text = "Permisos";
            this.btnUpdatePermisos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdatePermisos.UseVisualStyleBackColor = false;
            this.btnUpdatePermisos.Click += new System.EventHandler(this.btnUpdatePermisos_Click);
            this.btnUpdatePermisos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnUpdatePermisos_MouseClick);
            // 
            // btnUpdateRol
            // 
            this.btnUpdateRol.BackColor = System.Drawing.Color.White;
            this.btnUpdateRol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdateRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRol.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateRol.Location = new System.Drawing.Point(-1, -1);
            this.btnUpdateRol.Name = "btnUpdateRol";
            this.btnUpdateRol.Size = new System.Drawing.Size(159, 44);
            this.btnUpdateRol.TabIndex = 24;
            this.btnUpdateRol.Text = "Roles";
            this.btnUpdateRol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateRol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateRol.UseVisualStyleBackColor = false;
            this.btnUpdateRol.Click += new System.EventHandler(this.btnUpdateRol_Click);
            this.btnUpdateRol.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnUpdateRol_MouseClick);
            // 
            // FrmAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 729);
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
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.pnlProducto.ResumeLayout(false);
            this.pnlProducto.PerformLayout();
            this.tbcGeneral.ResumeLayout(false);
            this.tbpRol.ResumeLayout(false);
            this.pnlCatalogoRoles.ResumeLayout(false);
            this.pnlCatalogoRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosRol)).EndInit();
            this.tbpAddRol.ResumeLayout(false);
            this.pnlAddRol.ResumeLayout(false);
            this.pnlAddRol.PerformLayout();
            this.pnlAddRolesPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.pnlAddPermisos.ResumeLayout(false);
            this.pnlAddPermisos.PerformLayout();
            this.tbpUpdateRol.ResumeLayout(false);
            this.pnlUpdateRol.ResumeLayout(false);
            this.pnlUpdateRol.PerformLayout();
            this.pnlUpdatePermisos.ResumeLayout(false);
            this.pnlUpdatePermisos.PerformLayout();
            this.PnlUpdteRolesPermisos.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlCatalogoRoles;
        private System.Windows.Forms.Button btnActualizarRol;
        private System.Windows.Forms.Button btnBorrarRol;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox ckbStatusRol;
        private System.Windows.Forms.TextBox txtBuscarRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDatosRol;
        private System.Windows.Forms.Button btnRegistrarRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sComentario;
        private System.Windows.Forms.TabPage tbpAddRol;
        private System.Windows.Forms.Panel pnlAddRol;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Panel pnlAddRolesPermisos;
        private System.Windows.Forms.Button btnPnlAddPermises;
        private System.Windows.Forms.Button btnPnlAddRoles;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Panel pnlAddPermisos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tbpUpdateRol;
        private System.Windows.Forms.Panel pnlUpdateRol;
        private System.Windows.Forms.Panel pnlUpdatePermisos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtUpdateComentario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUpdateNombre;
        private System.Windows.Forms.Panel PnlUpdteRolesPermisos;
        private System.Windows.Forms.Button btnUpdatePermisos;
        private System.Windows.Forms.Button btnUpdateRol;
    }
}