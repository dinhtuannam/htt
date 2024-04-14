using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_discounts")]
    public class SqlDiscount : DateEntity
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        public int minimum { get; set; } = 0;
        public int remaining { get; set; } = 0;
        public double value { get; set; } = 0;
        public string type { get; set; } = "";
        public DateTime expiredTime { get; set; }
        public bool isdeleted { get; set; } = false;
    }
}
