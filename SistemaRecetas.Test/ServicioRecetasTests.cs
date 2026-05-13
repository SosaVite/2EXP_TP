using System;
using System.IO;
using SistemaRecetas.Gestores;
using SistemaRecetas.Modelos;
using SistemaRecetas.Servicios;
using Xunit;

namespace SistemaRecetas.Tests {
    public class ServicioRecetasTests : IDisposable {
        private readonly ServicioRecetas _servicio;
        private readonly string _rutaTemp;

        public ServicioRecetasTests() {
            var gestor = new GestorRecetas();
            var exportador = new ExportadorTxt();
            _servicio = new ServicioRecetas(gestor, exportador);
            _rutaTemp = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.txt");
        }

        [Fact]
        public void RegistrarUsuario_AgregaALista() {
            _servicio.RegistrarUsuario("TestUser");
            Assert.NotNull(_servicio.BuscarUsuario("TestUser"));
            Assert.Equal(1, _servicio.ContarUsuarios());
        }

        [Fact]
        public void BuscarUsuario_CaseInsensitive_Encuentra() {
            _servicio.RegistrarUsuario("Ana");
            Assert.NotNull(_servicio.BuscarUsuario("ANA"));
        }

        [Fact]
        public void BuscarUsuario_Inexistente_RetornaNull() {
            Assert.Null(_servicio.BuscarUsuario("Inexistente"));
        }

        [Fact]
        public void EliminarUsuario_ReduceCount() {
            _servicio.RegistrarUsuario("Ana");
            Assert.True(_servicio.EliminarUsuario("Ana"));
            Assert.Equal(0, _servicio.ContarUsuarios());
        }

        [Fact]
        public void OrdenarCatalogo_Quick_OrdenCorrecto() {
            _servicio.Gestor.AgregarReceta(new Receta("A", "C", 90));
            _servicio.Gestor.AgregarReceta(new Receta("B", "C", 10));
            _servicio.OrdenarCatalogo("quick");
            Assert.Equal(10, _servicio.Gestor.RecetasDisponibles[0].TiempoMinutos);
        }

        [Fact]
        public void OrdenarCatalogo_Merge_OrdenCorrecto() {
            _servicio.Gestor.AgregarReceta(new Receta("A", "C", 90));
            _servicio.Gestor.AgregarReceta(new Receta("B", "C", 10));
            _servicio.OrdenarCatalogo("merge");
            Assert.Equal(10, _servicio.Gestor.RecetasDisponibles[0].TiempoMinutos);
        }

        [Fact]
        public void ExportarATxt_CreaArchivo() {
            var u = _servicio.RegistrarUsuario("Ana");
            u.CrearLibroRecetas("Fav");
            u.AgregarRecetaALibro("Fav", new Receta("Paella", "Chef", 45));
            _servicio.Exportador.ExportarATxt(u, _rutaTemp);
            Assert.True(File.Exists(_rutaTemp));
        }

        [Fact]
        public void ExportarATxt_ContieneNombreReceta() {
            var u = _servicio.RegistrarUsuario("Ana");
            u.CrearLibroRecetas("Fav");
            u.AgregarRecetaALibro("Fav", new Receta("Paella", "Chef", 45));
            _servicio.Exportador.ExportarATxt(u, _rutaTemp);
            var contenido = File.ReadAllText(_rutaTemp);
            Assert.Contains("Paella", contenido);
        }

        [Fact]
        public void ExportarATxt_ContieneNombreUsuario() {
            var u = _servicio.RegistrarUsuario("Ana");
            _servicio.Exportador.ExportarATxt(u, _rutaTemp);
            var contenido = File.ReadAllText(_rutaTemp);
            Assert.Contains("Ana", contenido);
        }

        public void Dispose() {
            if (File.Exists(_rutaTemp)) File.Delete(_rutaTemp);
        }
    }
}