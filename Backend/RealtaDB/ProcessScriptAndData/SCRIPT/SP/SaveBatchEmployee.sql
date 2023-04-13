/****** Object:  StoredProcedure [dbo].[SaveBatchEmployee]    Script Date: 2/21/2023 10:12:17 AM ******/
DROP PROCEDURE [dbo].[SaveBatchEmployee]
GO

/****** Object:  StoredProcedure [dbo].[SaveBatchEmployee]    Script Date: 2/21/2023 10:12:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SaveBatchEmployee] 
	@CoId varchar(50)='Co01',
	@UserId varchar(50)='GY',
	@KeyGUID varchar(50)='b'
AS
declare @cmd      varchar(5000),
			@Step int,
			@Status varchar(500)

Set @Step=1

--Reset ProcessStatus
delete dbo.GST_UPLOAD_PROCESS_STATUS
			where CCOMPANY_ID=@CoId
			and CUSER_ID=@UserId
			and CKEY_GUID=@KeyGUID
--Reset ErrorStatus
delete dbo.GST_UPLOAD_ERROR_STATUS
			where CCOMPANY_ID=@CoId
			and CUSER_ID=@UserId
			and CKEY_GUID=@KeyGUID

set @Status='[01] Validation Table Company'
exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step,  @Status
set @Step=@Step+1
print @status
-------
insert into GST_UPLOAD_ERROR_STATUS(CCOMPANY_ID,CUSER_ID,CKEY_GUID,ISEQ_NO,CERROR_MESSAGE)
select @CoId,@UserId,@KeyGUID,a.SeqNo,'[01] Validation Table Company'
	from #raw_data a (nolock) where not exists(select top 1 b.CoId from TestCompanyTable b (nolock) 
															where a.CoId = b.CoId
															)
	
set @Status='[02] Validation Table Sex'
exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step, @Status
set @Step=@Step+1
print @status
-------
insert into GST_UPLOAD_ERROR_STATUS(CCOMPANY_ID,CUSER_ID,CKEY_GUID,ISEQ_NO,CERROR_MESSAGE)
select @CoId,@UserId,@KeyGUID,a.SeqNo,'[02] Validation Table Sex'
	from #raw_data a (nolock) where not exists(select top 1 b.SexId from TestSexTable b (nolock) 
															where a.SexId = b.SexId
															)


set @Status='[03] Validation Double'
exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step, @Status
set @Step=@Step+1
print @status
-------
insert into GST_UPLOAD_ERROR_STATUS(CCOMPANY_ID,CUSER_ID,CKEY_GUID,ISEQ_NO,CERROR_MESSAGE)
select @CoId,@UserId,@KeyGUID,a.SeqNo,'[03] Validation Double'
	from #raw_data a (nolock) where exists(select top 1 b.CoId from TestEmployeeTable b (nolock) 
															where a.CoId = b.CoId
															and a.EmpId=b.EmpId
															)


if exists(select top 1 CCOMPANY_ID from GST_UPLOAD_ERROR_STATUS (nolock) where CCOMPANY_ID=@CoId and CUSER_ID=@UserId and CKEY_GUID=@KeyGUID) begin
		set @Status='[04] Insert Error File and Set Finish Flag'
		exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step, @Status, 9
		set @Step=@Step+1
			
end
else begin
	set @Status='[04] Insert employee and Set Finish Flag'
	exec RSP_WriteUploadProcessStatus @CoId, @UserId, @KeyGUID, @Step, @Status, 1
	set @Step=@Step+1

	insert into TestEmployeeTable(CoId, EmpId, FirstName, LastName, SexId, TotalChild)
	select CoId, EmpId, FirstName, LastName, SexId, TotalChild
	from #raw_data (nolock)
	
end
drop table #raw_data





GO


