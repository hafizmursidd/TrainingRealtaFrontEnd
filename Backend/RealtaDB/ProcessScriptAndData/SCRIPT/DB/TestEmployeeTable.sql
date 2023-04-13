/****** Object:  Table [dbo].[EmployeeTable]    Script Date: 2/22/2023 1:54:14 PM ******/
DROP TABLE [dbo].[TestEmployeeTable]
GO

/****** Object:  Table [dbo].[TestEmployeeTable]    Script Date: 2/22/2023 1:54:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TestEmployeeTable](
	[CoId] [char](10) NOT NULL,
	[EmpId] [char](20) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL CONSTRAINT [DF_TestEmployeeTable_LastName]  DEFAULT (''),
	[SexId] [char](1) NOT NULL,
	[TotalChild] [int] NOT NULL CONSTRAINT [DF_TestEmployeeTable_TotalChild]  DEFAULT ((0)),
 CONSTRAINT [PK_TestEmployeeTable] PRIMARY KEY CLUSTERED 
(
	[CoId] ASC,
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


