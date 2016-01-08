using System.ComponentModel.DataAnnotations;
using OnlineCoding.Domain.BaseEntities;

namespace OnlineCoding.Domain.Entities
{
    public class TestResult : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsSuccessful { get; set; }
        public string ResultDescription { get; set; }

        public virtual CompilerClient CompilerClient { get; set; }
    }
}