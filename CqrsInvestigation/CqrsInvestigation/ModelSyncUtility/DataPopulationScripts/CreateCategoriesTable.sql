USE [Northwind]
GO

/****** Object:  Table [dbo].[Categories]    Script Date: 8/3/2013 5:16:43 PM ******/
DROP TABLE [dbo].[Categories]
GO

/****** Object:  Table [dbo].[Categories]    Script Date: 8/3/2013 5:16:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
	[Descriptions] [nvarchar](max) NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK__Categori__19093A2B7F60ED59] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

