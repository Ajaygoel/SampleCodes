USE [avnonDb]
GO
ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_dbo.Messages_dbo.UserModels_User_Id]
GO
ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_dbo.Images_dbo.Messages_Message_Id]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 01-06-16 5:17:58 AM ******/
DROP INDEX [IX_User_Id] ON [dbo].[Messages]
GO
/****** Object:  Index [IX_Message_Id]    Script Date: 01-06-16 5:17:58 AM ******/
DROP INDEX [IX_Message_Id] ON [dbo].[Images]
GO
/****** Object:  Table [dbo].[UserModels]    Script Date: 01-06-16 5:17:58 AM ******/
DROP TABLE [dbo].[UserModels]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 01-06-16 5:17:58 AM ******/
DROP TABLE [dbo].[Messages]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 01-06-16 5:17:58 AM ******/
DROP TABLE [dbo].[Images]
GO
/****** Object:  StoredProcedure [dbo].[udp_SaveMessage]    Script Date: 01-06-16 5:17:58 AM ******/
DROP PROCEDURE [dbo].[udp_SaveMessage]
GO
/****** Object:  StoredProcedure [dbo].[udp_SaveImage]    Script Date: 01-06-16 5:17:58 AM ******/
DROP PROCEDURE [dbo].[udp_SaveImage]
GO
/****** Object:  StoredProcedure [dbo].[udp_GetImagesByMessageId]    Script Date: 01-06-16 5:17:58 AM ******/
DROP PROCEDURE [dbo].[udp_GetImagesByMessageId]
GO
/****** Object:  StoredProcedure [dbo].[udp_GetAllMessagesByUserId]    Script Date: 01-06-16 5:17:58 AM ******/
DROP PROCEDURE [dbo].[udp_GetAllMessagesByUserId]
GO
USE [master]
GO
/****** Object:  Database [avnonDb]    Script Date: 01-06-16 5:17:58 AM ******/
DROP DATABASE [avnonDb]
GO
/****** Object:  Database [avnonDb]    Script Date: 01-06-16 5:17:58 AM ******/
CREATE DATABASE [avnonDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'avnonDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\avnonDb.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'avnonDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\avnonDb_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [avnonDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [avnonDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [avnonDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [avnonDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [avnonDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [avnonDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [avnonDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [avnonDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [avnonDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [avnonDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [avnonDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [avnonDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [avnonDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [avnonDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [avnonDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [avnonDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [avnonDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [avnonDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [avnonDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [avnonDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [avnonDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [avnonDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [avnonDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [avnonDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [avnonDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [avnonDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [avnonDb] SET  MULTI_USER 
GO
ALTER DATABASE [avnonDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [avnonDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [avnonDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [avnonDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [avnonDb]
GO
/****** Object:  StoredProcedure [dbo].[udp_GetAllMessagesByUserId]    Script Date: 01-06-16 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tarun Suneja
-- Create date: 5 Jan 2016
-- Description:	This procedure is used to get list of messages 
-- =============================================
CREATE PROCEDURE [dbo].[udp_GetAllMessagesByUserId]
	-- Add the parameters for the stored procedure here
	@UserId INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Id, 
		[Text] AS MessageBody
	FROM [Messages] WITH (NOLOCK)
	WHERE (@UserId IS NULL OR User_Id = @UserId)
	AND DateDeleted IS NULL
	ORDER BY DateCreated DESC
END

GO
/****** Object:  StoredProcedure [dbo].[udp_GetImagesByMessageId]    Script Date: 01-06-16 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tarun Suneja
-- Create date: 5 Jan 2016
-- Description:	This procedure is used to get list of images  
-- =============================================
CREATE PROCEDURE [dbo].[udp_GetImagesByMessageId]
	-- Add the parameters for the stored procedure here
	@MessageId INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Id, 
		Url
	FROM Images WITH (NOLOCK)
	WHERE (@MessageId IS NULL OR Message_Id = @MessageId)
	AND DateDeleted IS NULL
	ORDER BY DateCreated DESC
END

GO
/****** Object:  StoredProcedure [dbo].[udp_SaveImage]    Script Date: 01-06-16 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tarun Suneja
-- Create date: 5 Jan 2016
-- Description:	This procedure is used to save (insert or update) image
-- =============================================
CREATE PROCEDURE [dbo].[udp_SaveImage]
	-- Add the parameters for the stored procedure here
	@ImageId INT = NULL, 
	@MessageId INT = NULL, 
	@ImageUrl VARCHAR(MAX),
	@UserId INT,
	@IsDeleted BIT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- DECLARE Temp Variables

	IF (@IsDeleted = 1)
	BEGIN
		-- Mark Image as Deleted
		UPDATE [Images]
		SET [DateDeleted] = GETUTCDATE(),
			[DeletedBy] = @UserId
		WHERE Id = @ImageId

		RETURN
	END
	
	IF (@ImageId IS NULL OR @ImageId = 0 ) 
	BEGIN
		-- INSERT New Image
		INSERT INTO [Images]
			([Url], [Message_Id], [DateCreated], [CreatedBy])
		VALUES
			(@ImageUrl, @MessageId, GETUTCDATE(), @UserId)

		SELECT @ImageId = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		-- Update Image
		UPDATE [Images]
		SET [Url] = @ImageUrl,
			[Message_Id] = @MessageId,
			[DateLastModified] = GETUTCDATE(),
			[LastModifiedBy] = @UserId
		WHERE Id = @ImageId
	END

	SELECT 
		Id, 
		[Url],
		[Message_Id]
	FROM Images WITH (NOLOCK)
	WHERE (Id = @ImageId)
	AND DateDeleted IS NULL
	ORDER BY DateCreated DESC
END

GO
/****** Object:  StoredProcedure [dbo].[udp_SaveMessage]    Script Date: 01-06-16 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tarun Suneja
-- Create date: 5 Jan 2016
-- Description:	This procedure is used to save (insert or update) message
-- =============================================
CREATE PROCEDURE [dbo].[udp_SaveMessage]
	-- Add the parameters for the stored procedure here
	@MessageId INT = NULL, 
	@MessageText VARCHAR(MAX),
	@UserId INT,
	@IsDeleted BIT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF (@IsDeleted = 1)
	BEGIN
		-- Mark Message as Deleted
		UPDATE [Messages]
		SET [DateDeleted] = GETUTCDATE(),
			[DeletedBy] = @UserId
		WHERE Id = @MessageId

		RETURN
	END
	
	IF (@MessageId IS NULL OR @MessageId = 0 ) 
	BEGIN
		-- INSERT New Message
		INSERT INTO [Messages]
			([Text], [DateCreated], [User_Id], [CreatedBy])
		VALUES
			(@MessageText, GETUTCDATE(), @UserId, @UserId)

		SELECT @MessageId = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		-- Update Message
		UPDATE [Messages]
		SET [Text] = @MessageText,
			[User_Id] = @UserId,
			[DateLastModified] = GETUTCDATE(),
			[LastModifiedBy] = @UserId
		WHERE Id = @MessageId
	END

	SELECT 
		Id, 
		[Text] AS MessageBody
	FROM [Messages] WITH (NOLOCK)
	WHERE (Id = @MessageId)
	AND DateDeleted IS NULL
	ORDER BY DateCreated DESC
END

GO
/****** Object:  Table [dbo].[Images]    Script Date: 01-06-16 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateDeleted] [datetime] NULL,
	[DateLastModified] [datetime] NULL,
	[DateArchived] [datetime] NULL,
	[LastModifiedBy] [int] NULL,
	[DateDeactivated] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[DeletedBy] [int] NULL,
	[Message_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 01-06-16 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateDeleted] [datetime] NULL,
	[DateLastModified] [datetime] NULL,
	[DateArchived] [datetime] NULL,
	[LastModifiedBy] [int] NULL,
	[DateDeactivated] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[DeletedBy] [int] NULL,
	[User_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserModels]    Script Date: 01-06-16 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateDeleted] [datetime] NULL,
	[DateLastModified] [datetime] NULL,
	[DateArchived] [datetime] NULL,
	[LastModifiedBy] [int] NULL,
	[DateDeactivated] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[DeletedBy] [int] NULL,
 CONSTRAINT [PK_dbo.UserModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Message_Id]    Script Date: 01-06-16 5:17:58 AM ******/
CREATE NONCLUSTERED INDEX [IX_Message_Id] ON [dbo].[Images]
(
	[Message_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 01-06-16 5:17:58 AM ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[Messages]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Images_dbo.Messages_Message_Id] FOREIGN KEY([Message_Id])
REFERENCES [dbo].[Messages] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_dbo.Images_dbo.Messages_Message_Id]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.UserModels_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[UserModels] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.UserModels_User_Id]
GO
USE [master]
GO
ALTER DATABASE [avnonDb] SET  READ_WRITE 
GO
