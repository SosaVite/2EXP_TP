using SistemaRecetas.Gestores;
using SistemaRecetas.Modelos;
using SistemaRecetas.Servicios;

namespace SistemaRecetas {
    class Program {
        static readonly ConsoleColor ColorTitulo = ConsoleColor.Yellow;        
        static readonly ConsoleColor ColorExito = ConsoleColor.Green;          
        static readonly ConsoleColor ColorError = ConsoleColor.Red;            
        static readonly ConsoleColor ColorInfo = ConsoleColor.Cyan;            
        static readonly ConsoleColor ColorMenu = ConsoleColor.White;           
        static readonly ConsoleColor ColorEntrada = ConsoleColor.Magenta;      
        static readonly ConsoleColor ColorReceta = ConsoleColor.DarkYellow;    
        static readonly ConsoleColor ColorPais = ConsoleColor.DarkCyan;        

        static void Main(string[] args) 
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "🍳 Sistema de Gestión de Recetas de Cocina";

            // === Inicialización ===
            var gestor = new GestorRecetas();
            var exportador = new ExportadorTxt();
            var servicio = new ServicioRecetas(gestor, exportador);

            // === ESPAÑA ===
            gestor.AgregarReceta(new Receta("Paella", "Chef Ramírez", 45));
            gestor.AgregarReceta(new Receta("Gazpacho", "Chef Vega", 15));
            gestor.AgregarReceta(new Receta("Tortilla Española", "Chef Sanz", 35));
            gestor.AgregarReceta(new Receta("Churros", "Chef Navarro", 25));
            gestor.AgregarReceta(new Receta("Fabada Asturiana", "Chef Aragón", 130));

            // === MÉXICO ===
            gestor.AgregarReceta(new Receta("Tacos", "Chef López", 30));
            gestor.AgregarReceta(new Receta("Guacamole", "Chef Hernández", 10));
            gestor.AgregarReceta(new Receta("Chiles en Nogada", "Chef Morales", 150));
            gestor.AgregarReceta(new Receta("Cochinita Pibil", "Chef Canul", 240));
            gestor.AgregarReceta(new Receta("Mole Poblano", "Chef Domínguez", 180));

            // === ITALIA ===
            gestor.AgregarReceta(new Receta("Risotto", "Chef Rossi", 50));
            gestor.AgregarReceta(new Receta("Tiramisu", "Chef Bianchi", 40));
            gestor.AgregarReceta(new Receta("Lasagna", "Chef Romano", 75));
            gestor.AgregarReceta(new Receta("Carbonara", "Chef Conti", 25));
            gestor.AgregarReceta(new Receta("Osso Buco", "Chef Marino", 140));

            // === PERÚ ===
            gestor.AgregarReceta(new Receta("Ceviche", "Chef Pérez", 20));
            gestor.AgregarReceta(new Receta("Lomo Saltado", "Chef Acurio", 35));
            gestor.AgregarReceta(new Receta("Aji de Gallina", "Chef Quispe", 60));
            gestor.AgregarReceta(new Receta("Causa Limeña", "Chef Salazar", 50));
            gestor.AgregarReceta(new Receta("Anticuchos", "Chef Chávez", 45));

            // === JAPÓN ===
            gestor.AgregarReceta(new Receta("Ramen", "Chef Tanaka", 90));
            gestor.AgregarReceta(new Receta("Sushi", "Chef Yamamoto", 60));
            gestor.AgregarReceta(new Receta("Tempura", "Chef Sato", 30));
            gestor.AgregarReceta(new Receta("Okonomiyaki", "Chef Watanabe", 40));
            gestor.AgregarReceta(new Receta("Gyoza", "Chef Suzuki", 35));

            // === FRANCIA ===
            gestor.AgregarReceta(new Receta("Croissant", "Chef Dupont", 120));
            gestor.AgregarReceta(new Receta("Ratatouille", "Chef Lefèvre", 65));
            gestor.AgregarReceta(new Receta("Crepas", "Chef Moreau", 20));
            gestor.AgregarReceta(new Receta("Coq au Vin", "Chef Laurent", 110));
            gestor.AgregarReceta(new Receta("Quiche Lorraine", "Chef Girard", 55));

