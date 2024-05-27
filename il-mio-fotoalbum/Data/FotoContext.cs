﻿using il_mio_fotoalbum.Models;
using Microsoft.EntityFrameworkCore;

namespace il_mio_fotoalbum.Data
{
    public class FotoContext : DbContext
    {
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-fotoalbum;Integrated Security=True;Trust Server Certificate=True");
        }
    }
  
}