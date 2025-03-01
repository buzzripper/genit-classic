USE master;

CREATE LOGIN [dyvenix_app] WITH PASSWORD = 'P@ssword1';
CREATE LOGIN [dyvenix_admin] WITH PASSWORD = 'P@ssword1';
CREATE LOGIN [dyvenix_logviewer] WITH PASSWORD = 'P@ssword1';

Use Dyvenix;

-- Admin
CREATE USER [dyvenix_admin] FOR LOGIN [dyvenix_app] WITH DEFAULT_SCHEMA=[dbo];

-- App user
CREATE USER [dyvenix_app] FOR LOGIN [dyvenix_app] WITH DEFAULT_SCHEMA=[dbo];
GRANT CONNECT, SELECT, INSERT TO [dyvenix_app];

-- Log viewer user
CREATE USER [dyvenix_logviewer] FOR LOGIN [dyvenix_logviewer] WITH DEFAULT_SCHEMA=[Logs];
GRANT SELECT, DELETE ON SCHEMA::Logs TO [dyvenix_logviewer];


CREATE TABLE [Logs].[LogEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStampUTC] [datetime] NULL,
	[LogLevel] [int] NULL,
	[Application] [nvarchar](200) NULL,
	[Source] [nvarchar](200) NULL,
	[Message] [nvarchar](max) NULL,
	[CorrelationId] [nvarchar](50) NULL,
	[Exception] [nvarchar](max) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE NONCLUSTERED INDEX IX_LogEvents_TimeStampUTC ON Logs.LogEvents (TimeStampUTC);
CREATE NONCLUSTERED INDEX IX_LogEvents_Source ON Logs.LogEvents (Source);
CREATE NONCLUSTERED INDEX IX_LogEvents_CorrelationId ON Logs.LogEvents (CorrelationId);
GO