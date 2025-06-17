using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuditTrailAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// git config --global user.email "you@example.com"
//   git config --global user.name "Your Name"
namespace AuditTrailAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditTrail : Controller
    {
        private readonly IAuditTrailService _auditService;

        public AuditTrail(IAuditTrailService auditService)
        {
            _auditService = auditService;
        }

        [HttpPost("track")]
        public IActionResult Track([FromBody] AuditRequestModel model)
        {
            var auditResult = _auditService.TrackChanges(model.ObjectBefore, model.ObjectAfter, model.EntityName, model.UserId, model.Action);
            return Ok(auditResult);
        }
    }
}