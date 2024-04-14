using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_orders")]
    public class SqlOrder : DateEntity
    {
        [Key]
        public long id { get; set; }
        public string customer_code { get; set; } = "";
        public double total { get; set; } = 0;
        public bool isdeleted { get; set; } = false;
        public string note { get; set; } = "";
        public SqlUser? staff { get; set; }
        public SqlTable? table { get; set; }
        public List<SqlDetailOrder>? details { get; set; }
    }
}
