using Microsoft.EntityFrameworkCore;
using premio_essencial_back_end.Data;
using premio_essencial_back_end.Services;

namespace premio_essencial_back_end
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<DataContext>
				(opts =>
				{
					opts.UseMySql(connString, ServerVersion.AutoDetect(connString));
				});

			// Add services to the container.
			builder.Services.AddScoped<IParticipante, ParticipanteService>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//builder.Services.AddCors(options => options.AddPolicy(name: "Front", 
			//	policy =>
			//	{
			//		policy.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader();
			//	}
			//	)); 

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors(c => {
				c.AllowAnyHeader();
				c.AllowAnyMethod();
				c.AllowAnyOrigin();
			});

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}