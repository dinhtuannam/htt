using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_menu_item")]
    public class SqlMenuItem : DateEntity
    {
        [Key]
        public long id { get; set; }
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public string ingredients { get; set; } = "";
        public string image_path { get; set; } = "";
        public double price { get; set; } = 0;
        public double profit { get; set; } = 0;
        public bool isdeleted { get; set; } = false;
        public SqlMenuItemStatus? status { get; set; }
        public SqlCategory? category { get; set; }
        public SqlRecipe? recipes { get; set; }
    }
}
