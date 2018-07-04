CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Sex] [nvarchar](10) NULL,
	[Birthday] [datetime] NULL,
	[Position] [nvarchar](50) NULL,
	[Comment] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[UserCreated] [int] NULL,
	[DateCreated] [datetime] NULL,
	[UserModified] [int] NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_UserCreated] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_UserCreated]
GO

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_UserModified] FOREIGN KEY([UserModified])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_UserModified]
GO