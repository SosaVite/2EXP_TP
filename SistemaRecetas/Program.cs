using SistemaRecetas.Recetas;
using SistemaRecetas.Gestores;
using SistemaRecetas.Modelos;
using SistemaRecetas.Servicios;

namespace SistemaRecetas {
    class Program {
        // === Paleta de colores temática de cocina ===
        static readonly ConsoleColor ColorTitulo = ConsoleColor.Yellow;
        static readonly ConsoleColor ColorExito = ConsoleColor.Green;
        static readonly ConsoleColor ColorError = ConsoleColor.Red;
        static readonly ConsoleColor ColorInfo = ConsoleColor.Cyan;
        static readonly ConsoleColor ColorMenu = ConsoleColor.White;
        static readonly ConsoleColor ColorEntrada = ConsoleColor.Magenta;
        static readonly ConsoleColor ColorReceta = ConsoleColor.DarkYellow;
        static readonly ConsoleColor ColorPais = ConsoleColor.DarkCyan;

        static void Main(string[] args) {
            // Configurar consola
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "🍳 Sistema de Gestión de Recetas de Cocina";

            // === Inicialización ===
            var gestor = new GestorRecetas();
            var exportador = new ExportadorTxt();
            var servicio = new ServicioRecetas(gestor, exportador);

            // === Cargar catálogo inicial de recetas ===
            ListaRecetas.CargarEn(gestor);

            // === Encabezado de bienvenida ===
            MostrarEncabezado();

            // === Registro de Usuario ===
            EscribirColor("\n--- REGISTRO DE USUARIO ---\n", ColorTitulo);
            string nombreUsuario = LeerEntradaNoVacia("Por favor, ingrese su nombre de usuario: ");
            var usuario = servicio.RegistrarUsuario(nombreUsuario);
            EscribirColor($"✓ Usuario '{nombreUsuario}' registrado.\n", ColorExito);
            EscribirColor($"¡Bienvenido/a, {nombreUsuario}! 🍴\n\n", ColorInfo);

            string primerLibro = LeerEntradaNoVacia("Ingrese un nombre para su primer libro de recetas: ");
            usuario.CrearLibroRecetas(primerLibro);
            EscribirColor($"✓ Libro '{primerLibro}' creado exitosamente.\n", ColorExito);

            string libroActual = primerLibro;
            bool salir = false;

            // === Menú Principal ===
            while (!salir) {
                MostrarMenu(usuario, libroActual);
                string entrada = LeerConPrompt("Seleccione una opción: ");

                if (!int.TryParse(entrada, out int opcion)) {
                    EscribirColor("⚠️ Opción no válida.\n", ColorError);
                    continue;
                }

                switch (opcion) {
                    case 1: MostrarRecetasDisponibles(gestor); break;
                    case 2: OrdenarLibroActual(servicio, usuario, libroActual); break;
                    case 3: BusquedaBinariaEnCatalogo(gestor, usuario, libroActual); break;
                    case 4: libroActual = CrearNuevoLibro(usuario, libroActual); break;
                    case 5: libroActual = CambiarDeLibro(usuario, libroActual); break;
                    case 6: MostrarLibrosUsuario(usuario); break;
                    case 7: ExportarLibros(exportador, usuario); break;
                    case 8:
                        salir = true;
                        EscribirColor("\n¡Hasta luego! Buen provecho 🍽️\n", ColorTitulo);
                        break;
                    default: EscribirColor("⚠️ Opción no válida.\n", ColorError); break;
                }
            }
        }

        static void EscribirColor(string texto, ConsoleColor color, bool salto = false) {
            var colorActual = Console.ForegroundColor;
            Console.ForegroundColor = color;

            if (salto)
                Console.WriteLine(texto);
            else
                Console.Write(texto);

            Console.ForegroundColor = colorActual;
        }

        static string LeerConPrompt(string mensaje) {
            EscribirColor(mensaje, ColorEntrada);
            return Console.ReadLine();
        }

        static string LeerEntradaNoVacia(string mensaje) {
            while (true) {
                string entrada = LeerConPrompt(mensaje);

                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada.Trim();

                EscribirColor("⚠️ Error: El campo no puede estar vacío. Intente de nuevo.\n", ColorError);
            }
        }

