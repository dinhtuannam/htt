using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_invoices")]
    public class SqlInvoice
    {
        [Key]
        public long id { get; set; }
        public double amount { get; set; } = 0;
        public double discount_price { get; set; } = 0;
        public double total { get; set; } = 0;
        public bool isdeleted { get; set; } = false;
        public DateTime time { get; set; }
        public SqlDiscount? discount { get; set; }
        public List<SqlDetailOrder>? orders { get; set; }
    }
}
