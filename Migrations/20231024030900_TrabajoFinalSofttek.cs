using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoFinalSofttek.Migrations
{
    public partial class TrabajoFinalSofttek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    moneda_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moneda_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.moneda_id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimientos",
                columns: table => new
                {
                    tipoMovimiento_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoMovimiento_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimientos", x => x.tipoMovimiento_id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_cuil = table.Column<long>(type: "bigint", nullable: false),
                    usuario_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario_clave = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    usuario_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuario_id);
                });

            migrationBuilder.CreateTable(
                name: "CuentasCriptos",
                columns: table => new
                {
                    cuentaCripto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    cuentaCripto_UUID = table.Column<long>(type: "bigint", nullable: false),
                    cuentaCripto_saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuentaCripto_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasCriptos", x => x.cuentaCripto_id);
                    table.ForeignKey(
                        name: "FK_CuentasCriptos_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentasFiduciarias",
                columns: table => new
                {
                    cuentaFiduciaria_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    cuentaFiduciaria_CBU = table.Column<long>(type: "bigint", nullable: false),
                    cuentaFiduciaria_alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cuentaFiduciaria_numeroCuenta = table.Column<int>(type: "int", nullable: false),
                    cuentaFiduciaria_saldoPesos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuentaFiduciaria_saldoDolares = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuentaFiduciaria_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasFiduciarias", x => x.cuentaFiduciaria_id);
                    table.ForeignKey(
                        name: "FK_CuentasFiduciarias_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historiales",
                columns: table => new
                {
                    historial_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    tipoMovimiento_id = table.Column<int>(type: "int", nullable: false),
                    moneda_id = table.Column<int>(type: "int", nullable: false),
                    historial_monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiales", x => x.historial_id);
                    table.ForeignKey(
                        name: "FK_Historiales_Monedas_moneda_id",
                        column: x => x.moneda_id,
                        principalTable: "Monedas",
                        principalColumn: "moneda_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_TipoMovimientos_tipoMovimiento_id",
                        column: x => x.tipoMovimiento_id,
                        principalTable: "TipoMovimientos",
                        principalColumn: "tipoMovimiento_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Monedas",
                columns: new[] { "moneda_id", "moneda_descripcion" },
                values: new object[,]
                {
                    { 1, "Peso" },
                    { 2, "Dolar" },
                    { 3, "BTC" }
                });

            migrationBuilder.InsertData(
                table: "TipoMovimientos",
                columns: new[] { "tipoMovimiento_id", "tipoMovimiento_descripcion" },
                values: new object[,]
                {
                    { 1, "Consulta" },
                    { 2, "Deposito" },
                    { 3, "Extraccion" },
                    { 4, "Transferencia" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "usuario_id", "usuario_activo", "usuario_apellido", "usuario_clave", "usuario_cuil", "usuario_nombre" },
                values: new object[] { 1, true, "Scaglione", "1234", 11111111L, "Franco" });

            migrationBuilder.InsertData(
                table: "Historiales",
                columns: new[] { "historial_id", "moneda_id", "historial_monto", "tipoMovimiento_id", "usuario_id" },
                values: new object[] { 1, 1, 10000m, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasCriptos_usuario_id",
                table: "CuentasCriptos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasFiduciarias_usuario_id",
                table: "CuentasFiduciarias",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_moneda_id",
                table: "Historiales",
                column: "moneda_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_tipoMovimiento_id",
                table: "Historiales",
                column: "tipoMovimiento_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_usuario_id",
                table: "Historiales",
                column: "usuario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentasCriptos");

            migrationBuilder.DropTable(
                name: "CuentasFiduciarias");

            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "TipoMovimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
