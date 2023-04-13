/****** Object:  UserDefinedFunction [dbo].[RFN_CombineByte]    Script Date: 2/21/2023 10:16:10 AM ******/
DROP FUNCTION [dbo].[RFN_CombineByte]
GO

/****** Object:  UserDefinedFunction [dbo].[RFN_CombineByte]    Script Date: 2/21/2023 10:16:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--Create Function RFN_CombineByte
CREATE FUNCTION [dbo].[RFN_CombineByte]
   (
    @CoId nVarchar(max),
    @UserId nVarchar(max),
    @KeyGUID nVarchar(max)
   )
RETURNS varbinary(MAX)
AS BEGIN
	Declare @FullData as varbinary(max)

	SELECT @FullData= CONVERT(VARBINARY(MAX),
    (
     SELECT CONVERT(VARCHAR(MAX), ODATA,2) AS [text()]
     FROM GST_SPLIT_UPLOAD
     WHERE CCOMPANY_ID=@CoId
	AND CUSER_ID=@UserId
	AND CKEY_GUID=@KeyGUID
	ORDER BY ISEQ_NO
     FOR XML Path('')
    ),2)

	Return coalesce(@FullData,0x)
END


GO


