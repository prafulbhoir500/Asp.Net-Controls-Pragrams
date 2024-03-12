IF NOT EXISTS (SELECT * FROM sys.tables where OBJECT_ID=OBJECT_ID(N'[dbo].[UserDocument]') AND type in (N'U'))
BEGIN
	CREATE TABLE UserDocument(
	DocumentID INT IDENTITY(1,1),
	UserID INT,
    DocumentName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(1000) NOT NULL,
    UploadDate DATETIME NOT NULL DEFAULT GETDATE(),
    AttachmentTypeID INT,
	IsActive TINYINT,
	CreatedBy INT,
	CreatedOn DATE,
	RevisedBy INT,
	ReviesedOn DATE


CONSTRAINT [PK_UserDocument] PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF NOT EXISTS(SELECT * FROM sys.foreign_keys where object_id=Object_id(N'[dbo].[FK_UserDocument_mAttachmentType]') AND parent_object_id=object_id(N'[dbo].[UserDocument]'))
BEGIN
	ALTER TABLE [dbo].[UserDocument] WITH CHECK ADD CONSTRAINT [FK_UserDocument_mAttachmentType] FOREIGN KEY ([AttachmentTypeID]) REFERENCES [dbo].[mAttachmentType]([AttachmentTypeID]) 

	ALTER TABLE [dbo].[UserDocument] CHECK CONSTRAINT [FK_UserDocument_mAttachmentType]
END
GO

