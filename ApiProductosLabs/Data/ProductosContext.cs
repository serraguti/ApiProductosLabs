﻿using ApiProductosLabs.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProductosLabs.Data
{
    public class ProductosContext: DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
    }
}
