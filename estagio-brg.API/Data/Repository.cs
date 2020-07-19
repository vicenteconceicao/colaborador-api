using estagio_brg.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Colaborador[] GetAllColaboradores()
        {
            IQueryable<Colaborador> query = _context.Colaboradores;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);
            return query.ToArray();
        }

        public Colaborador[] GetAllColaboradoresByHabilidadeId(int habilidadeId)
        {
            IQueryable<Colaborador> query = _context.Colaboradores;
            query = query.AsNoTracking()
                         .Where(c => c.Trilhas.Any(t => t.HabilidadeId == habilidadeId));

            return query.ToArray();
        }

        public Colaborador GetColaboradorById(int colaboradorId)
        {
            IQueryable<Colaborador> query = _context.Colaboradores;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.Id == colaboradorId);
            return query.FirstOrDefault();
        }

        public Habilidade[] GetAllHabilidades()
        {
            IQueryable<Habilidade> query = _context.Habilidades;
            query = query.AsNoTracking()
                         .OrderBy(h => h.Id);
            return query.ToArray();
        }

        public Habilidade[] GetAllHabilidadesByColaboradorId(int colaboradorId)
        {
            IQueryable<Habilidade> query = _context.Habilidades;
            query = query.AsNoTracking()
                         .Where(c => c.Trilhas.Any(t => t.ColaboradorId == colaboradorId));
            return query.ToArray();
        }

        public Habilidade GetHabilidadeById(int habilidadeId)
        {
            IQueryable<Habilidade> query = _context.Habilidades;
            query = query.AsNoTracking()
                         .OrderBy(h => h.Id)
                         .Where(h => h.Id == habilidadeId);
            return query.FirstOrDefault();
        }

        public Trilha[] GetAllTrilhas()
        {
            IQueryable<Trilha> query = _context.Trilhas;
            query = query.AsNoTracking()
                         .Include(c => c.Colaborador).Include(h => h.Habilidade);
            return query.ToArray();
        }

        public Trilha[] GetAllTrilhasByColaboradorId(int colaboradorId)
        {
            IQueryable<Trilha> query = _context.Trilhas;
            query = query.AsNoTracking()
                         .Include(c => c.Colaborador)
                         .Include(h => h.Habilidade)
                         .OrderBy(t => t.Id)
                         .Where(c => c.ColaboradorId == colaboradorId);
            return query.ToArray();
        }

        public Trilha[] GetAllTrilhasByHabilidadeId(int habilidadeId)
        {
            IQueryable<Trilha> query = _context.Trilhas;
            query = query.AsNoTracking()
                         .Include(c => c.Colaborador)
                         .Include(h => h.Habilidade)
                         .OrderBy(t => t.Id)
                         .Where(c => c.HabilidadeId == habilidadeId);
            return query.ToArray();
        }

        public Trilha GetTrilhaById(int trilhasId)
        {
            IQueryable<Trilha> query = _context.Trilhas;
            query = query.AsNoTracking()
                         .Include(c => c.Colaborador)
                         .Include(h => h.Habilidade)
                         .OrderBy(t => t.Id)
                         .Where(t => t.Id == trilhasId);
            return query.FirstOrDefault();
        }
    }
}
