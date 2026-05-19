using Microsoft.Data.SqlClient;
using SistemaEstudiantes.Data;
using SistemaEstudiantes.Models;

namespace SistemaEstudiantes.Repositories;

public class ProductoRepository
{
    private readonly DatabaseHelper _db = new();

    public List<Producto> ObtenerTodos()
    {
        var lista = new List<Producto>();
        using var conn = _db.GetConnection();
        conn.Open();

        const string sql = @"
            SELECT Id, Codigo, Nombre, Categoria, Marca, Precio, Stock, Descripcion, FechaIngreso
            FROM Productos
            ORDER BY Categoria, Nombre";

        using var cmd    = new SqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(Mapear(reader));
        return lista;
    }

    public List<Producto> Buscar(string termino)
    {
        var lista = new List<Producto>();
        using var conn = _db.GetConnection();
        conn.Open();

        const string sql = @"
            SELECT Id, Codigo, Nombre, Categoria, Marca, Precio, Stock, Descripcion, FechaIngreso
            FROM Productos
            WHERE Codigo    LIKE @t
               OR Nombre    LIKE @t
               OR Categoria LIKE @t
               OR Marca     LIKE @t
            ORDER BY Categoria, Nombre";

        using var cmd    = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@t", $"%{termino}%");
        using var reader = cmd.ExecuteReader();
        while (reader.Read()) lista.Add(Mapear(reader));
        return lista;
    }

    public Producto? ObtenerPorId(int id)
    {
        using var conn = _db.GetConnection();
        conn.Open();

        const string sql = @"
            SELECT Id, Codigo, Nombre, Categoria, Marca, Precio, Stock, Descripcion, FechaIngreso
            FROM Productos WHERE Id = @id";

        using var cmd    = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);
        using var reader = cmd.ExecuteReader();
        return reader.Read() ? Mapear(reader) : null;
    }

    public void Insertar(Producto p)
    {
        using var conn = _db.GetConnection();
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            const string sql = @"
                INSERT INTO Productos
                    (Codigo, Nombre, Categoria, Marca, Precio, Stock, Descripcion, FechaIngreso)
                VALUES
                    (@codigo, @nombre, @categoria, @marca, @precio, @stock, @descripcion, @fecha)";

            using var cmd = new SqlCommand(sql, conn, tx);
            AgregarParametros(cmd, p);
            cmd.ExecuteNonQuery();
            tx.Commit();
        }
        catch { tx.Rollback(); throw; }
    }

    public void Actualizar(Producto p)
    {
        using var conn = _db.GetConnection();
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            const string sql = @"
                UPDATE Productos SET
                    Codigo       = @codigo,
                    Nombre       = @nombre,
                    Categoria    = @categoria,
                    Marca        = @marca,
                    Precio       = @precio,
                    Stock        = @stock,
                    Descripcion  = @descripcion,
                    FechaIngreso = @fecha
                WHERE Id = @id";

            using var cmd = new SqlCommand(sql, conn, tx);
            cmd.Parameters.AddWithValue("@id", p.Id);
            AgregarParametros(cmd, p);
            cmd.ExecuteNonQuery();
            tx.Commit();
        }
        catch { tx.Rollback(); throw; }
    }

    public void Eliminar(int id)
    {
        using var conn = _db.GetConnection();
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            using var cmd = new SqlCommand("DELETE FROM Productos WHERE Id = @id", conn, tx);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            tx.Commit();
        }
        catch { tx.Rollback(); throw; }
    }

    private static void AgregarParametros(SqlCommand cmd, Producto p)
    {
        cmd.Parameters.AddWithValue("@codigo",      p.Codigo);
        cmd.Parameters.AddWithValue("@nombre",      p.Nombre);
        cmd.Parameters.AddWithValue("@categoria",   p.Categoria);
        cmd.Parameters.AddWithValue("@marca",       p.Marca);
        cmd.Parameters.AddWithValue("@precio",      p.Precio);
        cmd.Parameters.AddWithValue("@stock",       p.Stock);
        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(p.Descripcion)
                                                        ? DBNull.Value : p.Descripcion);
        cmd.Parameters.AddWithValue("@fecha",       p.FechaIngreso.Date);
    }

    private static Producto Mapear(SqlDataReader r) => new()
    {
        Id           = r.GetInt32(0),
        Codigo       = r.GetString(1),
        Nombre       = r.GetString(2),
        Categoria    = r.GetString(3),
        Marca        = r.GetString(4),
        Precio       = r.GetDecimal(5),
        Stock        = r.GetInt32(6),
        Descripcion  = r.IsDBNull(7) ? string.Empty : r.GetString(7),
        FechaIngreso = r.IsDBNull(8) ? DateTime.Now  : r.GetDateTime(8)
    };
}
