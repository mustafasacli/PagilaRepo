using Pagila.Entity;
using Microsoft.EntityFrameworkCore;
using Coddie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pagila.CoreContext
{
    /// <summary>
    /// Defines the <see cref="PublicCoreDbContext"/>.
    /// </summary>
    public class PublicCoreDbContext : DbContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("#CONNECTION_STRING#");
        }

        /// <summary>
        /// The OnModelCreating method.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PublicCoreDbContext).Assembly);

            /**
             * Ef Core Entity type 'XXX' has composite primary key defined with data annotations. To set composite primary key, use fluent API.
             * hatasý için sýnýfta birden fazla Key attribute  varsa onlarý tanýmlamak gerekiyor ve bu iþlem aþaðýda yapýlýyor.
             */
            //modelBuilder.Entity<KullaniciKullanicirol>().HasKey(c => new { c.KullaniciFk, c.RolFk });
            //modelBuilder.Entity<KullaniciRoluygulama>().HasKey(c => new { c.UygulamaFk, c.RolFk });
            modelBuilder.Entity<FilmActor>().HasKey(c => new { c.ActorId, c.FilmId }); 
            modelBuilder.Entity<FilmCategory>().HasKey(c => new { c.FilmId, c.CategoryId }); 

            #region [ Ignoring Tables Have No Key property ]

            var types = new List<Type>();

            this.GetType()
            .GetRuntimeProperties()
            .Where(o =>
                o.PropertyType.IsGenericType &&
                o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                o.PropertyType.GenericTypeArguments.Count() > 0)
                .Select(q => q.PropertyType.GenericTypeArguments)
                .ToList()
                .ForEach(q =>
                {
                    types.AddRange(q);
                });
            types = types.Distinct().ToList();
            types =
            types.Where(q => q.GetKeysOfType().Count() < 1)
            .ToList() ?? new List<Type>();

            types.ForEach(q => { modelBuilder.Ignore(q); });

            # endregion [ Ignoring Tables Have No Key property ]

            #region [ Mapping Entities To Tables ]
/*
            modelBuilder.Entity<Payment>().ToTable(typeof(Payment).GetTableNameOfType());
*/
            # endregion [ Mapping Entities To Tables ]
        }

        #region [ Tables List ]

        /// <summary>
        /// Gets or sets the Actor.
        /// </summary>
        public virtual DbSet<Actor> Actor
        { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        public virtual DbSet<Address> Address
        { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public virtual DbSet<Category> Category
        { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        public virtual DbSet<City> City
        { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public virtual DbSet<Country> Country
        { get; set; }

        /// <summary>
        /// Gets or sets the Customer.
        /// </summary>
        public virtual DbSet<Customer> Customer
        { get; set; }

        /// <summary>
        /// Gets or sets the Film.
        /// </summary>
        public virtual DbSet<Film> Film
        { get; set; }

        /// <summary>
        /// Gets or sets the FilmActor.
        /// </summary>
        public virtual DbSet<FilmActor> FilmActor
        { get; set; }

        /// <summary>
        /// Gets or sets the FilmCategory.
        /// </summary>
        public virtual DbSet<FilmCategory> FilmCategory
        { get; set; }

        /// <summary>
        /// Gets or sets the Inventory.
        /// </summary>
        public virtual DbSet<Inventory> Inventory
        { get; set; }

        /// <summary>
        /// Gets or sets the Language.
        /// </summary>
        public virtual DbSet<Language> Language
        { get; set; }

        /// <summary>
        /// Gets or sets the Payment.
        /// </summary>
        public virtual DbSet<Payment> Payment
        { get; set; }

        /// <summary>
        /// Gets or sets the Rental.
        /// </summary>
        public virtual DbSet<Rental> Rental
        { get; set; }

        /// <summary>
        /// Gets or sets the Staff.
        /// </summary>
        public virtual DbSet<Staff> Staff
        { get; set; }

        /// <summary>
        /// Gets or sets the Store.
        /// </summary>
        public virtual DbSet<Store> Store
        { get; set; }

        #endregion [ Tables List ]
    }
}