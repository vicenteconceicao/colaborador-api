using estagio_brg.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estagio_brg.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<Trilha> Trilhas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Trilha>()
                .HasKey(t => new {t.ColaboradorId, t.HabilidadeId });

            builder.Entity<Colaborador>()
                .HasData(new List<Colaborador>() { 
                    new Colaborador(1,"Açougueiro","Operacional"),
                    new Colaborador(2,"Administrador","Recursos Humanos"),
                    new Colaborador(3,"Analista Administrativo","Recursos Humanos"),
                    new Colaborador(4,"Almoxarife","Empenho"),
                    new Colaborador(5,"Administrador de Sistemas","Tributário"),
                    new Colaborador(6,"Analista de Documentaçãos","Tributário"),
                    new Colaborador(7,"Ajudante Geral","Geral")
                });
            builder.Entity<Habilidade>()
                .HasData(new List<Habilidade>() {
                    new Habilidade(1,"Gestão de Projetos",1),
                    new Habilidade(2,"Mecânica de Motores",1),
                    new Habilidade(3,"Programação",1),
                    new Habilidade(4,"Domínio de C#",1),
                    new Habilidade(5,"Domínio de Exel",1),
                    new Habilidade(6,"Domínio de Contabilidade",1),
                    new Habilidade(7,"Inglês",1),
                    new Habilidade(8,"Comunicação Interpessoal",2),
                    new Habilidade(9,"Persuasão",2),
                    new Habilidade(10,"Proatividade",2),
                    new Habilidade(11,"Resiliência",2),
                    new Habilidade(12,"Resolução de conflitos",2),
                    new Habilidade(13,"Liderança",2),
                    new Habilidade(14,"Confiança",2),
                    new Habilidade(15,"Criatividade",2),
                    new Habilidade(16,"Comunicação",2),
                    new Habilidade(17,"Organização",2)
                });
            builder.Entity<Trilha>()
                .HasData(new List<Trilha>() {
                    new Trilha(1, 1, 8, DateTime.Parse("18/07/2020")),
                    new Trilha(2, 1, 10, DateTime.Parse("19/07/2020")),
                    new Trilha(3, 1, 17, DateTime.Parse("20/07/2020")),
                    new Trilha(4, 5, 3, DateTime.Parse("21/07/2020")),
                    new Trilha(5, 5, 7, DateTime.Parse("22/07/2020")),
                    new Trilha(6, 5, 10, DateTime.Parse("23/07/2020")),
                    new Trilha(7, 7, 2, DateTime.Parse("24/07/2020")),
                    new Trilha(8, 7, 12, DateTime.Parse("25/07/2020")),
                    new Trilha(9, 7, 15, DateTime.Parse("26/07/2020"))
                });
        }
    }
}
