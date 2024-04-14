using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_supplier")]
    public class SqlSupplier
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; } = "";
        public string address { get; set; } = "";
        public string phone { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public List<SqlImportBill>? bills { get; set; }
    }
}
