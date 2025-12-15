namespace Temperature
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.Services.AddLogging();
            });

            // Add services to the container.
            var logger           = loggerFactory.CreateLogger("ConfigureServices");

            var connectionString = builder.Configuration.GetConnectionString("SmartHome");

            var smartHomeDb = new SmartHomeDb(connectionString);

            builder.Services.AddSingleton(smartHomeDb);
            
            logger.LogInformation($"Конфигурация ConnectionStrings: [SmartHome={connectionString}]");

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
