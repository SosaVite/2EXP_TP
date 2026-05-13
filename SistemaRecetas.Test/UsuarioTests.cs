using System;
using SistemaRecetas.Modelos;
using Xunit;

namespace SistemaRecetas.Tests {
    public class UsuarioTests {
        [Fact]
        public void CrearLibro_AgregaAlDiccionario() {
            var u = new Usuario("Ana");
            u.CrearLibroRecetas("Favoritas");
            Assert.True(u.LibrosRecetas.ContainsKey("Favoritas"));
            Assert.Empty(u.LibrosRecetas["Favoritas"]);
        }

        [Fact]
        public void CrearLibro_Duplicado_LanzaInvalidOperationException() {
            var u = new Usuario("Ana");
            u.CrearLibroRecetas("Favoritas");
            Assert.Throws<InvalidOperationException>(() => u.CrearLibroRecetas("Favoritas"));
        }

        [Fact]
        public void AgregarReceta_LibroExistente_AgregaCorrectamente() {
            var u = new Usuario("Ana");
            u.CrearLibroRecetas("Favoritas");
            u.AgregarRecetaALibro("Favoritas", new Receta("Paella", "Chef", 45));
            Assert.Single(u.LibrosRecetas["Favoritas"]);
        }

        [Fact]
        public void AgregarReceta_LibroInexistente_LanzaKeyNotFoundException() {
            var u = new Usuario("Ana");
            Assert.Throws<KeyNotFoundException>(() =>
                u.AgregarRecetaALibro("NoExiste", new Receta("X", "Y", 10)));
        }

        [Fact]
        public void EliminarLibro_RemoveDelDiccionario() {
            var u = new Usuario("Ana");
            u.CrearLibroRecetas("Favoritas");
            u.EliminarLibro("Favoritas");
            Assert.False(u.LibrosRecetas.ContainsKey("Favoritas"));
        }

        [Fact]
        public void ContarRecetas_SumaCorrecta() {
            var u = new Usuario("Ana");
            u.CrearLibroRecetas("L1");
            u.CrearLibroRecetas("L2");
            u.AgregarRecetaALibro("L1", new Receta("A", "C", 10));
            u.AgregarRecetaALibro("L2", new Receta("B", "C", 20));
            Assert.Equal(2, u.ContarRecetas());
        }

        [Fact]
        public void ObtenerLibro_Existente_RetornaLista() {
            var u = new Usuario("Ana");
            u.CrearLibroRecetas("Favoritas");
            Assert.NotNull(u.ObtenerLibro("Favoritas"));
        }

        [Fact]
        public void ObtenerLibro_Inexistente_RetornaNull() {
            var u = new Usuario("Ana");
            Assert.Null(u.ObtenerLibro("NoExiste"));
        }
    }
}