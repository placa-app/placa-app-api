﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Placa.Repositorio;

namespace Placa.Repositorio.Migrations
{
    [DbContext(typeof(PlacaContexto))]
    partial class PlacaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Placa.Dominio.Motorista", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("alocacao");

                    b.Property<int>("carga_horaria");

                    b.Property<DateTime?>("data_atualizacao");

                    b.Property<DateTime>("data_criacao");

                    b.Property<string>("email");

                    b.Property<string>("faixa_etaria");

                    b.Property<string>("nome");

                    b.Property<string>("senha");

                    b.Property<bool>("status");

                    b.HasKey("id");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("Placa.Dominio.ProblemaSaude", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome");

                    b.HasKey("id");

                    b.ToTable("ProblemasSaude");
                });

            modelBuilder.Entity("Placa.Dominio.ProblemaSaudeMotorista", b =>
                {
                    b.Property<int>("ProblemaSaudeId");

                    b.Property<int>("MotoristaId");

                    b.HasKey("ProblemaSaudeId", "MotoristaId");

                    b.HasIndex("MotoristaId");

                    b.ToTable("ProblemasMotoristas");
                });

            modelBuilder.Entity("Placa.Dominio.Viagem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MotoristaId");

                    b.Property<DateTime?>("data_atualizacao");

                    b.Property<DateTime>("data_criacao");

                    b.Property<string>("destino");

                    b.Property<string>("distancia");

                    b.Property<string>("estado_viagem");

                    b.Property<DateTime>("horario_partida");

                    b.Property<DateTime>("horario_previsto");

                    b.Property<string>("origim");

                    b.Property<bool>("status");

                    b.HasKey("id");

                    b.HasIndex("MotoristaId");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("Placa.Dominio.ProblemaSaudeMotorista", b =>
                {
                    b.HasOne("Placa.Dominio.Motorista", "Motorista")
                        .WithMany("problemas")
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Placa.Dominio.ProblemaSaude", "ProblemaSaude")
                        .WithMany()
                        .HasForeignKey("ProblemaSaudeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Placa.Dominio.Viagem", b =>
                {
                    b.HasOne("Placa.Dominio.Motorista", "motorista")
                        .WithMany("viagens")
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
