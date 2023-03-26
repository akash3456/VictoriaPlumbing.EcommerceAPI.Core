using VictoriaPlumbing.EcommerceAPI.Core.Database;
using VictoriaPlumbing.EcommerceAPI.Core.Delegates;
using VictoriaPlumbing.EcommerceAPI.Core.Interfaces;
using VictoriaPlumbing.EcommerceAPI.Core.Services;
using VictoriaPlumbing.EcommerceAPI.Core.Validators;

namespace VictoriaPlumbing.EcommerceAPI.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<MockDatabase>();
            builder.Services.AddTransient<IOrderConfirmedHandler, OrderConfirmedHandler>();
            builder.Services.AddTransient<OrderValidator>();

            
            builder.Services.AddTransient<ValidateDelegate>(s =>
            {
                var validator = s.GetRequiredService<OrderValidator>();
                return validator.Validate;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}