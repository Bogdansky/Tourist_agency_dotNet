namespace Desktop_Tourism.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<adobe> adobe { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<client_info> client_info { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<data> data { get; set; }
        public virtual DbSet<manager> manager { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<resort> resort { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tour> tour { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adobe>()
                .Property(e => e.hotel_class)
                .IsUnicode(false);

            modelBuilder.Entity<adobe>()
                .HasMany(e => e.order)
                .WithOptional(e => e.adobe)
                .HasForeignKey(e => e.id_adobe);

            modelBuilder.Entity<client>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasOptional(e => e.client_info)
                .WithRequired(e => e.client);

            modelBuilder.Entity<client>()
                .HasMany(e => e.order)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.id_client);

            modelBuilder.Entity<client_info>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<client_info>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<client_info>()
                .Property(e => e.patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.visa_regime)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .HasMany(e => e.resort)
                .WithOptional(e => e.country)
                .HasForeignKey(e => e.id_country);

            modelBuilder.Entity<data>()
                .HasMany(e => e.client_info)
                .WithOptional(e => e.data)
                .HasForeignKey(e => e.id_photo);

            modelBuilder.Entity<data>()
                .HasMany(e => e.resort)
                .WithOptional(e => e.data)
                .HasForeignKey(e => e.id_video);

            modelBuilder.Entity<manager>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<manager>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<manager>()
                .Property(e => e.patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<manager>()
                .HasMany(e => e.tour)
                .WithOptional(e => e.manager)
                .HasForeignKey(e => e.id_manager);

            modelBuilder.Entity<resort>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<resort>()
                .HasMany(e => e.tour)
                .WithOptional(e => e.resort)
                .HasForeignKey(e => e.id_resort);

            modelBuilder.Entity<tour>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tour>()
                .HasMany(e => e.order)
                .WithOptional(e => e.tour)
                .HasForeignKey(e => e.id_tour);
        }
    }
}
