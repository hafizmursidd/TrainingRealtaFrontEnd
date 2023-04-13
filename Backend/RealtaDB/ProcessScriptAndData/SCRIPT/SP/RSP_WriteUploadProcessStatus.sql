/****** Object:  StoredProcedure [dbo].[RSP_WriteUploadProcessStatus]    Script Date: 2/24/2023 10:37:05 AM ******/
DROP PROCEDURE [dbo].[RSP_WriteUploadProcessStatus]
GO

/****** Object:  StoredProcedure [dbo].[RSP_WriteUploadProcessStatus]    Script Date: 2/24/2023 10:37:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RSP_WriteUploadProcessStatus] 
	@CoId varchar(50),
	@UserId varchar(50),
	@KeyGUID varchar(50),
	@Step int,
	@Status varchar(500),
	@Finish int=0 --0=Process, 1=Success, 9=Fail
AS
BEGIN
	if exists(select CCOMPANY_ID from GST_UPLOAD_PROCESS_STATUS(nolock)
					where CCOMPANY_ID=@CoId
					and CUSER_ID=@UserId
					and CKEY_GUID=@KeyGUID
					) begin
		update GST_UPLOAD_PROCESS_STATUS
			set IStep=@Step,
			CPROCESS_STATUS=@Status,
			IFINISH=@Finish
		where CCOMPANY_ID=@CoId
		and CUSER_ID=@UserId
		and CKEY_GUID=@KeyGUID
	end
	else begin
		insert into GST_UPLOAD_PROCESS_STATUS(CCOMPANY_ID, CUSER_ID, CKEY_GUID, ISTEP,  CPROCESS_STATUS, IFINISH)
		values(@CoId, @UserId, @KeyGUID,@Step,   @Status, @Finish)
	end
END
GO


