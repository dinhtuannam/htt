using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_recipes")]
    public class SqlRecipe
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public List<SqlMenuItem>? menu { get; set; }
        public List<SqlDetailRecipe>? detail_recipes { get; set;}
    }
}