            // === TAILANDIA ===
            gestor.AgregarReceta(new Receta("Pad Thai", "Chef Suwan", 25));
            gestor.AgregarReceta(new Receta("Tom Yum", "Chef Chaiyo", 25));
            gestor.AgregarReceta(new Receta("Curry Verde", "Chef Anong", 45));
            gestor.AgregarReceta(new Receta("Som Tam", "Chef Niran", 15));
            gestor.AgregarReceta(new Receta("Mango Sticky Rice", "Chef Kanya", 50));

            // === ARGENTINA ===
            gestor.AgregarReceta(new Receta("Empanadas", "Chef Gómez", 55));
            gestor.AgregarReceta(new Receta("Asado", "Chef Fernández", 180));
            gestor.AgregarReceta(new Receta("Milanesa", "Chef Rodríguez", 40));
            gestor.AgregarReceta(new Receta("Chimichurri", "Chef Sosa", 10));
            gestor.AgregarReceta(new Receta("Alfajores", "Chef Martínez", 60));

            // === MEDIO ORIENTE ===
            gestor.AgregarReceta(new Receta("Hummus", "Chef Khalil", 15));
            gestor.AgregarReceta(new Receta("Falafel", "Chef Mansour", 35));
            gestor.AgregarReceta(new Receta("Tabbouleh", "Chef Haddad", 20));
            gestor.AgregarReceta(new Receta("Shawarma", "Chef Aziz", 90));
            gestor.AgregarReceta(new Receta("Baklava", "Chef Demir", 75));

            // === HUNGRÍA ===
            gestor.AgregarReceta(new Receta("Goulash", "Chef Kovács", 110));
            gestor.AgregarReceta(new Receta("Langos", "Chef Nagy", 60));
            gestor.AgregarReceta(new Receta("Paprikash", "Chef Szabó", 80));
            gestor.AgregarReceta(new Receta("Dobos Torte", "Chef Horváth", 150));
            gestor.AgregarReceta(new Receta("Halászlé", "Chef Tóth", 70));

            // === VIETNAM ===
            gestor.AgregarReceta(new Receta("Pho", "Chef Nguyen", 180));
            gestor.AgregarReceta(new Receta("Banh Mi", "Chef Tran", 25));
            gestor.AgregarReceta(new Receta("Bun Cha", "Chef Le", 50));
            gestor.AgregarReceta(new Receta("Goi Cuon", "Chef Pham", 20));
            gestor.AgregarReceta(new Receta("Ca Kho To", "Chef Hoang", 95));

            // === GRECIA ===
            gestor.AgregarReceta(new Receta("Moussaka", "Chef Papadopoulos", 95));
            gestor.AgregarReceta(new Receta("Souvlaki", "Chef Dimitriou", 40));
            gestor.AgregarReceta(new Receta("Tzatziki", "Chef Andreou", 15));
            gestor.AgregarReceta(new Receta("Spanakopita", "Chef Georgiou", 70));
            gestor.AgregarReceta(new Receta("Dolmades", "Chef Nikolaou", 85));

            // === RUSIA ===
            gestor.AgregarReceta(new Receta("Borscht", "Chef Ivanov", 80));
            gestor.AgregarReceta(new Receta("Beef Stroganoff", "Chef Petrov", 60));
            gestor.AgregarReceta(new Receta("Blini", "Chef Smirnov", 30));
            gestor.AgregarReceta(new Receta("Pelmeni", "Chef Volkov", 90));
            gestor.AgregarReceta(new Receta("Olivier", "Chef Sokolov", 45));

