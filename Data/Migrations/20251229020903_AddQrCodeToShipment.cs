using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L_Connect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQrCodeToShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrCodeImage",
                table: "Shipments",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 1,
                column: "last_updated_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 419, DateTimeKind.Utc).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 2,
                column: "last_updated_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 419, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 3,
                column: "last_updated_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 419, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 4,
                column: "last_updated_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 419, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 5,
                column: "last_updated_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 419, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 6,
                column: "last_updated_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 419, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "ROLES",
                keyColumn: "role_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 109, DateTimeKind.Utc).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "ROLES",
                keyColumn: "role_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 12, 29, 2, 9, 0, 109, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 26, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 26, 14, 9, 0, 415, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 28, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 9, 0, 415, DateTimeKind.Utc).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 26, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 27, 14, 9, 0, 415, DateTimeKind.Utc).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 28, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 28, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 28, 20, 9, 0, 415, DateTimeKind.Utc).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EstimatedDeliveryDate", "QrCodeImage" },
                values: new object[] { new DateTime(2025, 12, 26, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8018), new DateTime(2025, 12, 31, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8028), null });

            migrationBuilder.UpdateData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EstimatedDeliveryDate", "QrCodeImage" },
                values: new object[] { new DateTime(2025, 12, 24, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8041), new DateTime(2025, 12, 28, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8042), null });

            migrationBuilder.UpdateData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EstimatedDeliveryDate", "QrCodeImage" },
                values: new object[] { new DateTime(2025, 12, 28, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8046), new DateTime(2026, 1, 2, 2, 9, 0, 415, DateTimeKind.Utc).AddTicks(8047), null });

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password_hash" },
                values: new object[] { new DateTime(2025, 12, 29, 2, 9, 0, 109, DateTimeKind.Utc).AddTicks(7406), "AQAAAAIAAYagAAAAEIqnFYLyTwli1++CgWeWe7RosyVhu0dsOipjr25+0aRRBjnifIqJP9b7eSn+eo5lgA==" });

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password_hash" },
                values: new object[] { new DateTime(2025, 12, 29, 2, 9, 0, 109, DateTimeKind.Utc).AddTicks(7408), "AQAAAAIAAYagAAAAEA5V8NXxwR7koldONCBiJ1yAIifComMQMM7wfzmWIT3A4UZtjVkT4g93WPyRtwtkGg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrCodeImage",
                table: "Shipments");

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 1,
                column: "last_updated_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 273, DateTimeKind.Utc).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 2,
                column: "last_updated_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 273, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 3,
                column: "last_updated_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 273, DateTimeKind.Utc).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 4,
                column: "last_updated_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 273, DateTimeKind.Utc).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 5,
                column: "last_updated_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 273, DateTimeKind.Utc).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "PRICING",
                keyColumn: "price_id",
                keyValue: 6,
                column: "last_updated_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 273, DateTimeKind.Utc).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "ROLES",
                keyColumn: "role_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 190, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "ROLES",
                keyColumn: "role_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 3, 30, 5, 0, 13, 190, DateTimeKind.Utc).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 27, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 27, 17, 0, 13, 272, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 29, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 25, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 25, 17, 0, 13, 272, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 27, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 28, 17, 0, 13, 272, DateTimeKind.Utc).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 29, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 29, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "ShipmentStatuses",
                keyColumn: "StatusId",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 3, 29, 23, 0, 13, 272, DateTimeKind.Utc).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EstimatedDeliveryDate" },
                values: new object[] { new DateTime(2025, 3, 27, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8111), new DateTime(2025, 4, 1, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8116) });

            migrationBuilder.UpdateData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EstimatedDeliveryDate" },
                values: new object[] { new DateTime(2025, 3, 25, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8120), new DateTime(2025, 3, 29, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8120) });

            migrationBuilder.UpdateData(
                table: "Shipments",
                keyColumn: "ShipmentId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EstimatedDeliveryDate" },
                values: new object[] { new DateTime(2025, 3, 29, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8122), new DateTime(2025, 4, 3, 5, 0, 13, 272, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password_hash" },
                values: new object[] { new DateTime(2025, 3, 30, 5, 0, 13, 190, DateTimeKind.Utc).AddTicks(992), "AQAAAAIAAYagAAAAEIOfA1qdJtlmNlKYsecdeQ7lEIKszCglOcEPRTV/ImGJZ6g6JCRyKFieCXukn7ZGIg==" });

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password_hash" },
                values: new object[] { new DateTime(2025, 3, 30, 5, 0, 13, 190, DateTimeKind.Utc).AddTicks(994), "AQAAAAIAAYagAAAAEPW9O97q9/dAIZfM1sGzmTzwqbV0KqfwBsr1+dDK4/oYljPGrHi5Gv+FA2pj+0sPDw==" });
        }
    }
}
