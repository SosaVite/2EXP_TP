using SistemaRecetas.Modelos;

namespace SistemaRecetas.Recetas {
    public static class ListaRecetas {
        public static readonly (string nombre, string chef, int minutos)[] Datos = new[] {
            // === ESPAÑA ===
            ("Paella", "Chef Ramírez", 45),
            ("Gazpacho", "Chef Vega", 15),
            ("Tortilla Española", "Chef Sanz", 35),
            ("Churros", "Chef Navarro", 25),
            ("Fabada Asturiana", "Chef Aragón", 130),

            // === MÉXICO ===
            ("Tacos", "Chef López", 30),
            ("Guacamole", "Chef Hernández", 10),
            ("Chiles en Nogada", "Chef Morales", 150),
            ("Cochinita Pibil", "Chef Canul", 240),
            ("Mole Poblano", "Chef Domínguez", 180),

            // === ITALIA ===
            ("Risotto", "Chef Rossi", 50),
            ("Tiramisu", "Chef Bianchi", 40),
            ("Lasagna", "Chef Romano", 75),
            ("Carbonara", "Chef Conti", 25),
            ("Osso Buco", "Chef Marino", 140),

            // === PERÚ ===
            ("Ceviche", "Chef Pérez", 20),
            ("Lomo Saltado", "Chef Acurio", 35),
            ("Aji de Gallina", "Chef Quispe", 60),
            ("Causa Limeña", "Chef Salazar", 50),
            ("Anticuchos", "Chef Chávez", 45),

            // === JAPÓN ===
            ("Ramen", "Chef Tanaka", 90),
            ("Sushi", "Chef Yamamoto", 60),
            ("Tempura", "Chef Sato", 30),
            ("Okonomiyaki", "Chef Watanabe", 40),
            ("Gyoza", "Chef Suzuki", 35),

            // === FRANCIA ===
            ("Croissant", "Chef Dupont", 120),
            ("Ratatouille", "Chef Lefèvre", 65),
            ("Crepas", "Chef Moreau", 20),
            ("Coq au Vin", "Chef Laurent", 110),
            ("Quiche Lorraine", "Chef Girard", 55),

            // === TAILANDIA ===
            ("Pad Thai", "Chef Suwan", 25),
            ("Tom Yum", "Chef Chaiyo", 25),
            ("Curry Verde", "Chef Anong", 45),
            ("Som Tam", "Chef Niran", 15),
            ("Mango Sticky Rice", "Chef Kanya", 50),

            // === ARGENTINA ===
            ("Empanadas", "Chef Gómez", 55),
            ("Asado", "Chef Fernández", 180),
            ("Milanesa", "Chef Rodríguez", 40),
            ("Chimichurri", "Chef Sosa", 10),
            ("Alfajores", "Chef Martínez", 60),

            // === MEDIO ORIENTE ===
            ("Hummus", "Chef Khalil", 15),
            ("Falafel", "Chef Mansour", 35),
            ("Tabbouleh", "Chef Haddad", 20),
            ("Shawarma", "Chef Aziz", 90),
            ("Baklava", "Chef Demir", 75),

            // === HUNGRÍA ===
            ("Goulash", "Chef Kovács", 110),
            ("Langos", "Chef Nagy", 60),
            ("Paprikash", "Chef Szabó", 80),
            ("Dobos Torte", "Chef Horváth", 150),
            ("Halászlé", "Chef Tóth", 70),

            // === VIETNAM ===
            ("Pho", "Chef Nguyen", 180),
            ("Banh Mi", "Chef Tran", 25),
            ("Bun Cha", "Chef Le", 50),
            ("Goi Cuon", "Chef Pham", 20),
            ("Ca Kho To", "Chef Hoang", 95),

            // === GRECIA ===
            ("Moussaka", "Chef Papadopoulos", 95),
            ("Souvlaki", "Chef Dimitriou", 40),
            ("Tzatziki", "Chef Andreou", 15),
            ("Spanakopita", "Chef Georgiou", 70),
            ("Dolmades", "Chef Nikolaou", 85),

            // === RUSIA ===
            ("Borscht", "Chef Ivanov", 80),
            ("Beef Stroganoff", "Chef Petrov", 60),
            ("Blini", "Chef Smirnov", 30),
            ("Pelmeni", "Chef Volkov", 90),
            ("Olivier", "Chef Sokolov", 45),

            // === COREA ===
            ("Bibimbap", "Chef Kim", 40),
            ("Kimchi", "Chef Park", 120),
            ("Bulgogi", "Chef Lee", 55),
            ("Tteokbokki", "Chef Choi", 30),
            ("Japchae", "Chef Jung", 50),

            // === POLONIA ===
            ("Pierogi", "Chef Kowalski", 70),
            ("Bigos", "Chef Nowak", 180),
            ("Zurek", "Chef Wójcik", 90),
            ("Golabki", "Chef Lewandowski", 120),
            ("Sernik", "Chef Wiśniewski", 95),

            // === INDIA ===
            ("Biryani", "Chef Khan", 100),
            ("Tikka Masala", "Chef Sharma", 65),
            ("Samosas", "Chef Patel", 45),
            ("Naan", "Chef Singh", 30),
            ("Dal Makhani", "Chef Gupta", 85),

            // === ALEMANIA ===
            ("Cheesecake", "Chef Müller", 85),
            ("Bratwurst", "Chef Schmidt", 25),
            ("Sauerbraten", "Chef Fischer", 200),
            ("Pretzel", "Chef Weber", 40),
            ("Schnitzel", "Chef Becker", 35),
        };

        // Método para cargar todo al gestor de una sola línea
        public static void CargarEn(Gestores.GestorRecetas gestor) {
            foreach (var (nombre, chef, minutos) in Datos)
                gestor.AgregarReceta(new Receta(nombre, chef, minutos));
        }
    }
}