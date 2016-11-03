using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabasePerformance.Models
{
    public class ModelWithoutIndex
    {
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        [MaxLength()]
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