        static void ImprimirRecetasNumeradas(IList<Receta> recetas) {
            for (int i = 0; i < recetas.Count; i++)
                EscribirColor($"  {i + 1,3}. {recetas[i]}\n", ColorReceta);
        }

        static void MostrarEncabezado() {
            EscribirColor("╔══════════════════════════════════════════════════════════╗\n", ColorTitulo);
            EscribirColor("║                                                          ║\n", ColorTitulo);
            EscribirColor("║   🍳  SISTEMA DE GESTIÓN DE RECETAS DE COCINA  🍳        ║\n", ColorTitulo);
            EscribirColor("║                                                          ║\n", ColorTitulo);
            EscribirColor("╚══════════════════════════════════════════════════════════╝\n", ColorTitulo);
        }

        static void MostrarMenu(Usuario usuario, string libroActual) {
            int totalRecetas = usuario.ObtenerLibro(libroActual)?.Count ?? 0;

            Console.WriteLine();

            EscribirColor("╔══════════════ MENÚ PRINCIPAL ══════════════╗\n", ColorTitulo);

            EscribirColor(
                $"  📖 Libro actual: '{libroActual}' ({totalRecetas} recetas)\n",
                ColorInfo
            );

            EscribirColor("╠════════════════════════════════════════════╣\n", ColorTitulo);

            EscribirColor("  1. 📋 Mostrar Recetas disponibles\n", ColorMenu);
            EscribirColor("  2. 🔄 Ordenar libro actual (QuickSort/MergeSort)\n", ColorMenu);
            EscribirColor("  3. 🔍 Búsqueda binaria en catálogo\n", ColorMenu);
            EscribirColor("  4. ➕ Crear nuevo libro de recetas\n", ColorMenu);
            EscribirColor("  5. 🔀 Cambiar de libro actual\n", ColorMenu);
            EscribirColor("  6. 📚 Ver mis libros\n", ColorMenu);
            EscribirColor("  7. 💾 Exportar mis libros a archivo .txt\n", ColorMenu);
            EscribirColor("  8. 🚪 Salir\n", ColorMenu);

            EscribirColor("╚════════════════════════════════════════════╝\n", ColorTitulo);
        }

        // === FUNCIONES DEL MENÚ ===

        static void MostrarRecetasDisponibles(GestorRecetas gestor) {
            EscribirColor("\n--- 📋 RECETAS DISPONIBLES ---\n", ColorTitulo);

            if (gestor.RecetasDisponibles.Count == 0) {
                EscribirColor("No hay recetas disponibles.\n", ColorError);
                return;
            }

            ImprimirRecetasNumeradas(gestor.RecetasDisponibles);
            EscribirColor($"\nTotal: {gestor.RecetasDisponibles.Count} recetas en el catálogo.\n", ColorInfo);
        }

        static void OrdenarLibroActual(ServicioRecetas servicio, Usuario usuario, string libroActual) {
            string tipo = LeerConPrompt("Elija algoritmo (quick/merge): ");

            var libro = usuario.ObtenerLibro(libroActual);
            if (libro == null || libro.Count == 0) {
                EscribirColor("⚠️ El libro está vacío. No hay nada que ordenar.\n", ColorError);
                return;
            }

            if (string.Equals(tipo, "quick", StringComparison.OrdinalIgnoreCase)) {
                servicio.Gestor.QuickSort(libro);
                EscribirColor("✓ Libro ordenado con QuickSort.\n", ColorExito);
            } else if (string.Equals(tipo, "merge", StringComparison.OrdinalIgnoreCase)) {
                var ordenada = servicio.Gestor.MergeSort(libro);
                usuario.LibrosRecetas[libroActual] = ordenada;
                EscribirColor("✓ Libro ordenado con MergeSort.\n", ColorExito);
            } else {
                EscribirColor("⚠️ Algoritmo no válido. Use 'quick' o 'merge'.\n", ColorError);
                return;
            }

            var libroOrdenado = usuario.ObtenerLibro(libroActual);
            int totalMinutos = libroOrdenado.Sum(r => r.TiempoMinutos);

            EscribirColor($"\n⏱️ Tiempo total de recetas en '{libroActual}': {totalMinutos} minutos\n", ColorInfo);
            EscribirColor("Recetas ordenadas:\n", ColorTitulo);

            Console.ForegroundColor = ColorReceta;
            foreach (var r in libroOrdenado)
                Console.WriteLine($"   - {r}");
            Console.ResetColor();
        }

