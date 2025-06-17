# AuditTrail API

## Objective
An enterprise-grade .NET Core Web API to track object changes and provide audit logging with metadata.

## Features
- Supports Created, Updated, Deleted actions
- Tracks only changed fields
- Metadata: Timestamp, User ID, Entity Name
- Easily pluggable into existing apps

## API Endpoint

**POST /api/audittrail/track**

### Request Body

```json
{
  "objectBefore": { "Name": "John", "Age": 30 },
  "objectAfter": { "Name": "John", "Age": 31 },
  "entityName": "User",
  "userId": "user123",
  "action": "Updated"
}

###Response 
{
  "entityName": "User",
  "action": "Updated",
  "userId": "user123",
  "timestamp": "2025-06-16T10:30:00Z",
  "changes": [
    {
      "propertyName": "Age",
      "oldValue": 30,
      "newValue": 31
    }
  ]
}

