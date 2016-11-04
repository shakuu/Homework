using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabasePerformance.Data.MySql.Models
{
    public class MySqlModel
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string Text { get; set; }

        [Key, Column(Order = 1)]
        public DateTime Date { get; set; }
    }
}
