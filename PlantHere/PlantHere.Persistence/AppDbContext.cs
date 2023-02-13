using MediatR;
using Microsoft.EntityFrameworkCore;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;
using System.Reflection;

namespace PlantHere.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions dbContextOptions, IMediator mediator) : base(dbContextOptions)
        {
            _mediator = mediator;
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Basket> Basket { get; set; }

        public DbSet<BasketItem> BasketItem { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
