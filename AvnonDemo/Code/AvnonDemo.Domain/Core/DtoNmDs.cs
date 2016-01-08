using System.ComponentModel.DataAnnotations;

namespace AvnonDemo.Domain.Core
{
    public abstract class DtoNmDs : Dto
    {
        [StringLength(256)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}