using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabasePerformance.Models
{
    public class ModelWithIndex
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength()]
        public string Text { get; set; }

        [Index]
        public DateTime Date { get; set; }
    }
}
