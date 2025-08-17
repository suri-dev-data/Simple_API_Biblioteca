using LivroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroAPI.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> opts) : base(opts)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprestimo>()
                .HasKey(livroEmprestimo => new
                {
                    livroEmprestimo.LivroId,
                    livroEmprestimo.PessoaId
                });

            modelBuilder.Entity<Emprestimo>()
                .HasOne(emprestimo => emprestimo.Livro)
                .WithMany(livro => livro.Emprestimos)
                .HasForeignKey(emprestimo => emprestimo.LivroId);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(emprestimo => emprestimo.Pessoa)
                .WithMany(pessoa => pessoa.Emprestimos)
                .HasForeignKey(emprestimo => emprestimo.PessoaId);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(emprestimo => emprestimo.Livro)
                .WithMany(livro => livro.Emprestimos)
                .OnDelete(DeleteBehavior.Restrict);


        }
        public DbSet<Livro> livros { get; set; }
        public DbSet<Livraria> livrarias { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Emprestimo> emprestimos { get; set; }
    }
}
