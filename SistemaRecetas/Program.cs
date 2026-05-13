using System;
using System.Collections.Generic;
using SistemaRecetas.Gestores;
using SistemaRecetas.Modelos;
using SistemaRecetas.Servicios;

namespace SistemaRecetas {
    class Program {
        static void Main(string[] args) {
            // === Inicialización ===
            var gestor = new GestorRecetas();
            var exportador = new ExportadorTxt();
            var servicio = new ServicioRecetas(gestor, exportador);

            // === 8 recetas de ejemplo ===
            gestor.AgregarReceta(new Receta("Paella", "Chef Ramírez", 45));
            gestor.AgregarReceta(new Receta("Tacos", "Chef López", 30));
            gestor.AgregarReceta(new Receta("Risotto", "Chef Rossi", 50));
            gestor.AgregarReceta(new Receta("Ceviche", "Chef Pérez", 20));
            gestor.AgregarReceta(new Receta("Ramen", "Chef Tanaka", 90));
            gestor.AgregarReceta(new Receta("Guacamole", "Chef Hernández", 10));
            gestor.AgregarReceta(new Receta("Croissant", "Chef Dupont", 120));
            gestor.AgregarReceta(new Receta("Tiramisu", "Chef Bianchi", 40));

            Console.WriteLine("SISTEMA DE GESTIÓN DE RECETAS DE COCINA\n");

            // === Registro de Usuario ===
            Console.WriteLine("--- REGISTRO DE USUARIO ---");
            Console.Write("Por favor, ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();
            var usuario = servicio.RegistrarUsuario(nombreUsuario);
            Console.WriteLine($"Usuario '{nombreUsuario}' registrado.");
            Console.WriteLine($"¡Bienvenido/a, {nombreUsuario}!\n");

            Console.Write("Ingrese un nombre para su primer libro de recetas: ");
            string primerLibro = Console.ReadLine();
            usuario.CrearLibroRecetas(primerLibro);
            Console.WriteLine($"Libro '{primerLibro}' creado exitosamente.\n");

            string libroActual = primerLibro;
            bool salir = false;

            // === Menú Principal ===
            while (!salir) {
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine($"Libro actual: '{libroActual}' ({usuario.ObtenerLibro(libroActual)?.Count ?? 0} recetas)\n");
                Console.WriteLine("  1. Mostrar Recetas disponibles");
                Console.WriteLine("  2. Ordenar libro actual (QuickSort o MergeSort)");
                Console.WriteLine("  3. Búsqueda binaria en catálogo");
                Console.WriteLine("  4. Crear nuevo libro de recetas");
                Console.WriteLine("  5. Cambiar de libro actual");
                Console.WriteLine("  6. Ver mis libros");
                Console.WriteLine("  7. Exportar mis libros a archivo .txt");
                Console.WriteLine("  8. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int opcion)) {
                    Console.WriteLine("Opción no válida.");
                    continue;
                }

                switch (opcion) {
                    case 1:
                        MostrarRecetasDisponibles(gestor);
                        break;
                    case 2:
                        OrdenarLibroActual(servicio, usuario, libroActual);
                        break;
                    case 3:
                        BusquedaBinariaEnCatalogo(gestor, usuario, libroActual);
                        break;
                    case 4:
                        libroActual = CrearNuevoLibro(usuario, libroActual);
                        break;
                    case 5:
                        libroActual = CambiarDeLibro(usuario, libroActual);
                        break;
                    case 6:
                        usuario.MostrarLibros();
                        break;
                    case 7:
                        ExportarLibros(exportador, usuario);
                        break;
                    case 8:
                        salir = true;
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void MostrarRecetasDisponibles(GestorRecetas gestor) {
            Console.WriteLine("\n--- RECETAS DISPONIBLES ---");
            if (gestor.RecetasDisponibles.Count == 0) {
                Console.WriteLine("No hay recetas disponibles.");
                return;
            }
            for (int i = 0; i < gestor.RecetasDisponibles.Count; i++)
                Console.WriteLine($"  {i + 1}. {gestor.RecetasDisponibles[i].ToString()}");
        }

        static void OrdenarLibroActual(ServicioRecetas servicio, Usuario usuario, string libroActual) {
            Console.Write("Elija algoritmo (quick/merge): ");
            string tipo = Console.ReadLine();

            var libro = usuario.ObtenerLibro(libroActual);
            if (libro == null || libro.Count == 0) {
                Console.WriteLine("El libro está vacío. No hay nada que ordenar.");
                return;
            }

            if (string.Equals(tipo, "quick", StringComparison.OrdinalIgnoreCase)) {
                servicio.Gestor.QuickSort(libro);
                Console.WriteLine("✓ Libro ordenado con QuickSort.");
            } else if (string.Equals(tipo, "merge", StringComparison.OrdinalIgnoreCase)) {
                var ordenada = servicio.Gestor.MergeSort(libro);
                usuario.LibrosRecetas[libroActual] = ordenada;
                Console.WriteLine("✓ Libro ordenado con MergeSort.");
            } else {
                Console.WriteLine("Algoritmo no válido.");
                return;
            }

            int totalMinutos = 0;
            foreach (var r in usuario.ObtenerLibro(libroActual))
                totalMinutos += r.TiempoMinutos;

            Console.WriteLine($"\nTiempo total de recetas en '{libroActual}': {totalMinutos} minutos");
            Console.WriteLine("Recetas ordenadas:");
            foreach (var r in usuario.ObtenerLibro(libroActual))
                Console.WriteLine($"   - {r.ToString()}");
        }

        static void BusquedaBinariaEnCatalogo(GestorRecetas gestor, Usuario usuario, string libroActual) {
            Console.Write("Ingrese el nombre exacto de la receta a buscar: ");
            string nombre = Console.ReadLine();

            int indice = gestor.BusquedaBinaria(nombre);

            if (indice == -1) {
                Console.WriteLine($"No se encontró la receta '{nombre}' en el catálogo.");
                return;
            }

            Console.WriteLine("\nReceta encontrada:");
            for (int i = 0; i < gestor.RecetasDisponibles.Count; i++)
                Console.WriteLine($"  {i + 1}. {gestor.RecetasDisponibles[i].ToString()}");

            Console.Write($"\nIngrese el índice de la receta para agregarla a '{libroActual}' (0 para cancelar): ");
            if (int.TryParse(Console.ReadLine(), out int indiceElegido)) {
                if (indiceElegido == 0) {
                    Console.WriteLine("Operación cancelada.");
                    return;
                }
                if (indiceElegido >= 1 && indiceElegido <= gestor.RecetasDisponibles.Count) {
                    var receta = gestor.RecetasDisponibles[indiceElegido - 1];
                    usuario.AgregarRecetaALibro(libroActual, receta);
                    Console.WriteLine($"✓ Receta '{receta.Nombre}' agregada a '{libroActual}'.");
                } else {
                    Console.WriteLine("Índice fuera de rango.");
                }
            }
        }

        static string CrearNuevoLibro(Usuario usuario, string libroActual) {
            Console.Write("Ingrese el nombre del nuevo libro: ");
            string nuevo = Console.ReadLine();
            try {
                usuario.CrearLibroRecetas(nuevo);
                Console.WriteLine($"✓ Libro '{nuevo}' creado.");
                return nuevo;
            } catch (InvalidOperationException ex) {
                Console.WriteLine($"Error: {ex.Message}");
                return libroActual;
            }
        }

        static string CambiarDeLibro(Usuario usuario, string libroActual) {
            if (usuario.LibrosRecetas.Count == 0) {
                Console.WriteLine("No tienes libros.");
                return libroActual;
            }

            Console.WriteLine("\nLibros disponibles:");
            foreach (var nombre in usuario.LibrosRecetas.Keys)
                Console.WriteLine($"  - {nombre}");

            Console.Write("Ingrese el nombre del libro al que desea cambiar: ");
            string elegido = Console.ReadLine();

            if (usuario.LibrosRecetas.ContainsKey(elegido)) {
                Console.WriteLine($"✓ Libro actual cambiado a '{elegido}'.");
                return elegido;
            }
            Console.WriteLine("El libro no existe.");
            return libroActual;
        }

        static void ExportarLibros(ExportadorTxt exportador, Usuario usuario) {
            string ruta = $"LibrosRecetas_{usuario.Nombre}.txt";
            exportador.ExportarATxt(usuario, ruta);
            Console.WriteLine($"✓ Archivo exportado a: {ruta}");
        }
    }
}