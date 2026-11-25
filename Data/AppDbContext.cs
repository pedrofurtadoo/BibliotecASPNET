using System;
using System.Collections.Generic;
using Bibliotec_MVC__Manha.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec_MVC__Manha.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administrador { get; set; }

    public virtual DbSet<Aluno> Aluno { get; set; }

    public virtual DbSet<Autor> Autor { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Curso> Curso { get; set; }

    public virtual DbSet<Favoritos> Favoritos { get; set; }

    public virtual DbSet<Livro> Livro { get; set; }

    public virtual DbSet<Reserva> Reserva { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__2B3E34A8DDCDA0D5");

            entity.HasIndex(e => e.NIF, "UQ__Administ__C7DEC330ADB4E051").IsUnique();

            entity.Property(e => e.IdAdministrador).ValueGeneratedNever();
            entity.Property(e => e.NIF)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAdministradorNavigation).WithOne(p => p.Administrador)
                .HasForeignKey<Administrador>(d => d.IdAdministrador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administrador_Usuario");
        });

        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.IdAluno).HasName("PK__Aluno__8092FCB3ACC676DE");

            entity.HasIndex(e => e.Matricula, "UQ__Aluno__0FB9FB4FA65AC01C").IsUnique();

            entity.Property(e => e.IdAluno).ValueGeneratedNever();
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodVerifEmail)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Matricula)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAlunoNavigation).WithOne(p => p.Aluno)
                .HasForeignKey<Aluno>(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aluno_Usuario");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Aluno)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aluno_Curso");
        });

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autor__DD33B031E69F788B");

            entity.Property(e => e.Nacionalidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10A1B6BC83");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Curso__085F27D68185CF01");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Periodo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Favoritos>(entity =>
        {
            entity.HasKey(e => e.IdFavorito).HasName("PK__Favorito__39DCEE505D34F647");

            entity.HasIndex(e => new { e.IdAluno, e.IdLivro }, "UQ_Favorito").IsUnique();

            entity.Property(e => e.DataFavorito)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favoritos_Aluno");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.IdLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favoritos_Livro");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.IdLivro).HasName("PK__Livro__3B69D85A1FB4C30B");

            entity.Property(e => e.CaminhoImagem)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Editora)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Livro)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_Autor");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Livro)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_Status");

            entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdLivro)
                .UsingEntity<Dictionary<string, object>>(
                    "LivroCategoria",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LivroCategoria_Categoria"),
                    l => l.HasOne<Livro>().WithMany()
                        .HasForeignKey("IdLivro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LivroCategoria_Livro"),
                    j =>
                    {
                        j.HasKey("IdLivro", "IdCategoria");
                    });
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__0E49C69DA8635EE4");

            entity.Property(e => e.Observacoes)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Aluno");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Livro");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Reserva)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Status");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Status__B450643AA7BBEA12");

            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF975774BE78");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534A05CDC9D").IsUnique();

            entity.Property(e => e.CaminhoFoto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DataCadastro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Excluido).HasDefaultValue(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