            // === COREA ===
            gestor.AgregarReceta(new Receta("Bibimbap", "Chef Kim", 40));
            gestor.AgregarReceta(new Receta("Kimchi", "Chef Park", 120));
            gestor.AgregarReceta(new Receta("Bulgogi", "Chef Lee", 55));
            gestor.AgregarReceta(new Receta("Tteokbokki", "Chef Choi", 30));
            gestor.AgregarReceta(new Receta("Japchae", "Chef Jung", 50));

            // === POLONIA ===
            gestor.AgregarReceta(new Receta("Pierogi", "Chef Kowalski", 70));
            gestor.AgregarReceta(new Receta("Bigos", "Chef Nowak", 180));
            gestor.AgregarReceta(new Receta("Zurek", "Chef Wójcik", 90));
            gestor.AgregarReceta(new Receta("Golabki", "Chef Lewandowski", 120));
            gestor.AgregarReceta(new Receta("Sernik", "Chef Wiśniewski", 95));

            // === INDIA ===
            gestor.AgregarReceta(new Receta("Biryani", "Chef Khan", 100));
            gestor.AgregarReceta(new Receta("Tikka Masala", "Chef Sharma", 65));
            gestor.AgregarReceta(new Receta("Samosas", "Chef Patel", 45));
            gestor.AgregarReceta(new Receta("Naan", "Chef Singh", 30));
            gestor.AgregarReceta(new Receta("Dal Makhani", "Chef Gupta", 85));

