using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabasePerformance.Models
{
    public class ModelWithTwoIndexes
    {
        public int Id { get; set; }

        [Index]
        [Column(TypeName = "nvarchar")]
        [MaxLength()]
        public string Text { get; set; }

        [Index]
        public DateTime Date { get; set; }
    }
}