        static void BusquedaBinariaEnCatalogo(GestorRecetas gestor, Usuario usuario, string libroActual) {
            string nombre = LeerEntradaNoVacia("Ingrese el nombre exacto de la receta a buscar: ");

            int indice = gestor.BusquedaBinaria(nombre);
            if (indice == -1) {
                EscribirColor($"✗ No se encontró la receta '{nombre}' en el catálogo.\n", ColorError);
                return;
            }

            EscribirColor("\n✓ Receta encontrada. Catálogo completo:\n", ColorExito);
            ImprimirRecetasNumeradas(gestor.RecetasDisponibles);

            string respuesta = LeerConPrompt($"\nIngrese el índice de la receta para agregarla a '{libroActual}' (0 para cancelar): ");

            if (int.TryParse(respuesta, out int indiceElegido)) {
                if (indiceElegido == 0) {
                    EscribirColor("Operación cancelada.\n", ColorInfo);
                    return;
                }
                if (indiceElegido >= 1 && indiceElegido <= gestor.RecetasDisponibles.Count) {
                    var receta = gestor.RecetasDisponibles[indiceElegido - 1];
                    usuario.AgregarRecetaALibro(libroActual, receta);
                    EscribirColor($"✓ Receta '{receta.Nombre}' agregada a '{libroActual}'.\n", ColorExito);
                } else {
                    EscribirColor("⚠️ Índice fuera de rango.\n", ColorError);
                }
            }
        }

        static string CrearNuevoLibro(Usuario usuario, string libroActual) {
            string nuevo = LeerEntradaNoVacia("Ingrese el nombre del nuevo libro: ");
            try {
                usuario.CrearLibroRecetas(nuevo);
                EscribirColor($"✓ Libro '{nuevo}' creado.\n", ColorExito);
                return nuevo;
            } catch (InvalidOperationException ex) {
                EscribirColor($"✗ Error: {ex.Message}\n", ColorError);
                return libroActual;
            }
        }

        static string CambiarDeLibro(Usuario usuario, string libroActual) {
            if (usuario.LibrosRecetas.Count == 0) {
                EscribirColor("⚠️ No tienes libros.\n", ColorError);
                return libroActual;
            }

            EscribirColor("\n📚 Libros disponibles:\n", ColorTitulo);
            Console.ForegroundColor = ColorInfo;
            foreach (var nombre in usuario.LibrosRecetas.Keys)
                Console.WriteLine($"  - {nombre}");
            Console.ResetColor();

            string elegido = LeerEntradaNoVacia("Ingrese el nombre del libro al que desea cambiar: ");

            if (usuario.LibrosRecetas.ContainsKey(elegido)) {
                EscribirColor($"✓ Libro actual cambiado a '{elegido}'.\n", ColorExito);
                return elegido;
            }
            EscribirColor("✗ El libro no existe.\n", ColorError);
            return libroActual;
        }

        static void MostrarLibrosUsuario(Usuario usuario) {
            if (usuario.LibrosRecetas.Count == 0) {
                EscribirColor("⚠️ No tienes libros de recetas.\n", ColorError);
                return;
            }

            EscribirColor("\n--- 📚 MIS LIBROS DE RECETAS ---\n", ColorTitulo);

            foreach (var libro in usuario.LibrosRecetas) {
                EscribirColor($"\n📖 Libro: {libro.Key} ({libro.Value.Count} recetas)\n", ColorPais);

                if (libro.Value.Count == 0) {
                    EscribirColor("   (Vacío)\n", ColorError);
                } else {
                    Console.ForegroundColor = ColorReceta;
                    foreach (var receta in libro.Value)
                        Console.WriteLine($"   - {receta}");
                    Console.ResetColor();
                }
            }
        }

        static void ExportarLibros(ExportadorTxt exportador, Usuario usuario) {
            string ruta = $"LibrosRecetas_{usuario.Nombre}.txt";
            exportador.ExportarATxt(usuario, ruta);
            EscribirColor($"✓ Archivo exportado a: {ruta}\n", ColorExito);
        }
    }
}