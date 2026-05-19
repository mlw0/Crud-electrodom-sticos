using Microsoft.Data.SqlClient;

namespace SistemaEstudiantes.Data;

public class DatabaseHelper
{
    private const string Server   = "localhost";
    private const string User     = "sa";
    private const string Password = "12345678";
    private const string DbName   = "ElectrodomesticosDB";

    public const string ConnectionString =
        $"Server={Server};Database={DbName};User Id={User};Password={Password};TrustServerCertificate=True;";

    private static string MasterConnection =>
        $"Server={Server};Database=master;User Id={User};Password={Password};TrustServerCertificate=True;";

    public SqlConnection GetConnection() => new SqlConnection(ConnectionString);

    public void InitializeDatabase()
    {
        using (var conn = new SqlConnection(MasterConnection))
        {
            conn.Open();
            var sql = $@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{DbName}')
                    CREATE DATABASE {DbName};";
            using var cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        using var appConn = GetConnection();
        appConn.Open();

        const string createTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Productos' AND xtype='U')
            CREATE TABLE Productos (
                Id           INT            PRIMARY KEY IDENTITY(1,1),
                Codigo       NVARCHAR(20)   NOT NULL UNIQUE,
                Nombre       NVARCHAR(150)  NOT NULL,
                Categoria    NVARCHAR(100)  NOT NULL,
                Marca        NVARCHAR(100)  NOT NULL,
                Precio       DECIMAL(10,2)  NOT NULL,
                Stock        INT            NOT NULL DEFAULT 0,
                Descripcion  NVARCHAR(300)  NULL,
                FechaIngreso DATE           NOT NULL DEFAULT GETDATE()
            );";

        using var cmdTable = new SqlCommand(createTable, appConn);
        cmdTable.ExecuteNonQuery();
    }
}
