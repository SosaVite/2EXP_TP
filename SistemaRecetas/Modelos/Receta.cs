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
    }
}