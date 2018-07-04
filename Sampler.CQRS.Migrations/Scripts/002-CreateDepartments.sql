CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[UserCreated] [int] NULL,
	[DateCreated] [datetime] NULL,
	[UserModified] [int] NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [DF_Departments_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_UserCreated] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_UserCreated]
GO

ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_UserModified] FOREIGN KEY([UserModified])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_UserModified]
GO