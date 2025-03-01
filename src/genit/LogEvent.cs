using System;

namespace Dyvenix.Genit;

public class LogEvent
{
	public int Id { get; set; }
	public DateTime TimeStamp { get; set; }
	public int LogLevel { get; set; }
	public string Application { get; set; }
	public string UserName { get; set; }
	public string Source { get; set; }
	public string CorrelationId { get; set; }
	public string Message { get; set; }
	public string Exception { get; set; }

	public bool HasException { get; set; }
	public bool ExceptionWasLoaded { get; set; }
}
