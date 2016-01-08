using System;
using System.ComponentModel.DataAnnotations;
using OnlineCoding.Domain.BaseEntities;

namespace OnlineCoding.Domain.Entities
{
    public class CompileResult : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsCompiledSuccesfully { get; set; }
        public DateTime CompiledOn { get; set; }

        public virtual CompilerClient CompilerClient { get; set; }
    }
}