using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_ingredients")]
    public class SqlIngredient
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public decimal quantity { get; set; } = 0;
        public string unit { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public List<SqlDetailRecipe>? detail_recipes { get; set; }
        public List<SqlDetailImportBill>? detail_bill { get; set; }
    }
}
