using System;
using System.Collections.Generic;

namespace Dyvenix.App1.Server.Entities;

public partial class LogEvent
{
    public int Id { get; set; }

    public string Message { get; set; }

    public DateTime? Timestamp { get; set; }

    public string Exception { get; set; }

    public int? LogLevel { get; set; }

    public string Application { get; set; }

    public string Source { get; set; }

    public string CorrelationId { get; set; }
}
