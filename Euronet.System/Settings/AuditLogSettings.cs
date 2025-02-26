

namespace Euronet.System.Settings
{
    public class AuditLogSettings //: AuditDbSettings
    {
        public string ConnectionString { get; set; }

        public string TableName { get; set; }

        public string SchemaName { get; set; }

        public bool DisableAudit { get; set; }

        public AuditLogSeverity Severity { get; set; }

    }
}
