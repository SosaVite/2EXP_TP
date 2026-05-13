using System;
using System.Collections.Generic;
using SistemaRecetas.Interfaces;
using SistemaRecetas.Modelos;

namespace SistemaRecetas.Servicios {
    public class ServicioRecetas {
        public IGestorRecetas Gestor { get; private set; }
        public IExportador Exportador { get; private set; }
        public List<Usuario> Usuarios { get; private set; }

        public ServicioRecetas(IGestorRecetas gestor, IExportador exportador) {
            Gestor = gestor;
            Exportador = exportador;
            Usuarios = new List<Usuario>();
        }

        public Usuario RegistrarUsuario(string nombre) {
            var usuario = new Usuario(nombre);
            Usuarios.Add(usuario);
            return usuario;
        }

        public Usuario BuscarUsuario(string nombre) {
            if (string.IsNullOrWhiteSpace(nombre)) return null;
            return Usuarios.Find(u => string.Equals(u.Nombre, nombre, StringComparison.OrdinalIgnoreCase));
        }

        public bool EliminarUsuario(string nombre) {
            var usuario = BuscarUsuario(nombre);
            if (usuario != null) {
                Usuarios.Remove(usuario);
                return true;
            }
            return false;
        }

        public int ContarUsuarios() {
            return Usuarios.Count;
        }

        public void OrdenarCatalogo(string tipo) {
            if (string.Equals(tipo, "quick", StringComparison.OrdinalIgnoreCase)) {
                Gestor.QuickSort(Gestor.RecetasDisponibles);
                Console.WriteLine("✓ Catálogo ordenado con QuickSort (ascendente por TiempoMinutos).");
            } else if (string.Equals(tipo, "merge", StringComparison.OrdinalIgnoreCase)) {
                var ordenada = Gestor.MergeSort(Gestor.RecetasDisponibles);
                Gestor.LimpiarCatalogo();
                foreach (var r in ordenada) Gestor.AgregarReceta(r);
                Console.WriteLine("✓ Catálogo ordenado con MergeSort (ascendente por TiempoMinutos).");
            } else {
                Console.WriteLine("Tipo de ordenamiento no válido. Use 'quick' o 'merge'.");
            }
        }

        public int OrdenarLibroYCalcularTiempo(Usuario usuario, string nombreLibro) {
            var libro = usuario.ObtenerLibro(nombreLibro);
            if (libro == null) return 0;

            var ordenada = Gestor.MergeSort(libro);
            usuario.LibrosRecetas[nombreLibro] = ordenada;

            int total = 0;
            foreach (var r in ordenada) total += r.TiempoMinutos;
            return total;
        }
    }
}