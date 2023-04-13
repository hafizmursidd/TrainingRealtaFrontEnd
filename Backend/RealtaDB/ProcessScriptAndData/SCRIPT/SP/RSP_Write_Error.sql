/****** Object:  StoredProcedure [dbo].[RSP_Write_Error]    Script Date: 2/24/2023 10:36:38 AM ******/
DROP PROCEDURE [dbo].[RSP_Write_Error]
GO

/****** Object:  StoredProcedure [dbo].[RSP_Write_Error]    Script Date: 2/24/2023 10:36:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[RSP_Write_Error] 
	@RECID int,
	@Error_Code varchar(20),
	@Detail nvarchar(max)
AS

IF (OBJECT_ID('tempdb..#__SP_ERR_Table') is null) BEGIN
	select SP_Name=cast('' as varchar(50)), Err_Code=cast('' as varchar(20)), Err_Detail=cast('' as nvarchar(max)) into #__SP_ERR_Table where 0=1
end

insert into #__SP_ERR_Table(SP_Name, Err_Code, Err_Detail) 
values(OBJECT_NAME(@RECID),@Error_Code, @Detail)

GO


