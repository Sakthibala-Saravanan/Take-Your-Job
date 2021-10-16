IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[EmailId] [nvarchar](255) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](20) NOT NULL,
	[State] [nvarchar](10) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedByUserId] [uniqueidentifier] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedByUserId] [uniqueidentifier] NULL,
	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