            // === ALEMANIA ===
            gestor.AgregarReceta(new Receta("Cheesecake", "Chef Müller", 85));
            gestor.AgregarReceta(new Receta("Bratwurst", "Chef Schmidt", 25));
            gestor.AgregarReceta(new Receta("Sauerbraten", "Chef Fischer", 200));
            gestor.AgregarReceta(new Receta("Pretzel", "Chef Weber", 40));
            gestor.AgregarReceta(new Receta("Schnitzel", "Chef Becker", 35));

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
                Console.ForegroundColor = ColorEntrada;
                Console.Write("Seleccione una opción: ");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out int opcion)) {
                    EscribirColor("⚠ Opción no válida.\n", ColorError);
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
                        MostrarLibrosUsuario(usuario);
                        break;
                    case 7:
                        ExportarLibros(exportador, usuario);
                        break;
                    case 8:
                        salir = true;
                        EscribirColor("\n¡Hasta luego! Buen provecho 🍽\n", ColorTitulo);
                        break;
                    default:
                        EscribirColor("⚠ Opción no válida.\n", ColorError);
                        break;
                }
            }
        }

        static void EscribirColor(string texto, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.Write(texto);
            Console.ResetColor();
        }

        static void MostrarEncabezado() {
            Console.ForegroundColor = ColorTitulo;
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║   🍳  SISTEMA DE GESTIÓN DE RECETAS DE COCINA  🍳        ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void MostrarMenu(Usuario usuario, string libroActual) {
            int totalRecetas = usuario.ObtenerLibro(libroActual)?.Count ?? 0;

            Console.WriteLine();
            EscribirColor("╔══════════════ MENÚ PRINCIPAL ══════════════╗\n", ColorTitulo);
            Console.ForegroundColor = ColorInfo;
            Console.WriteLine($"  📖 Libro actual: '{libroActual}' ({totalRecetas} recetas)");
            Console.ResetColor();
            EscribirColor("╠════════════════════════════════════════════╣\n", ColorTitulo);

            Console.ForegroundColor = ColorMenu;
            Console.WriteLine("  1. 📋 Mostrar Recetas disponibles");
            Console.WriteLine("  2. 🔄 Ordenar libro actual (QuickSort/MergeSort)");
            Console.WriteLine("  3. 🔍 Búsqueda binaria en catálogo");
            Console.WriteLine("  4. ➕ Crear nuevo libro de recetas");
            Console.WriteLine("  5. 🔀 Cambiar de libro actual");
            Console.WriteLine("  6. 📚 Ver mis libros");
            Console.WriteLine("  7. 💾 Exportar mis libros a archivo .txt");
            Console.WriteLine("  8. 🚪 Salir");
            Console.ResetColor();

            EscribirColor("╚════════════════════════════════════════════╝\n", ColorTitulo);
        }

        // === Método auxiliar para validar entradas no vacías ===
        static string LeerEntradaNoVacia(string mensaje) {
            string entrada;
            while (true) {
                Console.ForegroundColor = ColorEntrada;
                Console.Write(mensaje);
                Console.ResetColor();
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada)) {
                    return entrada.Trim();
                }

                EscribirColor("⚠ Error: El campo no puede estar vacío. Intente de nuevo.\n", ColorError);
            }
        }

        // === FUNCIONES DEL MENÚ ===

        static void MostrarRecetasDisponibles(GestorRecetas gestor) {
            EscribirColor("\n--- 📋 RECETAS DISPONIBLES ---\n", ColorTitulo);

            if (gestor.RecetasDisponibles.Count == 0) {
                EscribirColor("No hay recetas disponibles.\n", ColorError);
                return;
            }

            Console.ForegroundColor = ColorReceta;
            for (int i = 0; i < gestor.RecetasDisponibles.Count; i++)
                Console.WriteLine($"  {i + 1,3}. {gestor.RecetasDisponibles[i].ToString()}");
            Console.ResetColor();

            EscribirColor($"\nTotal: {gestor.RecetasDisponibles.Count} recetas en el catálogo.\n", ColorInfo);
        }

        static void OrdenarLibroActual(ServicioRecetas servicio, Usuario usuario, string libroActual) {
            Console.ForegroundColor = ColorEntrada;
            Console.Write("Elija algoritmo (quick/merge): ");
            Console.ResetColor();
            string tipo = Console.ReadLine();

            var libro = usuario.ObtenerLibro(libroActual);
            if (libro == null || libro.Count == 0) {
                EscribirColor("⚠ El libro está vacío. No hay nada que ordenar.\n", ColorError);
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
                EscribirColor("⚠ Algoritmo no válido. Use 'quick' o 'merge'.\n", ColorError);
                return;
            }

            int totalMinutos = 0;
            foreach (var r in usuario.ObtenerLibro(libroActual))
                totalMinutos += r.TiempoMinutos;

            EscribirColor($"\n⏱ Tiempo total de recetas en '{libroActual}': {totalMinutos} minutos\n", ColorInfo);
            EscribirColor("Recetas ordenadas:\n", ColorTitulo);

            Console.ForegroundColor = ColorReceta;
            foreach (var r in usuario.ObtenerLibro(libroActual))
                Console.WriteLine($"   - {r.ToString()}");
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

            Console.ForegroundColor = ColorReceta;
            for (int i = 0; i < gestor.RecetasDisponibles.Count; i++)
                Console.WriteLine($"  {i + 1,3}. {gestor.RecetasDisponibles[i].ToString()}");
            Console.ResetColor();

            Console.ForegroundColor = ColorEntrada;
            Console.Write($"\nIngrese el índice de la receta para agregarla a '{libroActual}' (0 para cancelar): ");
            Console.ResetColor();

            if (int.TryParse(Console.ReadLine(), out int indiceElegido)) {
                if (indiceElegido == 0) {
                    EscribirColor("Operación cancelada.\n", ColorInfo);
                    return;
                }
                if (indiceElegido >= 1 && indiceElegido <= gestor.RecetasDisponibles.Count) {
                    var receta = gestor.RecetasDisponibles[indiceElegido - 1];
                    usuario.AgregarRecetaALibro(libroActual, receta);
                    EscribirColor($"✓ Receta '{receta.Nombre}' agregada a '{libroActual}'.\n", ColorExito);
                } else {
                    EscribirColor("⚠ Índice fuera de rango.\n", ColorError);
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
                EscribirColor("⚠ No tienes libros.\n", ColorError);
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
                EscribirColor("⚠ No tienes libros de recetas.\n", ColorError);
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
                        Console.WriteLine($"   - {receta.ToString()}");
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