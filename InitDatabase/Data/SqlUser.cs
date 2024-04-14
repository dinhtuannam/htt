using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_users")]
    public class SqlUser : DateEntity
    {
        [Key]
        public long id { get; set; }
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string email { get; set; } = "";
        public string phone { get; set; } = "";
        public string address { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public SqlRole? role { get; set; }
        public List<SqlOrder>? staffOrders { get; set; }
        public List<SqlImportBill>? bills { get; set; }
    }
}
