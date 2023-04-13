/****** Object:  StoredProcedure [dbo].[SampleProcessBatch]    Script Date: 2/21/2023 10:10:54 AM ******/
DROP PROCEDURE [dbo].[SampleProcessBatch]
GO

/****** Object:  StoredProcedure [dbo].[SampleProcessBatch]    Script Date: 2/21/2023 10:10:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SampleProcessBatch] 
	@CoId varchar(50)='Co01',
	@UserId varchar(50)='GY',
	@KeyGUID varchar(50)='guid1',
	@Loop int=20,
	@IsError bit=1
AS
Declare 
@ErrSeqno int,
@Step int,
@Status varchar(500),
@FinishFlag int

set @Step=1
set @ErrSeqNo=1

while (@Step<@loop) begin
	set @Status='Simulation Process Step '+cast(@step as varchar(10))
   exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step, @Status
   print @status
   
   if ((@IsError=1) and (@step % 3) =0) begin
		insert into GST_UPLOAD_ERROR_STATUS(CCOMPANY_ID,CUSER_ID,CKEY_GUID,ISEQ_NO,CERROR_MESSAGE)
		values(@CoId, @UserId, @KeyGUID, @ErrSeqNo, 'Error Step '+cast(@step as varchar(10)))
		print 'Error Step '+cast(@step as varchar(10))
		

		--Direct report error status
		set @Status='Error Step '+cast(@step as varchar(10))
		exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step, @Status, 9
		return
		
		set @ErrSeqNo=@ErrSeqNo+1
   end
   
   WAITFOR DELAY '00:00:1'
   set @Step=@Step+1
end
set @Status='Simulation Finish '+cast(@step as varchar(10))
if @IsError=0 begin
	set @FinishFlag=1
end
else begin
	set @FinishFlag=9
end

exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step, @Status, @FinishFlag



GO


