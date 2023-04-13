/****** Object:  Table [dbo].[SexTable]    Script Date: 2/22/2023 1:58:10 PM ******/
DROP TABLE [dbo].[TestSexTable]
GO

/****** Object:  Table [dbo].[TestSexTable]    Script Date: 2/22/2023 1:58:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TestSexTable](
	[SexId] [char](1) NOT NULL,
	[SexDesc] [varchar](10) NOT NULL,
 CONSTRAINT [PK_SexTable] PRIMARY KEY CLUSTERED 
(
	[SexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


