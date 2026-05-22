using SistemaRecetas.Interfaces;

namespace SistemaRecetas.Modelos {
    public class Receta : IReceta {
        public string Nombre { get; }
        public string Chef { get; }
        public int TiempoMinutos { get; }

        public Receta(string nombre, string chef, int tiempoMinutos) {
            if (tiempoMinutos <= 0)
                throw new ArgumentException("El tiempo en minutos debe ser mayor a 0.");
            Nombre = nombre;
            Chef = chef;
            TiempoMinutos = tiempoMinutos;
        }

        public override string ToString() {
            return $"{Nombre} - {Chef} ({TiempoMinutos} min)";
        }


        public override bool Equals(object obj) =>
            obj is Receta otra &&
            string.Equals(Nombre, otra.Nombre, StringComparison.OrdinalIgnoreCase);


        public override int GetHashCode() =>
            Nombre.ToLowerInvariant().GetHashCode();
    }
}