using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NotesAppFinal1.DataAccess;
using SEDC.NotesAppFinal1.DataAccess.Implementations;
using SEDC.NotesAppFinal1.DataAccess.Interfaces;
using SEDC.NotesAppFinal1.Domain.Models;
using SEDC.NotesAppFinal1.Services.Implementations;
using SEDC.NotesAppFinal1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.Helpers
{
	public static class DependencyInjectionHelper
	{
		public static void InjectDbContext (this IServiceCollection services)
		{
			services.AddDbContext<NotesAppFinal1DbContext> (options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLServer;Database=NotesAppFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
		}

		public static void InjectRepositories(this IServiceCollection services)
		{
			services.AddTransient<IRepository<Note>, NoteRepository>();
			services.AddTransient<IRepository<User>, UserRepository>();
		}

		public static void InjectServices (this IServiceCollection services)
		{
			services.AddTransient<INoteService, NoteService>();
			services.AddTransient<IUserService, UserService>();
		}
	}
}
