using Pagila.Entity;
using SimpleFileLogging.Enums;
using SimpleFileLogging.Interfaces;
using Coddie.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Pagila.Context
{
    /// <summary>
    /// Defines the <see cref="PublicDbContext"/>.
    /// </summary>
    public class PublicDbContext : DbContext
    {
        /// <summary>
        /// Defines the logger.
        /// </summary>
        private readonly ISimpleLogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicDbContext"/> class.
        /// </summary>
        public PublicDbContext() : base($"name={nameof(PublicDbContext)}")
        {
            Database.SetInitializer<PublicDbContext>(null);
            logger =
            SimpleFileLogging.SimpleFileLogger.Instance;
            logger.LogDateFormatType = SimpleLogDateFormats.None;
            this.Database.Log = LogQueries;
        }

        /// <summary>
        /// The LogQueries
        /// </summary>
        /// <param name="q">The q <see cref="string"/>.</param>
        protected void LogQueries(string q)
        {
            logger?.Debug(q);
        }

        /// <summary>
        /// The OnModelCreating method.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

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
            modelBuilder.Ignore(types);

            # endregion [ Ignoring Tables Have No Key property ]

            #region [ Mapping Entities To Tables ]

            modelBuilder.Entity<Payment>().ToTable(typeof(Payment).GetTableNameOfType());

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