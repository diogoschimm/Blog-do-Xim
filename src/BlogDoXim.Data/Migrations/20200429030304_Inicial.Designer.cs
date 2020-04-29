﻿// <auto-generated />
using System;
using BlogDoXim.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogDoXim.Data.Migrations
{
    [DbContext(typeof(BlogDoXimContext))]
    [Migration("20200429030304_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogDoXim.Domain.AcessoArtigo", b =>
                {
                    b.Property<int>("AcessoArtigoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AcessoArtigoId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtigoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAcesso")
                        .HasColumnName("DataAcesso")
                        .HasColumnType("DateTime");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnName("IP")
                        .HasColumnType("varchar(100)");

                    b.HasKey("AcessoArtigoId")
                        .HasName("pk_acessoArtigo");

                    b.HasIndex("ArtigoId");

                    b.ToTable("AcessoArtigo");
                });

            modelBuilder.Entity("BlogDoXim.Domain.Artigo", b =>
                {
                    b.Property<int>("ArtigoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ArtigoId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("CategoriaId")
                        .HasColumnName("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnName("Conteudo")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DataPublicacao")
                        .HasColumnName("DataPublicacao")
                        .HasColumnType("DateTime");

                    b.Property<string>("GithubUrl")
                        .IsRequired()
                        .HasColumnName("GithubUrl")
                        .HasColumnType("varchar(1000)");

                    b.Property<byte[]>("Imagem")
                        .HasColumnName("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasColumnName("Resumo")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SubTitulo")
                        .IsRequired()
                        .HasColumnName("SubTitulo")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("Titulo")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("UsuarioId")
                        .HasColumnName("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ArtigoId")
                        .HasName("pk_artigo");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Artigo");
                });

            modelBuilder.Entity("BlogDoXim.Domain.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoriaId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("DateTime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("varchar(500)");

                    b.Property<byte[]>("Imagem")
                        .HasColumnName("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoriaId")
                        .HasName("pk_categoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("BlogDoXim.Domain.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UsuarioId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("DateTime");

                    b.Property<byte[]>("Foto")
                        .HasColumnName("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Github")
                        .IsRequired()
                        .HasColumnName("Github")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("Login")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("varchar(max)");

                    b.HasKey("UsuarioId")
                        .HasName("pk_usuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BlogDoXim.Domain.AcessoArtigo", b =>
                {
                    b.HasOne("BlogDoXim.Domain.Artigo", "Artigo")
                        .WithMany("AcessosArtigo")
                        .HasForeignKey("ArtigoId")
                        .HasConstraintName("fk_acessoArtigo_artigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogDoXim.Domain.Artigo", b =>
                {
                    b.HasOne("BlogDoXim.Domain.Categoria", "Categoria")
                        .WithMany("Artigos")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("fk_artigo_categoria")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BlogDoXim.Domain.Usuario", "Usuario")
                        .WithMany("Artigos")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_artigo_usuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
