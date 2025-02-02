using ACooperativa.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ACooperativa.Models;
using ACooperativa.Controllers;
using ACooperativa.Data;


using Microsoft.EntityFrameworkCore;
using ACooperativa.Models;

namespace ACooperativa.Data
{
    public class CooperativaContext : DbContext
    {
        public CooperativaContext(DbContextOptions<CooperativaContext> options)
            : base(options)
        {
        }

        public DbSet<Agricultor> Agricultores { get; set; }
        public DbSet<Maquinaria> Maquinarias { get; set; }
        public DbSet<RegistroUso> RegistrosUso { get; set; }
    }
}
