using PersonagensFiltro.Entity;

namespace PersonagensFiltro.SERVICES
{
    public interface IServiceP
    {
        IEnumerable<Personagens> MostrarTodos();
        Personagens MostrarPorId(int id);
        void Adicionar(Personagens personagem);
        void Atualizar(Personagens personagem);
        void Deletar(int id);
        IEnumerable<Personagens> MostrarPorRaca(string raca);
        IEnumerable<Personagens> MostrarPorIdade(int idade);
        IEnumerable<Personagens> MostrarPorIdadeIgualMenorQue(int idade);
        IEnumerable<Personagens> MostrarPorIdadeIgualMaiorQue(int idade);
    }
}
