using System;
using System.Collections.Generic;
using SistemaRecetas.Interfaces;
using SistemaRecetas.Modelos;

namespace SistemaRecetas.Gestores {
    public class GestorRecetas : IGestorRecetas {
        public List<Receta> RecetasDisponibles { get; private set; }

        public GestorRecetas() {
            RecetasDisponibles = new List<Receta>();
        }

        public void AgregarReceta(Receta receta) {
            if (receta == null) return;
            if (!RecetasDisponibles.Contains(receta))
                RecetasDisponibles.Add(receta);
        }

        public void EliminarReceta(Receta receta) {
            if (RecetasDisponibles.Contains(receta))
                RecetasDisponibles.Remove(receta);
        }

        public void EliminarPorIndice(int indice) {
            if (indice >= 0 && indice < RecetasDisponibles.Count)
                RecetasDisponibles.RemoveAt(indice);
        }

        public List<Receta> BuscarPorNombre(string nombre) {
            var resultados = new List<Receta>();
            if (string.IsNullOrWhiteSpace(nombre)) return resultados;

            foreach (var r in RecetasDisponibles) {
                if (r.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0)
                    resultados.Add(r);
            }
            return resultados;
        }

        public void LimpiarCatalogo() {
            RecetasDisponibles.Clear();
        }

        // ---------------- QUICKSORT (in-place, por TiempoMinutos ASC) ----------------
        public void QuickSort(List<Receta> lista) {
            if (lista == null || lista.Count <= 1) return;
            QuickSortRecursivo(lista, 0, lista.Count - 1);
        }

        private void QuickSortRecursivo(List<Receta> lista, int izquierda, int derecha) {
            if (izquierda < derecha) {
                int pivote = Particionar(lista, izquierda, derecha);
                QuickSortRecursivo(lista, izquierda, pivote - 1);
                QuickSortRecursivo(lista, pivote + 1, derecha);
            }
        }

        private int Particionar(List<Receta> lista, int izquierda, int derecha) {
            int pivote = lista[derecha].TiempoMinutos;
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++) {
                if (lista[j].TiempoMinutos <= pivote) {
                    i++;
                    (lista[i], lista[j]) = (lista[j], lista[i]);
                }
            }
            (lista[i + 1], lista[derecha]) = (lista[derecha], lista[i + 1]);
            return i + 1;
        }

        // ---------------- MERGESORT (retorna nueva lista) ----------------
        public List<Receta> MergeSort(List<Receta> lista) {
            if (lista == null || lista.Count <= 1)
                return new List<Receta>(lista ?? new List<Receta>());

            int medio = lista.Count / 2;
            var izquierda = MergeSort(lista.GetRange(0, medio));
            var derecha = MergeSort(lista.GetRange(medio, lista.Count - medio));

            return Merge(izquierda, derecha);
        }

        private List<Receta> Merge(List<Receta> izq, List<Receta> der) {
            var resultado = new List<Receta>();
            int i = 0, j = 0;

            while (i < izq.Count && j < der.Count) {
                if (izq[i].TiempoMinutos <= der[j].TiempoMinutos)
                    resultado.Add(izq[i++]);
                else
                    resultado.Add(der[j++]);
            }
            while (i < izq.Count) resultado.Add(izq[i++]);
            while (j < der.Count) resultado.Add(der[j++]);

            return resultado;
        }

        // ---------------- BÚSQUEDA BINARIA (por Nombre) ----------------
        public int BusquedaBinaria(string nombre) {
            if (string.IsNullOrWhiteSpace(nombre) || RecetasDisponibles.Count == 0)
                return -1;

            // Ordenamos una copia por Nombre
            var copiaOrdenada = new List<Receta>(RecetasDisponibles);
            copiaOrdenada.Sort((a, b) => string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase));

            int izq = 0;
            int der = copiaOrdenada.Count - 1;

            while (izq <= der) {
                int medio = (izq + der) / 2;
                int comparacion = string.Compare(copiaOrdenada[medio].Nombre, nombre, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0) {
                    // Retornamos el índice en la lista ORIGINAL
                    return RecetasDisponibles.IndexOf(copiaOrdenada[medio]);
                } else if (comparacion < 0)
                    izq = medio + 1;
                else
                    der = medio - 1;
            }
            return -1;
        }
    }
}