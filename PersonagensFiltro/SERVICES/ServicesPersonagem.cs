using Microsoft.EntityFrameworkCore;
using PersonagensFiltro.DTO;
using PersonagensFiltro.Entity;

namespace PersonagensFiltro.SERVICES
{
    public class ServicesPersonagem : IServiceP
    {
        private readonly DataFile _context;
        public ServicesPersonagem(DataFile context)
        {
            _context = context;
        }

        IEnumerable<Personagens> IServiceP.MostrarTodos()
        {
            return _context.Personagens.AsNoTracking().ToList();
        }

        Personagens? IServiceP.MostrarPorId(int id)
        {
            return _context.Personagens.Find(id);
        }

        void IServiceP.Adicionar(Personagens personagem)
        {
            _context.Personagens.Add(personagem);
            _context.SaveChanges();
        }

        void IServiceP.Atualizar(Personagens personagem)
        {
            _context.Personagens.Update(personagem);
            _context.SaveChanges();
        }

        void IServiceP.Deletar(int id)
        {
            var personagem = _context.Personagens.Find(id);
            if (personagem != null)
            {
                _context.Personagens.Remove(personagem);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Entity.Personagens> MostrarPorRaca(string raca)
        {
            return _context.Personagens.Where(p => p.Raca == raca).ToList();
        }

        public IEnumerable<Entity.Personagens> MostrarPorIdade(int idade)
        {
            return _context.Personagens.Where(p => p.idade == idade).ToList();
        }

        public IEnumerable<Entity.Personagens> MostrarPorIdadeIgualMenorQue(int idade)
        {
            return _context.Personagens.Where(p => p.idade < idade).ToList();
        }

        public IEnumerable<Entity.Personagens> MostrarPorIdadeIgualMaiorQue(int idade)
        {
            return _context.Personagens.Where(p => p.idade > idade).ToList();
        }



    }
}