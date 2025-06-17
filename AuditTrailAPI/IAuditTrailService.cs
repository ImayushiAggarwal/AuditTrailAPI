using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditTrailAPI.Models;

namespace AuditTrailAPI
{
    public interface IAuditTrailService
    {
        AuditEntry TrackChanges(object before, object after, string entityName, string userId, AuditAction action);
       
    }
}