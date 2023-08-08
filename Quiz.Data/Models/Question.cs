using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Data.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string QuestionInWords { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string? ImageName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option1 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option2 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option3 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option4 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Answer { get; set; }
    }

    public class QuestionAnswers
    {
        public int QuestionId { get; set; }

        public string QuestionInWord { get; set; }

        public string ImageName { get; set; }

        public string[] Options { get; set; }

        public string Answer { get; set; }
    }
}
