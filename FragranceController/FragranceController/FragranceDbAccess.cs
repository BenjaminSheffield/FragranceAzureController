namespace FragranceController
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FragranceDbAccess : DbContext
    {
        public FragranceDbAccess()
            : base("name=FragranceDbAccess")
        {
        }

        public virtual DbSet<Fragrance> Fragrances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
