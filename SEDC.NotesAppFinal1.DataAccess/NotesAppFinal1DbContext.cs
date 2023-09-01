using Microsoft.EntityFrameworkCore;
using SEDC.NotesAppFinal1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesAppFinal1.DataAccess
{
	public class NotesAppFinal1DbContext : DbContext
	{
        public NotesAppFinal1DbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
			.Property(x => x.FirstName)
			.HasMaxLength(50);

			modelBuilder.Entity<User>()
		    .Property(x => x.LastName)
			.HasMaxLength(50);

			modelBuilder.Entity<User>()
			.Property(x=>x.UserName) 
			.HasMaxLength(50)
			.IsRequired();

			modelBuilder.Entity<User>()
			.Property(x => x.Age)
			.IsRequired();

			modelBuilder.Entity<Note>()
			.Property(x => x.Text)
			.HasMaxLength(100);

			modelBuilder.Entity<Note>()
			.Property(x => x.Priority)
			.IsRequired();

			modelBuilder.Entity<Note>()
			.Property(x => x.Tag)
			.IsRequired();

			modelBuilder.Entity<User>()
			.HasMany(x => x.Notes)
			.WithOne(x => x.User)
			.HasForeignKey(x => x.Userid);

			modelBuilder.Entity<Note>().HasData(new Note
			{
				Id = 1,
				Text = "Buy groceries for the week.",
				Priority = Domain.Enums.Priority.High,
				Tag = Domain.Enums.Tag.Work,
				Userid = 2,
			});

			modelBuilder.Entity<Note>().HasData(new Note
			{
				Id = 2,
				Text = "Prepare presentation for client meeting.",
				Priority = Domain.Enums.Priority.Medium,
				Tag = Domain.Enums.Tag.SocialLife,
				Userid = 1,
			});

			modelBuilder.Entity<Note>().HasData(new Note
			{
				Id = 3,
				Text = "Call plumber to fix the leaking faucet.",
				Priority = Domain.Enums.Priority.Low,
				Tag = Domain.Enums.Tag.Health,
				Userid = 3,
			});

			modelBuilder.Entity<Note>().HasData(new Note
			{
				Id = 4,
				Text = "Research new recipe ideas for dinner party.",
				Priority = Domain.Enums.Priority.Medium,
				Tag = Domain.Enums.Tag.SocialLife,
				Userid = 2,
			});

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 1,
				FirstName = "Bojan",
				LastName = "Damchevski",
				UserName = "BojanDamchevski",
				Age = 25
			});

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 2,
				FirstName = "Damjan",
				LastName = "Krstevski",
				UserName = "DamjanKrstevski",
				Age = 28
			});

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 3,
				FirstName = "Antonio",
				LastName = "Novoselski",
				UserName = "AntonioNovoselski",
				Age = 20
			});

		}
	}
}
