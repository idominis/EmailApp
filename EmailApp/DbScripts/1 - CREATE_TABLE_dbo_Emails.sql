USE [LocalDb]
GO

/****** Object:  Table [dbo].[Emails]    Script Date: 6/5/2024 8:01:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Emails](
	[EmailId] [int] IDENTITY(1,1) NOT NULL,
	[FromEmail] [nvarchar](255) NOT NULL,
	[ToEmail] [nvarchar](255) NOT NULL,
	[CcEmails] [nvarchar](255) NULL,
	[Subject] [nvarchar](255) NOT NULL,
	[Importance] [int] NOT NULL,
	[Content] [ntext] NOT NULL,
	[CreatedDate ] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo_EmailId] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


