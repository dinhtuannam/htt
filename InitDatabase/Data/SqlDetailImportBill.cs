using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_detail_import_bill")]
    public class SqlDetailImportBill
    {
        [Key]
        public long id { get; set; }
        public int quantity { get; set; } = 0;
        public double price { get; set; } = 0;
        public double total { get; set; } = 0;
        public SqlImportBill? bill { get; set; }
        public SqlIngredient? ingredient { get; set; }
    }
}
