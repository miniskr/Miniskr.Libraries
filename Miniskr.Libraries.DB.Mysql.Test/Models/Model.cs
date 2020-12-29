using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Miniskr.Libraries.DB.Mysql.Test.Models
{
    public abstract class Model
    {
        [Key, Identity]
        public long Id { get; set; }
        public DateTime CreateAt { get; set; }
    }

    [Table("User")]
    public class User : Model
    {
        public long EnterpriseId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Table("Enterprise")]
    public class Enterprise : Model
    {
        public string Name { get; set; }
    }
}
