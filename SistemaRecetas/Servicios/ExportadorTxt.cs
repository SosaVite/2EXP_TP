using System;
using System.IO;
using System.Text;
using SistemaRecetas.Interfaces;
using SistemaRecetas.Modelos;

namespace SistemaRecetas.Servicios {
    public class ExportadorTxt : IExportador {
        public void ExportarATxt(Usuario usuario, string rutaArchivo) {
            var sb = new StringBuilder();
            sb.AppendLine("===========================================");
            sb.AppendLine($"  LIBROS DE RECETAS DE: {usuario.Nombre}");
            sb.AppendLine($"  Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine("===========================================");
            sb.AppendLine();

            if (usuario.LibrosRecetas.Count == 0) {
                sb.AppendLine("(El usuario no tiene libros de recetas)");
            } else {
                foreach (var libro in usuario.LibrosRecetas) {
                    sb.AppendLine($"📖 Libro: {libro.Key}");
                    sb.AppendLine($"   Total de recetas: {libro.Value.Count}");
                    sb.AppendLine("   -----------------------------------");

                    if (libro.Value.Count == 0) {
                        sb.AppendLine("   (Sin recetas)");
                    } else {
                        int i = 1;
                        foreach (var receta in libro.Value) {
                            sb.AppendLine($"   {i}. {receta.ToString()}");
                            i++;
                        }
                    }
                    sb.AppendLine();
                }
            }

            File.WriteAllText(rutaArchivo, sb.ToString());
        }
    }
}