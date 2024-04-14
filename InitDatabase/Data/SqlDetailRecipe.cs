using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_detail_recipe")]
    public class SqlDetailRecipe
    {
        [Key]
        public long id { get; set; }
        public decimal quantity { get; set; } = 0;
        public string unit { get; set; } = "";
        public SqlIngredient? ingredient { get; set; }
        public SqlRecipe? recipe { get; set; }
    }
}
