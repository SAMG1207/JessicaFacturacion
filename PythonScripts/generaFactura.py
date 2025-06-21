from reportlab.lib.pagesizes import A4
from reportlab.lib.units import mm
from reportlab.pdfgen import canvas
import sys
import json
from datetime import datetime

def generar_factura(datos, output_pdf):
    c = canvas.Canvas(output_pdf, pagesize=A4)
    width, height = A4

    c.setFont("Helvetica-Bold", 20)
    c.drawCentredString(width / 2, height - 40, "Factura")

    c.setFont("Helvetica", 12)
    c.drawString(40, height - 80, f"Nº Factura: {datos['CodigoFactura']}")
    c.drawString(40, height - 100, f"Cliente: {datos['NombreCliente']}")
    c.drawString(40, height - 120, f"DNI: {datos['DNICliente']}")
    c.drawString(40, height - 140, f"Fecha: {datos['FechaFactura']}")

    c.drawString(40, height - 180, "Concepto:")
    c.drawString(120, height - 180, datos['Concepto'])

    # Tabla simple
    c.drawString(40, height - 220, "Base Imponible:")
    c.drawString(180, height - 220, f"{datos['BaseImponible']:.2f} €")

    c.drawString(40, height - 240, "Impuesto (%):")
    c.drawString(180, height - 240, f"{datos['Impuesto']}%")

    c.drawString(40, height - 260, "Total:")
    c.drawString(180, height - 260, f"{datos['Total']:.2f} €")

    c.drawString(40, height - 300, "Gracias por su confianza.")
    c.drawString(40, height - 320, "Generado automáticamente por el sistema.")

    c.showPage()
    c.save()

if __name__ == "__main__":
    json_path = sys.argv[1]  # Ruta archivo JSON con datos
    pdf_path = sys.argv[2]   # Ruta salida PDF

    with open(json_path, "r", encoding="utf-8") as f:
        datos = json.load(f)

    # En caso de que la fecha venga en formato string, se deja tal cual o se convierte
    if 'FechaFactura' in datos:
        try:
            # Intentamos formatear la fecha para PDF
            fecha_dt = datetime.fromisoformat(datos['FechaFactura'])
            datos['FechaFactura'] = fecha_dt.strftime("%d/%m/%Y")
        except:
            pass

    generar_factura(datos, pdf_path)
    print(f"Factura generada en {pdf_path}")
