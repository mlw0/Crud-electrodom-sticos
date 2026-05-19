using SistemaEstudiantes.Models;
using SistemaEstudiantes.Repositories;

namespace SistemaEstudiantes.Forms;

public partial class MainForm : Form
{
    private readonly ProductoRepository _repo = new();
    private int _idSeleccionado = 0;

    public MainForm() => InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e)
    {
        CargarCombos();
        ConfigurarGrid();
        CargarProductos();
    }

    private void CargarCombos()
    {
        cboCategoria.Items.AddRange(new string[]
        {
            "Refrigeradoras",
            "Lavadoras",
            "Secadoras",
            "Televisores",
            "Microondas",
            "Cocinas",
            "Lavavajillas",
            "Aires Acondicionados",
            "Aspiradoras",
            "Pequeños Electrodomésticos"
        });

        cboMarca.Items.AddRange(new string[]
        {
            "Samsung", "LG", "Mabe", "Indurama",
            "Whirlpool", "Bosch", "Panasonic", "Sony",
            "Electrolux", "Oster"
        });
    }

    private void ConfigurarGrid()
    {
        dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
        dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvProductos.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgvProductos.EnableHeadersVisualStyles               = false;
        dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.MistyRose;
    }

    private void CargarProductos()
    {
        try
        {
            var lista = _repo.ObtenerTodos();
            MostrarEnGrid(lista);
            MostrarEstado($"Total productos: {lista.Count}", false);
        }
        catch (Exception ex)
        {
            MostrarEstado($"Error al cargar: {ex.Message}", true);
        }
    }

    private void MostrarEnGrid(List<Producto> lista)
    {
        var tabla = new System.Data.DataTable();
        tabla.Columns.Add("Id",            typeof(int));
        tabla.Columns.Add("Código",        typeof(string));
        tabla.Columns.Add("Nombre",        typeof(string));
        tabla.Columns.Add("Categoría",     typeof(string));
        tabla.Columns.Add("Marca",         typeof(string));
        tabla.Columns.Add("Precio (USD)",  typeof(string));
        tabla.Columns.Add("Stock",         typeof(int));
        tabla.Columns.Add("Fecha Ingreso", typeof(string));

        foreach (var p in lista)
            tabla.Rows.Add(
                p.Id, p.Codigo, p.Nombre, p.Categoria, p.Marca,
                p.Precio.ToString("N2"), p.Stock,
                p.FechaIngreso.ToString("dd/MM/yyyy"));

        dgvProductos.DataSource = tabla;

        if (dgvProductos.Columns.Count > 0)
            dgvProductos.Columns["Id"]!.Visible = false;
    }

    private void BtnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
        txtCodigo.Focus();
        MostrarEstado("Complete los campos y presione Guardar para registrar un nuevo producto.", false);
    }

    private void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;
        try
        {
            _repo.Insertar(ObtenerProductoDelFormulario());
            CargarProductos();
            LimpiarFormulario();
            MostrarEstado("Producto registrado exitosamente.", false);
        }
        catch (Exception ex)
        {
            MostrarEstado($"Error al guardar: {ex.Message}", true);
        }
    }

    private void BtnActualizar_Click(object sender, EventArgs e)
    {
        if (_idSeleccionado == 0)
        {
            MostrarEstado("Seleccione un producto de la lista para actualizar.", true);
            return;
        }
        if (!ValidarFormulario()) return;
        try
        {
            var p = ObtenerProductoDelFormulario();
            p.Id = _idSeleccionado;
            _repo.Actualizar(p);
            CargarProductos();
            LimpiarFormulario();
            MostrarEstado("Producto actualizado exitosamente.", false);
        }
        catch (Exception ex)
        {
            MostrarEstado($"Error al actualizar: {ex.Message}", true);
        }
    }

    private void BtnEliminar_Click(object sender, EventArgs e)
    {
        if (_idSeleccionado == 0)
        {
            MostrarEstado("Seleccione un producto de la lista para eliminar.", true);
            return;
        }

        var resp = MessageBox.Show(
            $"¿Eliminar el producto?\n\n[{txtCodigo.Text}]  {txtNombre.Text}",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (resp != DialogResult.Yes) return;

        try
        {
            _repo.Eliminar(_idSeleccionado);
            CargarProductos();
            LimpiarFormulario();
            MostrarEstado("Producto eliminado exitosamente.", false);
        }
        catch (Exception ex)
        {
            MostrarEstado($"Error al eliminar: {ex.Message}", true);
        }
    }

    private void BtnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
        MostrarEstado(string.Empty, false);
    }

    private void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtBuscar.Text))
        {
            CargarProductos();
            return;
        }
        try
        {
            var resultado = _repo.Buscar(txtBuscar.Text.Trim());
            MostrarEnGrid(resultado);
            MostrarEstado($"Se encontraron {resultado.Count} producto(s).", false);
        }
        catch (Exception ex)
        {
            MostrarEstado($"Error en búsqueda: {ex.Message}", true);
        }
    }

    private void BtnMostrarTodos_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        CargarProductos();
    }

    private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var idVal = dgvProductos.Rows[e.RowIndex].Cells["Id"].Value;
        if (idVal == null || idVal == DBNull.Value) return;

        _idSeleccionado = Convert.ToInt32(idVal);
        try
        {
            var p = _repo.ObtenerPorId(_idSeleccionado);
            if (p != null) CargarFormulario(p);
        }
        catch (Exception ex)
        {
            MostrarEstado($"Error al cargar producto: {ex.Message}", true);
        }
    }

    private void CargarFormulario(Producto p)
    {
        lblIdValor.Text       = p.Id.ToString();
        txtCodigo.Text        = p.Codigo;
        txtNombre.Text        = p.Nombre;
        cboCategoria.Text     = p.Categoria;
        cboMarca.Text         = p.Marca;
        txtPrecio.Text        = p.Precio.ToString("N2");
        txtStock.Text         = p.Stock.ToString();
        txtDescripcion.Text   = p.Descripcion;
        dtpFechaIngreso.Value = p.FechaIngreso == DateTime.MinValue ? DateTime.Now : p.FechaIngreso;
    }

    private Producto ObtenerProductoDelFormulario() => new()
    {
        Codigo       = txtCodigo.Text.Trim().ToUpper(),
        Nombre       = txtNombre.Text.Trim(),
        Categoria    = cboCategoria.Text.Trim(),
        Marca        = cboMarca.Text.Trim(),
        Precio       = decimal.Parse(txtPrecio.Text.Trim()),
        Stock        = int.TryParse(txtStock.Text.Trim(), out int s) ? s : 0,
        Descripcion  = txtDescripcion.Text.Trim(),
        FechaIngreso = dtpFechaIngreso.Value.Date
    };

    private void LimpiarFormulario()
    {
        _idSeleccionado      = 0;
        lblIdValor.Text      = "Nuevo";
        txtCodigo.Clear();
        txtNombre.Clear();
        cboCategoria.SelectedIndex = -1;
        cboMarca.SelectedIndex     = -1;
        cboMarca.Text              = string.Empty;
        txtPrecio.Clear();
        txtStock.Text        = "0";
        txtDescripcion.Clear();
        dtpFechaIngreso.Value = DateTime.Now;
    }

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtCodigo.Text))
        {
            MostrarEstado("El campo Código es obligatorio.", true);
            txtCodigo.Focus(); return false;
        }
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MostrarEstado("El campo Nombre es obligatorio.", true);
            txtNombre.Focus(); return false;
        }
        if (cboCategoria.SelectedIndex < 0)
        {
            MostrarEstado("Debe seleccionar una Categoría.", true);
            cboCategoria.Focus(); return false;
        }
        if (string.IsNullOrWhiteSpace(cboMarca.Text))
        {
            MostrarEstado("El campo Marca es obligatorio.", true);
            cboMarca.Focus(); return false;
        }
        if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
        {
            MostrarEstado("El Precio debe ser un número decimal positivo (ej: 199.99).", true);
            txtPrecio.Focus(); return false;
        }
        if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
        {
            MostrarEstado("El Stock debe ser un número entero mayor o igual a 0.", true);
            txtStock.Focus(); return false;
        }
        return true;
    }

    private void MostrarEstado(string mensaje, bool esError)
    {
        lblEstado.Text      = mensaje;
        lblEstado.ForeColor = esError ? Color.Crimson : Color.DarkGreen;
    }
}
