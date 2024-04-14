using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_import_bill")]
    public class SqlImportBill
    {
        public long id { get; set; }
        public int quantity { get; set; } = 0;
        public double total { get; set; } = 0;
        public DateTime import_date { get; set; }
        public SqlUser? user { get; set; }
        public SqlSupplier? supplier { get; set; }
        public List<SqlDetailImportBill>? details { get; set; }

    }
}
