using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace JessicaFacturacion.Controllers
{
    [Route("factura")] 
    public class FacturaController : Controller
    {
        [HttpGet("generarFactura/{id}")]
        public IActionResult GenerarFactura()
        {
            var factura = new
            {
                CodigoFactura = "FAC-002",
                NombreCliente = "Ana Gómez",
                DNICliente = "98765432B",
                FechaFactura = DateTime.Now.ToString("yyyy-MM-dd"),
                Concepto = "Desarrollo de software",
                BaseImponible = 2000.0,
                Impuesto = 21,
                Total = 2420.0
            };

            // Rutas relativas al proyecto
            string jsonPath = Path.Combine("PythonScripts", "factura.json");
            string pdfPath = Path.Combine("wwwroot", "pdf", "factura.pdf");
            string scriptPath = Path.Combine("PythonScripts", "generaFactura.py");

            // Guardar JSON
            System.IO.File.WriteAllText(jsonPath, JsonSerializer.Serialize(factura));

            // Ejecutar el script
            var psi = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"{scriptPath} {jsonPath} {pdfPath}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            var process = new Process { StartInfo = psi };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode != 0 || !System.IO.File.Exists(pdfPath))
                return StatusCode(500, $"Error generando PDF: {error}");

            // Devolver el PDF
            var pdfBytes = System.IO.File.ReadAllBytes(pdfPath);
            return File(pdfBytes, "application/pdf", "Factura.pdf");
        }
    }
}
