using SistemaEstudiantes.Data;
using SistemaEstudiantes.Forms;

namespace SistemaEstudiantes;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            new DatabaseHelper().InitializeDatabase();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"No se pudo conectar a SQL Server.\n\n{ex.Message}\n\n" +
                "Verifique:\n" +
                "  • SQL Server está en ejecución\n" +
                "  • La autenticación de modo mixto está habilitada\n" +
                "  • Credenciales: sa / 12345678\n" +
                "  • Servidor: localhost (o localhost\\SQLEXPRESS)",
                "Error de conexión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        Application.Run(new MainForm());
    }
}
