using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json; 
using System;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using Microsoft.Identity.Client;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using static System.Net.Mime.MediaTypeNames;
using Azure;
using StarWarsApi.Models;
using Microsoft.AspNetCore.Http;


namespace StarWarsApi.Models
{
    public class StarShipContext : DbContext
    {
        public StarShipContext(DbContextOptions<StarShipContext> options)
        : base(options)
        { }

        public DbSet<Starship> Starships { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

