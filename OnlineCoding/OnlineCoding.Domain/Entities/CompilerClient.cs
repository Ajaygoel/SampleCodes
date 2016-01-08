using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OnlineCoding.Domain.BaseEntities;

namespace OnlineCoding.Domain.Entities
{
    public class CompilerClient : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string ClientName { get; set; }
        public string ClientIpAddress { get; set; }
        public DateTime ConnectedOn { get; set; }
        public DateTime DisconnectedOn { get; set; }
        public string IsConnected { get; set; }

        public virtual ICollection<CompileResult> CompileResults { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}