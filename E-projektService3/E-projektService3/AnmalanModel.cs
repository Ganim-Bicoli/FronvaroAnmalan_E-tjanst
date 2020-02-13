namespace E_projektService3
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AnmalanModel : DbContext
    {
        public AnmalanModel()
            : base("name=AnmalanModel")
        {
        }

        public virtual DbSet<Franvaro> Franvaro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franvaro>()
                .Property(e => e.fNamn)
                .IsUnicode(false);

            modelBuilder.Entity<Franvaro>()
                .Property(e => e.eNamn)
                .IsUnicode(false);
        }
    }
}
