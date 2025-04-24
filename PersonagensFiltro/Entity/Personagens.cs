namespace PersonagensFiltro.Entity
{
    public class Personagens
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public string Raca { get; set; } = null!;
        public string? Classe { get; set; }
        public string? Arma { get; set; }
        public string? Armadura { get; set; }
        public int idade { get; set; }
    }
}
