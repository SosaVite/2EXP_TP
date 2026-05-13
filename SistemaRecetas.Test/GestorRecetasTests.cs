using SistemaRecetas.Gestores;
using SistemaRecetas.Modelos;
using Xunit;

namespace SistemaRecetas.Tests {
    public class GestorRecetasTests {
        [Fact]
        public void AgregarReceta_IncrementaCount() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("Paella", "Chef", 45));
            Assert.Equal(1, g.RecetasDisponibles.Count);
        }

        [Fact]
        public void AgregarReceta_Duplicado_NoDuplica() {
            var g = new GestorRecetas();
            var r = new Receta("Paella", "Chef", 45);
            g.AgregarReceta(r);
            g.AgregarReceta(r);
            Assert.Equal(1, g.RecetasDisponibles.Count);
        }

        [Fact]
        public void EliminarReceta_DisminuyeCount() {
            var g = new GestorRecetas();
            var r = new Receta("Paella", "Chef", 45);
            g.AgregarReceta(r);
            g.EliminarReceta(r);
            Assert.Equal(0, g.RecetasDisponibles.Count);
        }

        [Fact]
        public void BuscarPorNombre_CaseInsensitive_Encuentra() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("Paella Valenciana", "Chef", 45));
            var resultados = g.BuscarPorNombre("paella");
            Assert.Contains(resultados, r => r.Nombre == "Paella Valenciana");
        }

        [Fact]
        public void BuscarPorNombre_SinCoincidencias_RetornaVacio() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("Paella", "Chef", 45));
            var resultados = g.BuscarPorNombre("ZZZ");
            Assert.Empty(resultados);
        }

        [Fact]
        public void QuickSort_OrdenAscendenteCorrecto() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("A", "C", 90));
            g.AgregarReceta(new Receta("B", "C", 10));
            g.AgregarReceta(new Receta("C", "C", 50));
            g.QuickSort(g.RecetasDisponibles);
            for (int i = 0; i < g.RecetasDisponibles.Count - 1; i++)
                Assert.True(g.RecetasDisponibles[i].TiempoMinutos <= g.RecetasDisponibles[i + 1].TiempoMinutos);
        }

        [Fact]
        public void MergeSort_OrdenAscendenteCorrecto() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("A", "C", 90));
            g.AgregarReceta(new Receta("B", "C", 10));
            g.AgregarReceta(new Receta("C", "C", 50));
            var ordenada = g.MergeSort(g.RecetasDisponibles);
            for (int i = 0; i < ordenada.Count - 1; i++)
                Assert.True(ordenada[i].TiempoMinutos <= ordenada[i + 1].TiempoMinutos);
        }

        [Fact]
        public void MergeSort_NoModificaOriginal() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("A", "C", 90));
            g.AgregarReceta(new Receta("B", "C", 10));
            int primerTiempoAntes = g.RecetasDisponibles[0].TiempoMinutos;
            g.MergeSort(g.RecetasDisponibles);
            Assert.Equal(primerTiempoAntes, g.RecetasDisponibles[0].TiempoMinutos);
        }

        [Fact]
        public void BusquedaBinaria_RecetaExistente_RetornaIndiceValido() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("Paella", "Chef", 45));
            g.AgregarReceta(new Receta("Tacos", "Chef", 30));
            Assert.True(g.BusquedaBinaria("Paella") >= 0);
        }

        [Fact]
        public void BusquedaBinaria_CaseInsensitive_Encuentra() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("Paella", "Chef", 45));
            Assert.True(g.BusquedaBinaria("PAELLA") >= 0);
        }

        [Fact]
        public void BusquedaBinaria_NoExistente_RetornaMenosUno() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("Paella", "Chef", 45));
            Assert.Equal(-1, g.BusquedaBinaria("RecetaXYZInexistente"));
        }

        [Fact]
        public void LimpiarCatalogo_DejaListaVacia() {
            var g = new GestorRecetas();
            g.AgregarReceta(new Receta("Paella", "Chef", 45));
            g.LimpiarCatalogo();
            Assert.Empty(g.RecetasDisponibles);
        }
    }
}