using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_menu_item_status")]
    public class SqlMenuItemStatus
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public List<SqlMenuItem>? menuItems { get; set; }
    }
}
