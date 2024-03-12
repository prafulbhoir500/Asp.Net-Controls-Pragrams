IF NOT EXISTS (SELECT * FROM sys.tables where OBJECT_ID=OBJECT_ID(N'[dbo].[mAttachmentType]') AND type in (N'U'))
BEGIN
	CREATE TABLE mAttachmentType(
	AttachmentTypeID INT IDENTITY(1,1),
	UserType INT,
	AttachmentID INT,
	TabName VARCHAR(50),
	IsActive TINYINT,
	CreatedBy INT,
	CreatedOn DATE,
	RevisedBy INT,
	ReviesedOn DATE

CONSTRAINT [PK_mAttachmentType] PRIMARY KEY CLUSTERED 
(
	[AttachmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

IF NOT EXISTS(SELECT * FROM sys.foreign_keys where object_id=Object_id(N'[dbo].[FK_mAttachmentType_mAttachment]') AND parent_object_id=object_id(N'[dbo].[mAttachmentType]'))
BEGIN
	ALTER TABLE [dbo].[mAttachmentType] WITH CHECK ADD CONSTRAINT [FK_mAttachmentType_mAttachment] FOREIGN KEY ([AttachmentID]) REFERENCES [dbo].[mAttachment]([AttachmentID]) 

	ALTER TABLE [dbo].[mAttachmentType] CHECK CONSTRAINT [FK_mAttachmentType_mAttachment]
END
GO