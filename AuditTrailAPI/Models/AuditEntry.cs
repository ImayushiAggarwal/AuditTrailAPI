using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditTrailAPI.Models
{
    public class AuditEntry
    {
       public string? EntityName { get; set; }
    public AuditAction Action { get; set; }
    public List<ChangeDetail> Changes { get; set; } = new();
    public string? UserId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}