
using DAL;
using Services;

namespace CarServiceSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            string dbConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddDAL(dbConnection);
            builder.Services.AddServices();

            builder.Services.AddControllers();

            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    o =>
                    {
                        o.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                    });
            });

            var app = builder.Build();

            app.UseCors(MyAllowSpecificOrigins);
            app.MapControllers();

            app.Run();
        }
    }
}
