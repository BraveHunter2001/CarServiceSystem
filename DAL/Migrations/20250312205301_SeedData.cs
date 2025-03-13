using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                INSERT INTO Owners (Name, Surname, Patronymic, Phone, PassportSeries, PassportNumber, ResidentialAddress)
                VALUES
                    (N'Иван', N'Петров', N'Александрович', N'+79161234567', N'4507', N'123456', N'Москва, ул. Ленина, д. 10'),
                    (N'Мария', N'Сидорова', NULL, N'+79261112233', N'5008', N'654321', N'Санкт-Петербург, пр. Невский, д. 20'),
                    (N'Алексей', N'Иванов', N'Викторович', N'+79370001122', N'4709', N'987654', N'Казань, ул. Баумана, д. 5');

                INSERT INTO Automobiles (Brand, Model, LicensePlate, Mileage, EngineVolume, OwnerId)
                VALUES
                    (N'Toyota', N'Camry', N'A123BC77', 75000, 2.5, 1),
                    (N'BMW', N'X5', N'B456CD78', 120000, 3.0, 2),
                    (N'Hyundai', N'Solaris', N'C789DE79', 90000, 1.6, 3);

                INSERT INTO Masters (Name, Surname, Patronymic, Phone, WorkExperience)
                VALUES
                    (N'Сергей', N'Морозов', N'Андреевич', N'+79165556677', 10),
                    (N'Владимир', N'Кузнецов', NULL, N'+79263334455', 7),
                    (N'Олег', N'Смирнов', N'Игоревич', N'+79372221133', 15);

                INSERT INTO WorkRecords (Malfunction, Cost, RepairDate, CompletionDate, AutomobileId, MasterId)
                VALUES
                    (N'Замена масла', 3000.00, '2025-05-01', NULL, 1, 1),
                    (N'Ремонт двигателя', 50000.00, '2025-05-05', NULL, 2, 2),
                    (N'Замена тормозных колодок', 7000.00, '2025-05-08', '2025-05-22', 3, 3),
                    (N'Диагностика', 1500.00, '2025-05-10', NULL, 1, 2),
                    (N'Замена аккумулятора', 8000.00, '2025-05-12', '2025-05-22', 2, 3),
                    (N'Ремонт подвески', 12000.00, '2025-05-15', NULL, 3, 1),
                    (N'Покраска кузова', 25000.00, '2025-05-18', '2025-05-22', 1, 3),
                    (N'Шиномонтаж', 2000.00, '2025-05-20', NULL, 2, 1),
                    (N'Замена свечей зажигания', 5000.00, '2025-05-22', NULL, 3, 2),
                    (N'Ремонт КПП', 45000.00, '2025-05-25', NULL, 1, 2);

                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
