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

            Console.WriteLine("SISTEMA DE GESTIÓN DE RECETAS DE COCINA\n");

            // === Registro de Usuario ===
            Console.WriteLine("--- REGISTRO DE USUARIO ---");
            string nombreUsuario = LeerEntradaNoVacia("Por favor, ingrese su nombre de usuario: ");
            var usuario = servicio.RegistrarUsuario(nombreUsuario);
            Console.WriteLine($"Usuario '{nombreUsuario}' registrado.");
            Console.WriteLine($"¡Bienvenido/a, {nombreUsuario}!\n");

            string primerLibro = LeerEntradaNoVacia("Ingrese un nombre para su primer libro de recetas: ");
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

        // === Método auxiliar para validar entradas no vacías ===
        static string LeerEntradaNoVacia(string mensaje) {
            string entrada;
            while (true) {
                Console.Write(mensaje);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada)) {
                    return entrada.Trim();
                }

                Console.WriteLine("⚠ Error: El campo no puede estar vacío. Intente de nuevo.");
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
            string nombre = LeerEntradaNoVacia("Ingrese el nombre exacto de la receta a buscar: ");

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
            string nuevo = LeerEntradaNoVacia("Ingrese el nombre del nuevo libro: ");
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

            string elegido = LeerEntradaNoVacia("Ingrese el nombre del libro al que desea cambiar: ");

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