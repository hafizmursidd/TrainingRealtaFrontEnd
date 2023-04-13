/****** Object:  Table [dbo].[GST_UPLOAD_PROCESS_STATUS]    Script Date: 2/21/2023 10:18:15 AM ******/
DROP TABLE [dbo].[GST_UPLOAD_PROCESS_STATUS]
GO

/****** Object:  Table [dbo].[GST_UPLOAD_PROCESS_STATUS]    Script Date: 2/21/2023 10:18:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GST_UPLOAD_PROCESS_STATUS](
	[CCOMPANY_ID] [varchar](10) NOT NULL,
	[CUSER_ID] [varchar](20) NOT NULL,
	[CKEY_GUID] [varchar](40) NOT NULL,
	[ISTEP] [int] NOT NULL,
	[CPROCESS_STATUS] [varchar](500) NOT NULL,
	[IFINISH] [int] NOT NULL CONSTRAINT [DF_GST_UPLOAD_PROCESS_STATUS_IFINISH]  DEFAULT ((0)),
 CONSTRAINT [PK_GST_UPLOAD_PROCESS_STATUS] PRIMARY KEY CLUSTERED 
(
	[CCOMPANY_ID] ASC,
	[CUSER_ID] ASC,
	[CKEY_GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


