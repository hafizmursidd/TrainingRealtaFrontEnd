/****** Object:  Table [dbo].[TestEmployeeAttachment]    Script Date: 2/21/2023 10:14:03 AM ******/
DROP TABLE [dbo].[TestEmployeeAttachment]
GO

/****** Object:  Table [dbo].[TestEmployeeAttachment]    Script Date: 2/21/2023 10:14:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TestEmployeeAttachment](
	[CoId] [varchar](10) NOT NULL,
	[EmpId] [varchar](50) NOT NULL,
	[FileName] [varchar](30) NOT NULL,
	[oData] [varbinary](max) NOT NULL,
	[FileExtension] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TestEmployeeAttachment] PRIMARY KEY CLUSTERED 
(
	[CoId] ASC,
	[EmpId] ASC,
	[FileName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


