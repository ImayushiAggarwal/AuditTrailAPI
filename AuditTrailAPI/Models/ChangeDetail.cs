using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditTrailAPI.Models
{
    public class ChangeDetail
    {
        public string? PropertyName { get; set; }
    public object? OldValue { get; set; }
    public object? NewValue { get; set; }
    }
}