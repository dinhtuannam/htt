using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_roles")]
    public class SqlRole
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public List<SqlUser>? users { get; set; }
    }
}
