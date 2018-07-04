CREATE TABLE [dbo].[DepartmentEmployees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[UserCreated] [int] NULL,
	[DateCreated] [datetime] NULL,
	[UserModified] [int] NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_DepartmentEmployees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DepartmentEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentEmployees_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO

ALTER TABLE [dbo].[DepartmentEmployees] CHECK CONSTRAINT [FK_DepartmentEmployees_Departments]
GO

ALTER TABLE [dbo].[DepartmentEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentEmployees_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO

ALTER TABLE [dbo].[DepartmentEmployees] CHECK CONSTRAINT [FK_DepartmentEmployees_Employees]
GO

ALTER TABLE [dbo].[DepartmentEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentEmployees_UserCreated] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[DepartmentEmployees] CHECK CONSTRAINT [FK_DepartmentEmployees_UserCreated]
GO

ALTER TABLE [dbo].[DepartmentEmployees]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentEmployees_UserModified] FOREIGN KEY([UserModified])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[DepartmentEmployees] CHECK CONSTRAINT [FK_DepartmentEmployees_UserModified]
GO