using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_detail_order")]
    public class SqlDetailOrder
    {
        [Key]
        public long id { get; set; }
        public double price { get; set; } = 0;
        public double profit { get; set; } = 0;
        public int quantity { get; set; } = 0;
        public double total { get; set; } = 0;
        public bool isdeleted { get; set; } = false;
        public SqlMenuItem? item { get; set; }
        public SqlOrder? order { get; set; }
        public SqlInvoice? invoice { get; set; }
    }
}
