﻿using Chapter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Contexts
{
    public class ChapterContext: DbContext
    {
        public ChapterContext()
        {

        }

        public ChapterContext(DbContextOptions<ChapterContext> options): base(options)
        {

        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true; TrustServerCertificate=true;");
            }
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }


}


