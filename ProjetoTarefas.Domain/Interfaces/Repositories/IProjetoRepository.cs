using ProjetosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosApp.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        void Add(Projeto projeto);
        void Update(Projeto projeto);
        void Delete(Projeto projeto);

        List<Projeto> GetAll();
        List<Projeto> GetByName(string nome);
        Projeto? GetById(Guid id);
    }
}
