using estagio_brg.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        bool SaveChanges();

        // Colaborador.
        Colaborador[] GetAllColaboradores();
        Colaborador[] GetAllColaboradoresByHabilidadeId(int id);
        Colaborador GetColaboradorById(int id);

        // Habilidade.
        Habilidade[] GetAllHabilidades();
        Habilidade[] GetAllHabilidadesByColaboradorId(int id);
        Habilidade GetHabilidadeById(int id);

        // Trilha.
        Trilha[] GetAllTrilhas();
        Trilha[] GetAllTrilhasByColaboradorId(int id);
        Trilha[] GetAllTrilhasByHabilidadeId(int id);
        Trilha GetTrilhaById(int id);
        Trilha UpdateTrilha(Trilha entity);
        void DeleteTrilha(Trilha entity);

    }
}
