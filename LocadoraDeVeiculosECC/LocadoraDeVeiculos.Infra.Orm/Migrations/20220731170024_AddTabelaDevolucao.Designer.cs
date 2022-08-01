﻿// <auto-generated />
using System;
using LocadoraDeVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraDeVeiculosDbContext))]
    [Migration("20220731170024_AddTabelaDevolucao")]
    partial class AddTabelaDevolucao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<int>("TipoDeCliente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBCliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<DateTime>("ValidadeCnh")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBCondutor");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("KmVeiculo")
                        .HasColumnType("int");

                    b.Property<Guid>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("NivelDoTanque")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoId");

                    b.ToTable("TBDevolucao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeEntrada")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos.GrupoDeVeiculos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeDoGrupo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoDeVeiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CondutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucaoPrevista")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlanoDeCobrancaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorTotalPrevisto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PlanoDeCobrancaId");

                    b.ToTable("TBLocacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoDeVeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecoKmRodado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoDePlano")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorKmIncluso")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoDeVeiculoId");

                    b.ToTable("TBPlanoDeCobranca");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloTaxas.Taxas", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<Guid?>("DevolucaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoCalculo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DevolucaoId");

                    b.HasIndex("LocacaoId");

                    b.ToTable("TBTaxas");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", "Locacao")
                        .WithMany()
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Locacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", "Condutor")
                        .WithMany()
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloFuncionario.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", "PlanoDeCobranca")
                        .WithMany()
                        .HasForeignKey("PlanoDeCobrancaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("Funcionario");

                    b.Navigation("PlanoDeCobranca");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca.PlanoDeCobranca", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos.GrupoDeVeiculos", "GrupoDeVeiculo")
                        .WithMany()
                        .HasForeignKey("GrupoDeVeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoDeVeiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloTaxas.Taxas", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", null)
                        .WithMany("Taxas")
                        .HasForeignKey("DevolucaoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", null)
                        .WithMany("Taxas")
                        .HasForeignKey("LocacaoId");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.Navigation("Taxas");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Navigation("Taxas");
                });
#pragma warning restore 612, 618
        }
    }
}
