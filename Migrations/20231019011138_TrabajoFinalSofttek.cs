using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoFinalSofttek.Migrations
{
    public partial class TrabajoFinalSofttek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuentasCriptos",
                columns: table => new
                {
                    cuentaCripto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cuentaCripto_UUID = table.Column<long>(type: "bigint", nullable: false),
                    cuentaCripto_saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuentaCripto_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasCriptos", x => x.cuentaCripto_id);
                });

            migrationBuilder.CreateTable(
                name: "CuentasFiduciarias",
                columns: table => new
                {
                    cuentaFiduciaria_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

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
                    usuario_clave = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    cuentaFiduciaria_id = table.Column<int>(type: "int", nullable: false),
                    cuentaCripto_id = table.Column<int>(type: "int", nullable: false),
                    usuario_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_Usuarios_CuentasCriptos_cuentaCripto_id",
                        column: x => x.cuentaCripto_id,
                        principalTable: "CuentasCriptos",
                        principalColumn: "cuentaCripto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_CuentasFiduciarias_cuentaFiduciaria_id",
                        column: x => x.cuentaFiduciaria_id,
                        principalTable: "CuentasFiduciarias",
                        principalColumn: "cuentaFiduciaria_id",
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
                    historial_monto = table.Column<long>(type: "bigint", nullable: false)
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
                table: "CuentasCriptos",
                columns: new[] { "cuentaCripto_id", "cuentaCripto_activo", "cuentaCripto_saldo", "cuentaCripto_UUID" },
                values: new object[] { 1, true, 10m, 2222333L });

            migrationBuilder.InsertData(
                table: "CuentasFiduciarias",
                columns: new[] { "cuentaFiduciaria_id", "cuentaFiduciaria_activo", "cuentaFiduciaria_alias", "cuentaFiduciaria_CBU", "cuentaFiduciaria_numeroCuenta", "cuentaFiduciaria_saldoDolares", "cuentaFiduciaria_saldoPesos" },
                values: new object[] { 1, true, "alias", 111111111111111L, 1, 100m, 10000m });

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
                columns: new[] { "usuario_id", "usuario_activo", "usuario_clave", "cuentaCripto_id", "cuentaFiduciaria_id", "usuario_cuil" },
                values: new object[] { 1, true, "1234", 1, 1, 20424465306L });

            migrationBuilder.InsertData(
                table: "Historiales",
                columns: new[] { "historial_id", "moneda_id", "historial_monto", "tipoMovimiento_id", "usuario_id" },
                values: new object[] { 1, 1, 10000L, 1, 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_cuentaCripto_id",
                table: "Usuarios",
                column: "cuentaCripto_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_cuentaFiduciaria_id",
                table: "Usuarios",
                column: "cuentaFiduciaria_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "TipoMovimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CuentasCriptos");

            migrationBuilder.DropTable(
                name: "CuentasFiduciarias");
        }
    }
}
