/****** Object:  Table [dbo].[TestCompanyTable]    Script Date: 2/22/2023 2:05:50 PM ******/
DROP TABLE [dbo].[TestCompanyTable]
GO

/****** Object:  Table [dbo].[TestCompanyTable]    Script Date: 2/22/2023 2:05:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TestCompanyTable](
	[CoId] [char](10) NOT NULL,
	[CoNm] [varchar](30) NOT NULL,
 CONSTRAINT [PK_TestCompanyTable] PRIMARY KEY CLUSTERED 
(
	[CoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


