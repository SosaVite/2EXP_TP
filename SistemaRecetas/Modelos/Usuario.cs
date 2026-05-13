using System;
using System.Collections.Generic;

namespace SistemaRecetas.Modelos {
    public class Usuario {
        public string Nombre { get; set; }
        public Dictionary<string, List<Receta>> LibrosRecetas { get; set; }

        public Usuario(string nombre) {
            Nombre = nombre;
            LibrosRecetas = new Dictionary<string, List<Receta>>();
        }

        public void CrearLibroRecetas(string nombreLibro) {
            if (LibrosRecetas.ContainsKey(nombreLibro))
                throw new InvalidOperationException($"El libro '{nombreLibro}' ya existe.");

            LibrosRecetas[nombreLibro] = new List<Receta>();
        }

        public void AgregarRecetaALibro(string nombreLibro, Receta receta) {
            if (!LibrosRecetas.TryGetValue(nombreLibro, out var lista))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");

            lista.Add(receta);
        }

        public void EliminarLibro(string nombreLibro) {
            if (LibrosRecetas.ContainsKey(nombreLibro))
                LibrosRecetas.Remove(nombreLibro);
        }

        public List<Receta> ObtenerLibro(string nombreLibro) {
            if (LibrosRecetas.TryGetValue(nombreLibro, out var lista))
                return lista;
            return null;
        }

        public int ContarRecetas() {
            int total = 0;
            foreach (var libro in LibrosRecetas.Values)
                total += libro.Count;
            return total;
        }

        public void MostrarLibros() {
            if (LibrosRecetas.Count == 0) {
                Console.WriteLine("No tienes libros de recetas.");
                return;
            }

            foreach (var libro in LibrosRecetas) {
                Console.WriteLine($"\n📖 Libro: {libro.Key} ({libro.Value.Count} recetas)");
                if (libro.Value.Count == 0) {
                    Console.WriteLine("   (Vacío)");
                } else {
                    foreach (var receta in libro.Value)
                        Console.WriteLine($"   - {receta.ToString()}");
                }
            }
        }
    }
}