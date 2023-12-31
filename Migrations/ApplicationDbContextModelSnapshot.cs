﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabajoFinalSofttek.DataAccess;

#nullable disable

namespace TrabajoFinalSofttek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.CuentaCripto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cuentaCripto_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("cuentaCripto_activo");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("cuentaCripto_saldo");

                    b.Property<long>("UUID")
                        .HasColumnType("bigint")
                        .HasColumnName("cuentaCripto_UUID");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CuentasCriptos");
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.CuentaFiduciaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cuentaFiduciaria_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("cuentaFiduciaria_activo");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cuentaFiduciaria_alias");

                    b.Property<long>("CBU")
                        .HasColumnType("bigint")
                        .HasColumnName("cuentaFiduciaria_CBU");

                    b.Property<int>("NumeroCuenta")
                        .HasColumnType("int")
                        .HasColumnName("cuentaFiduciaria_numeroCuenta");

                    b.Property<decimal>("SaldoDolares")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("cuentaFiduciaria_saldoDolares");

                    b.Property<decimal>("SaldoPesos")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("cuentaFiduciaria_saldoPesos");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CuentasFiduciarias");
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.Historial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("historial_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Cuil")
                        .HasColumnType("bigint")
                        .HasColumnName("historial_cuil_destino");

                    b.Property<int>("MonedaId")
                        .HasColumnType("int")
                        .HasColumnName("moneda_id");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("historial_monto");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("int")
                        .HasColumnName("tipoMovimiento_id");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("MonedaId");

                    b.HasIndex("TipoMovimientoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Historiales");
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.Moneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("moneda_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("moneda_descripcion");

                    b.HasKey("Id");

                    b.ToTable("Monedas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Peso"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Dolar"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "BTC"
                        });
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.TipoMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("tipoMovimiento_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tipoMovimiento_descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoMovimientos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Deposito"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Extraccion"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Venta"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Compra"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Transferencia"
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Consulta"
                        });
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("usuario_activo");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("usuario_apellido");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("usuario_clave");

                    b.Property<long>("Cuil")
                        .HasColumnType("bigint")
                        .HasColumnName("usuario_cuil");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("usuario_nombre");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Apellido = "Scaglione",
                            Clave = "1234",
                            Cuil = 11111111L,
                            Nombre = "Franco"
                        });
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.CuentaCripto", b =>
                {
                    b.HasOne("TrabajoFinalSofttek.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.CuentaFiduciaria", b =>
                {
                    b.HasOne("TrabajoFinalSofttek.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TrabajoFinalSofttek.Entities.Historial", b =>
                {
                    b.HasOne("TrabajoFinalSofttek.Entities.Moneda", "Moneda")
                        .WithMany()
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoFinalSofttek.Entities.TipoMovimiento", "TipoMovimiento")
                        .WithMany()
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoFinalSofttek.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moneda");

                    b.Navigation("TipoMovimiento");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
