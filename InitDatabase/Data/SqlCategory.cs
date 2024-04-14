using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_categories")]
    public class SqlCategory
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public List<SqlMenuItem>? menuItems { get; set; }
    }
}
