﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Twitter.Data;

namespace Twitter.Migrations
{
    [DbContext(typeof(TwitterContext))]
    partial class TwitterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Twitter.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Comentarios")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .HasColumnType("longtext");

                    b.Property<int>("Curtidas")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("longblob");

                    b.Property<DateTime>("Momento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Retweets")
                        .HasColumnType("int");

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Twitter.Models.Curtida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ComentarioId")
                        .HasColumnType("int");

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Curtidas");
                });

            modelBuilder.Entity("Twitter.Models.Tweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Comentarios")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .HasColumnType("longtext");

                    b.Property<int>("Curtidas")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataTweetado")
                        .HasColumnType("datetime(6)");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("longblob");

                    b.Property<int>("Retweets")
                        .HasColumnType("int");

                    b.Property<int>("Salvos")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("Twitter.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoVerificacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ImagemPerfil")
                        .HasColumnType("longblob");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tag")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Twitter.Models.Comentario", b =>
                {
                    b.HasOne("Twitter.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Twitter.Models.Curtida", b =>
                {
                    b.HasOne("Twitter.Models.Usuario", null)
                        .WithMany("TweetsCurtidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Twitter.Models.Tweet", b =>
                {
                    b.HasOne("Twitter.Models.Usuario", "Usuario")
                        .WithMany("Tweets")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Twitter.Models.Usuario", b =>
                {
                    b.Navigation("Tweets");

                    b.Navigation("TweetsCurtidos");
                });
#pragma warning restore 612, 618
        }
    }
}
