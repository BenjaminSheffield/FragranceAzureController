namespace FragranceController
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FragranceReact : DbContext
    {
        public FragranceReact()
            : base("name=FragranceReact")
        {
        }

        public virtual DbSet<Fragrance> Fragrances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
