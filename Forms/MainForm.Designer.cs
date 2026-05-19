namespace SistemaEstudiantes.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        lblTitulo        = new Label();
        gbDatos          = new GroupBox();
        lblId            = new Label();
        lblIdValor       = new Label();
        lblCodigo        = new Label();
        txtCodigo        = new TextBox();
        lblNombre        = new Label();
        txtNombre        = new TextBox();
        lblCategoria     = new Label();
        cboCategoria     = new ComboBox();
        lblMarca         = new Label();
        cboMarca         = new ComboBox();
        lblPrecio        = new Label();
        txtPrecio        = new TextBox();
        lblStock         = new Label();
        txtStock         = new TextBox();
        lblDescripcion   = new Label();
        txtDescripcion   = new TextBox();
        lblFechaIngreso  = new Label();
        dtpFechaIngreso  = new DateTimePicker();
        gbBusqueda       = new GroupBox();
        lblBuscar        = new Label();
        txtBuscar        = new TextBox();
        btnBuscar        = new Button();
        gbAcciones       = new GroupBox();
        btnNuevo         = new Button();
        btnGuardar       = new Button();
        btnActualizar    = new Button();
        btnEliminar      = new Button();
        btnLimpiar       = new Button();
        btnMostrarTodos  = new Button();
        lblEstado        = new Label();
        dgvProductos     = new DataGridView();

        gbDatos.SuspendLayout();
        gbBusqueda.SuspendLayout();
        gbAcciones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
        SuspendLayout();

        // lblTitulo
        lblTitulo.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DarkRed;
        lblTitulo.Location  = new Point(0, 8);
        lblTitulo.Name      = "lblTitulo";
        lblTitulo.Size      = new Size(952, 35);
        lblTitulo.Text      = "LOCAL DE ELECTRODOMÉSTICOS  -  GESTIÓN DE PRODUCTOS";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

        // gbDatos
        gbDatos.Controls.Add(lblId);
        gbDatos.Controls.Add(lblIdValor);
        gbDatos.Controls.Add(lblCodigo);
        gbDatos.Controls.Add(txtCodigo);
        gbDatos.Controls.Add(lblNombre);
        gbDatos.Controls.Add(txtNombre);
        gbDatos.Controls.Add(lblCategoria);
        gbDatos.Controls.Add(cboCategoria);
        gbDatos.Controls.Add(lblMarca);
        gbDatos.Controls.Add(cboMarca);
        gbDatos.Controls.Add(lblPrecio);
        gbDatos.Controls.Add(txtPrecio);
        gbDatos.Controls.Add(lblStock);
        gbDatos.Controls.Add(txtStock);
        gbDatos.Controls.Add(lblDescripcion);
        gbDatos.Controls.Add(txtDescripcion);
        gbDatos.Controls.Add(lblFechaIngreso);
        gbDatos.Controls.Add(dtpFechaIngreso);
        gbDatos.Font     = new Font("Segoe UI", 9F, FontStyle.Bold);
        gbDatos.Location = new Point(12, 48);
        gbDatos.Name     = "gbDatos";
        gbDatos.Size     = new Size(448, 338);
        gbDatos.TabStop  = false;
        gbDatos.Text     = "Datos del Producto";

        // lblId / lblIdValor
        lblId.AutoSize = true;
        lblId.Font     = new Font("Segoe UI", 8.25F);
        lblId.Location = new Point(12, 28);
        lblId.Text     = "ID:";

        lblIdValor.AutoSize  = true;
        lblIdValor.Font      = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblIdValor.ForeColor = Color.DarkRed;
        lblIdValor.Location  = new Point(60, 28);
        lblIdValor.Name      = "lblIdValor";
        lblIdValor.Text      = "Nuevo";

        // Código
        lblCodigo.AutoSize = true;
        lblCodigo.Font     = new Font("Segoe UI", 8.25F);
        lblCodigo.Location = new Point(12, 60);
        lblCodigo.Text     = "Código *:";

        txtCodigo.CharacterCasing = CharacterCasing.Upper;
        txtCodigo.Font     = new Font("Segoe UI", 8.25F);
        txtCodigo.Location = new Point(140, 56);
        txtCodigo.MaxLength= 20;
        txtCodigo.Name     = "txtCodigo";
        txtCodigo.Size     = new Size(150, 23);
        txtCodigo.TabIndex = 0;

        // Nombre
        lblNombre.AutoSize = true;
        lblNombre.Font     = new Font("Segoe UI", 8.25F);
        lblNombre.Location = new Point(12, 93);
        lblNombre.Text     = "Nombre *:";

        txtNombre.Font     = new Font("Segoe UI", 8.25F);
        txtNombre.Location = new Point(140, 89);
        txtNombre.MaxLength= 150;
        txtNombre.Name     = "txtNombre";
        txtNombre.Size     = new Size(290, 23);
        txtNombre.TabIndex = 1;

        // Categoría
        lblCategoria.AutoSize = true;
        lblCategoria.Font     = new Font("Segoe UI", 8.25F);
        lblCategoria.Location = new Point(12, 126);
        lblCategoria.Text     = "Categoría *:";

        cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCategoria.Font          = new Font("Segoe UI", 8.25F);
        cboCategoria.Location      = new Point(140, 122);
        cboCategoria.Name          = "cboCategoria";
        cboCategoria.Size          = new Size(290, 23);
        cboCategoria.TabIndex      = 2;

        // Marca
        lblMarca.AutoSize = true;
        lblMarca.Font     = new Font("Segoe UI", 8.25F);
        lblMarca.Location = new Point(12, 159);
        lblMarca.Text     = "Marca *:";

        cboMarca.DropDownStyle = ComboBoxStyle.DropDown;
        cboMarca.Font          = new Font("Segoe UI", 8.25F);
        cboMarca.Location      = new Point(140, 155);
        cboMarca.Name          = "cboMarca";
        cboMarca.Size          = new Size(200, 23);
        cboMarca.TabIndex      = 3;

        // Precio + Stock (misma fila)
        lblPrecio.AutoSize = true;
        lblPrecio.Font     = new Font("Segoe UI", 8.25F);
        lblPrecio.Location = new Point(12, 192);
        lblPrecio.Text     = "Precio (USD) *:";

        txtPrecio.Font      = new Font("Segoe UI", 8.25F);
        txtPrecio.Location  = new Point(140, 188);
        txtPrecio.MaxLength = 12;
        txtPrecio.Name      = "txtPrecio";
        txtPrecio.Size      = new Size(100, 23);
        txtPrecio.TabIndex  = 4;

        lblStock.AutoSize = true;
        lblStock.Font     = new Font("Segoe UI", 8.25F);
        lblStock.Location = new Point(255, 192);
        lblStock.Text     = "Stock:";

        txtStock.Font      = new Font("Segoe UI", 8.25F);
        txtStock.Location  = new Point(305, 188);
        txtStock.MaxLength = 6;
        txtStock.Name      = "txtStock";
        txtStock.Size      = new Size(80, 23);
        txtStock.TabIndex  = 5;

        // Descripción (multiline)
        lblDescripcion.AutoSize = true;
        lblDescripcion.Font     = new Font("Segoe UI", 8.25F);
        lblDescripcion.Location = new Point(12, 225);
        lblDescripcion.Text     = "Descripción:";

        txtDescripcion.Font        = new Font("Segoe UI", 8.25F);
        txtDescripcion.Location    = new Point(140, 221);
        txtDescripcion.MaxLength   = 300;
        txtDescripcion.Multiline   = true;
        txtDescripcion.Name        = "txtDescripcion";
        txtDescripcion.ScrollBars  = ScrollBars.Vertical;
        txtDescripcion.Size        = new Size(290, 60);
        txtDescripcion.TabIndex    = 6;

        // Fecha Ingreso
        lblFechaIngreso.AutoSize = true;
        lblFechaIngreso.Font     = new Font("Segoe UI", 8.25F);
        lblFechaIngreso.Location = new Point(12, 296);
        lblFechaIngreso.Text     = "Fecha Ingreso:";

        dtpFechaIngreso.Format   = DateTimePickerFormat.Short;
        dtpFechaIngreso.Font     = new Font("Segoe UI", 8.25F);
        dtpFechaIngreso.Location = new Point(140, 292);
        dtpFechaIngreso.Name     = "dtpFechaIngreso";
        dtpFechaIngreso.Size     = new Size(185, 23);
        dtpFechaIngreso.TabIndex = 7;

        // gbBusqueda
        gbBusqueda.Controls.Add(lblBuscar);
        gbBusqueda.Controls.Add(txtBuscar);
        gbBusqueda.Controls.Add(btnBuscar);
        gbBusqueda.Font     = new Font("Segoe UI", 9F, FontStyle.Bold);
        gbBusqueda.Location = new Point(470, 48);
        gbBusqueda.Name     = "gbBusqueda";
        gbBusqueda.Size     = new Size(462, 75);
        gbBusqueda.TabStop  = false;
        gbBusqueda.Text     = "Búsqueda  (por código, nombre, categoría o marca)";

        lblBuscar.AutoSize = true;
        lblBuscar.Font     = new Font("Segoe UI", 8.25F);
        lblBuscar.Location = new Point(12, 32);
        lblBuscar.Text     = "Buscar:";

        txtBuscar.Font     = new Font("Segoe UI", 8.25F);
        txtBuscar.Location = new Point(72, 28);
        txtBuscar.Name     = "txtBuscar";
        txtBuscar.Size     = new Size(265, 23);
        txtBuscar.TabIndex = 8;

        btnBuscar.BackColor             = Color.SteelBlue;
        btnBuscar.ForeColor             = Color.White;
        btnBuscar.FlatStyle             = FlatStyle.Flat;
        btnBuscar.Font                  = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        btnBuscar.Location              = new Point(347, 26);
        btnBuscar.Name                  = "btnBuscar";
        btnBuscar.Size                  = new Size(100, 27);
        btnBuscar.Text                  = "Buscar";
        btnBuscar.UseVisualStyleBackColor = false;
        btnBuscar.Click                += BtnBuscar_Click;

        // gbAcciones
        gbAcciones.Controls.Add(btnNuevo);
        gbAcciones.Controls.Add(btnGuardar);
        gbAcciones.Controls.Add(btnActualizar);
        gbAcciones.Controls.Add(btnEliminar);
        gbAcciones.Controls.Add(btnLimpiar);
        gbAcciones.Controls.Add(btnMostrarTodos);
        gbAcciones.Controls.Add(lblEstado);
        gbAcciones.Font     = new Font("Segoe UI", 9F, FontStyle.Bold);
        gbAcciones.Location = new Point(470, 130);
        gbAcciones.Name     = "gbAcciones";
        gbAcciones.Size     = new Size(462, 256);
        gbAcciones.TabStop  = false;
        gbAcciones.Text     = "Acciones CRUD";

        btnNuevo.BackColor             = Color.RoyalBlue;
        btnNuevo.ForeColor             = Color.White;
        btnNuevo.FlatStyle             = FlatStyle.Flat;
        btnNuevo.Font                  = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnNuevo.Location              = new Point(12, 30);
        btnNuevo.Name                  = "btnNuevo";
        btnNuevo.Size                  = new Size(135, 45);
        btnNuevo.Text                  = "Nuevo";
        btnNuevo.UseVisualStyleBackColor = false;
        btnNuevo.Click                += BtnNuevo_Click;

        btnGuardar.BackColor             = Color.ForestGreen;
        btnGuardar.ForeColor             = Color.White;
        btnGuardar.FlatStyle             = FlatStyle.Flat;
        btnGuardar.Font                  = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnGuardar.Location              = new Point(157, 30);
        btnGuardar.Name                  = "btnGuardar";
        btnGuardar.Size                  = new Size(135, 45);
        btnGuardar.Text                  = "Guardar";
        btnGuardar.UseVisualStyleBackColor = false;
        btnGuardar.Click                += BtnGuardar_Click;

        btnActualizar.BackColor             = Color.DarkOrange;
        btnActualizar.ForeColor             = Color.White;
        btnActualizar.FlatStyle             = FlatStyle.Flat;
        btnActualizar.Font                  = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnActualizar.Location              = new Point(302, 30);
        btnActualizar.Name                  = "btnActualizar";
        btnActualizar.Size                  = new Size(145, 45);
        btnActualizar.Text                  = "Actualizar";
        btnActualizar.UseVisualStyleBackColor = false;
        btnActualizar.Click                += BtnActualizar_Click;

        btnEliminar.BackColor             = Color.Crimson;
        btnEliminar.ForeColor             = Color.White;
        btnEliminar.FlatStyle             = FlatStyle.Flat;
        btnEliminar.Font                  = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnEliminar.Location              = new Point(12, 85);
        btnEliminar.Name                  = "btnEliminar";
        btnEliminar.Size                  = new Size(135, 45);
        btnEliminar.Text                  = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = false;
        btnEliminar.Click                += BtnEliminar_Click;

        btnLimpiar.BackColor             = Color.SlateGray;
        btnLimpiar.ForeColor             = Color.White;
        btnLimpiar.FlatStyle             = FlatStyle.Flat;
        btnLimpiar.Font                  = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnLimpiar.Location              = new Point(157, 85);
        btnLimpiar.Name                  = "btnLimpiar";
        btnLimpiar.Size                  = new Size(135, 45);
        btnLimpiar.Text                  = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = false;
        btnLimpiar.Click                += BtnLimpiar_Click;

        btnMostrarTodos.BackColor             = Color.Teal;
        btnMostrarTodos.ForeColor             = Color.White;
        btnMostrarTodos.FlatStyle             = FlatStyle.Flat;
        btnMostrarTodos.Font                  = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnMostrarTodos.Location              = new Point(302, 85);
        btnMostrarTodos.Name                  = "btnMostrarTodos";
        btnMostrarTodos.Size                  = new Size(145, 45);
        btnMostrarTodos.Text                  = "Mostrar Todos";
        btnMostrarTodos.UseVisualStyleBackColor = false;
        btnMostrarTodos.Click                += BtnMostrarTodos_Click;

        // Área de estado / mensajes
        lblEstado.AutoSize  = false;
        lblEstado.Font      = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        lblEstado.Location  = new Point(12, 145);
        lblEstado.Name      = "lblEstado";
        lblEstado.Size      = new Size(435, 95);
        lblEstado.Text      = string.Empty;
        lblEstado.TextAlign = ContentAlignment.MiddleCenter;

        // dgvProductos
        dgvProductos.AllowUserToAddRows          = false;
        dgvProductos.AllowUserToDeleteRows       = false;
        dgvProductos.AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProductos.BackgroundColor             = Color.White;
        dgvProductos.BorderStyle                 = BorderStyle.Fixed3D;
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProductos.Location                    = new Point(12, 395);
        dgvProductos.MultiSelect                 = false;
        dgvProductos.Name                        = "dgvProductos";
        dgvProductos.ReadOnly                    = true;
        dgvProductos.RowHeadersWidth             = 45;
        dgvProductos.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        dgvProductos.Size                        = new Size(920, 255);
        dgvProductos.TabIndex                    = 12;
        dgvProductos.CellClick                  += DgvProductos_CellClick;

        // MainForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode       = AutoScaleMode.Font;
        ClientSize          = new Size(952, 665);
        Controls.Add(dgvProductos);
        Controls.Add(gbAcciones);
        Controls.Add(gbBusqueda);
        Controls.Add(gbDatos);
        Controls.Add(lblTitulo);
        MinimumSize   = new Size(968, 700);
        Name          = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text          = "Electrodomésticos CRUD - ADO.NET";
        Load         += MainForm_Load;

        gbDatos.ResumeLayout(false);
        gbDatos.PerformLayout();
        gbBusqueda.ResumeLayout(false);
        gbBusqueda.PerformLayout();
        gbAcciones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Label           lblTitulo;
    private GroupBox        gbDatos;
    private Label           lblId;
    private Label           lblIdValor;
    private Label           lblCodigo;
    private TextBox         txtCodigo;
    private Label           lblNombre;
    private TextBox         txtNombre;
    private Label           lblCategoria;
    private ComboBox        cboCategoria;
    private Label           lblMarca;
    private ComboBox        cboMarca;
    private Label           lblPrecio;
    private TextBox         txtPrecio;
    private Label           lblStock;
    private TextBox         txtStock;
    private Label           lblDescripcion;
    private TextBox         txtDescripcion;
    private Label           lblFechaIngreso;
    private DateTimePicker  dtpFechaIngreso;
    private GroupBox        gbBusqueda;
    private Label           lblBuscar;
    private TextBox         txtBuscar;
    private Button          btnBuscar;
    private GroupBox        gbAcciones;
    private Button          btnNuevo;
    private Button          btnGuardar;
    private Button          btnActualizar;
    private Button          btnEliminar;
    private Button          btnLimpiar;
    private Button          btnMostrarTodos;
    private Label           lblEstado;
    private DataGridView    dgvProductos;
}
