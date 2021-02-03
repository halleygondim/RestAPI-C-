using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestAPI.Models
{
    [Table("USERS")]
    public class User
    {

        [Column("ID")]
        public long Id { get; set; }

        [Column("LOGIN")]
        public string Login { get; set; }

        [Column("ACCESSKEY")]
        public string AccessKey { get; set; }
    }
}
