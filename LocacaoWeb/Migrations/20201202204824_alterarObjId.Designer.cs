﻿// <auto-generated />
using System;
using LocacaoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocacaoWeb.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201202204824_alterarObjId")]
    partial class alterarObjId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocacaoWeb.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("criadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LocacaoWeb.Models.Funcionario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("criadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("LocacaoWeb.Models.Locacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cliID")
                        .HasColumnType("int");

                    b.Property<int?>("clienteid")
                        .HasColumnType("int");

                    b.Property<DateTime>("criadoEm")
                        .HasColumnType("datetime2");

                    b.Property<double>("custoVariavel")
                        .HasColumnType("float");

                    b.Property<DateTime>("dataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<bool>("devolvido")
                        .HasColumnType("bit");

                    b.Property<string>("formaPagamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("funID")
                        .HasColumnType("int");

                    b.Property<int?>("funcionarioid")
                        .HasColumnType("int");

                    b.Property<DateTime>("previsaoEntrega")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalLocacao")
                        .HasColumnType("float");

                    b.Property<int>("vecID")
                        .HasColumnType("int");

                    b.Property<int?>("veiculoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.HasIndex("funcionarioid");

                    b.HasIndex("veiculoid");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("LocacaoWeb.Models.Veiculo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("criadoEm")
                        .HasColumnType("datetime2");

                    b.Property<bool>("locado")
                        .HasColumnType("bit");

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valorDiaria")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("veiculos");
                });

            modelBuilder.Entity("LocacaoWeb.Models.Locacao", b =>
                {
                    b.HasOne("LocacaoWeb.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid");

                    b.HasOne("LocacaoWeb.Models.Funcionario", "funcionario")
                        .WithMany()
                        .HasForeignKey("funcionarioid");

                    b.HasOne("LocacaoWeb.Models.Veiculo", "veiculo")
                        .WithMany()
                        .HasForeignKey("veiculoid");
                });
#pragma warning restore 612, 618
        }
    }
}
