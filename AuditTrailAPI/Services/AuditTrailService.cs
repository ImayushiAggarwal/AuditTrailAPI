using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditTrailAPI.Models;

namespace AuditTrailAPI.Services
{
    public class AuditTrailService: IAuditTrailService
    {
        public AuditEntry TrackChanges(object before, object after, string entityName, string userId, AuditAction action)
    {
        var audit = new AuditEntry
        {
            Action = action,
            EntityName = entityName,
            UserId = userId,
            Timestamp = DateTime.UtcNow
        };

        if (before == null && after != null && action == AuditAction.Created)
        {
            foreach (var prop in after.GetType().GetProperties())
            {
                audit.Changes.Add(new ChangeDetail
                {
                    PropertyName = prop.Name,
                    OldValue = null,
                    NewValue = prop.GetValue(after)
                });
            }
        }
        else if (before != null && after == null && action == AuditAction.Deleted)
        {
            foreach (var prop in before.GetType().GetProperties())
            {
                audit.Changes.Add(new ChangeDetail
                {
                    PropertyName = prop.Name,
                    OldValue = prop.GetValue(before),
                    NewValue = null
                });
            }
        }
        else if (before != null && after != null && action == AuditAction.Updated)
        {
            foreach (var prop in before.GetType().GetProperties())
            {
                var beforeValue = prop.GetValue(before);
                var afterValue = prop.GetValue(after);
                if (!Equals(beforeValue, afterValue))
                {
                    audit.Changes.Add(new ChangeDetail
                    {
                        PropertyName = prop.Name,
                        OldValue = beforeValue,
                        NewValue = afterValue
                    });
                }
            }
        }

        return audit;
    }
    }
}