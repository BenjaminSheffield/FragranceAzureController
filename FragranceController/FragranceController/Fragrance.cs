namespace FragranceController
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fragrance
    {
        public int id { get; set; }

        public string House { get; set; }

        [Column("Fragrance")]
        public string Fragrance1 { get; set; }

        public string Rating { get; set; }

        public string Votes { get; set; }

        public string Gender { get; set; }

        public string Url_Link { get; set; }

        public string Price { get; set; }

        public string PriceURL { get; set; }

        public string TitleColumn { get; set; }
    }
}
