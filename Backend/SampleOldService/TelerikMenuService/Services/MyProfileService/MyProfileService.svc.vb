Imports R_Common
Imports MyProfileBack
Imports System.ServiceModel.Channels
' NOTE: You can use the "Rename" command on the context menu to change the class name "MyProfileService" in code, svc and config file together.
Public Class MyProfileService
    Implements IMyProfileService

    Public Sub Svc_R_Delete(poEntity As MyProfileBack.MyProfileDTO) Implements R_BackEnd.R_IServicebase(Of MyProfileBack.MyProfileDTO).Svc_R_Delete

    End Sub

    Public Function Svc_R_GetRecord(poEntity As MyProfileBack.MyProfileDTO) As MyProfileBack.MyProfileDTO Implements R_BackEnd.R_IServicebase(Of MyProfileBack.MyProfileDTO).Svc_R_GetRecord
        Dim loEx As New R_Exception
        Dim loCls As New MyProfileCls
        Dim loRtn As MyProfileDTO = Nothing

        Try
            loRtn = loCls.R_GetRecord(poEntity)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function Svc_R_Save(poEntity As MyProfileBack.MyProfileDTO, poCRUDMode As R_Common.eCRUDMode) As MyProfileBack.MyProfileDTO Implements R_BackEnd.R_IServicebase(Of MyProfileBack.MyProfileDTO).Svc_R_Save
        Dim loEx As New R_Exception
        Dim loCls As New MyProfileCls
        Dim loRtn As MyProfileDTO = Nothing

        Try
            loRtn = loCls.R_Save(poEntity, poCRUDMode)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function GetImage(pcUserId As String) As MyProfileBack.SliceDTO Implements IMyProfileService.GetImage
        Dim loEx As New R_Exception
        Dim loCls As New MyProfileCls
        Dim loRtn As SliceDTO

        Try
            loRtn = loCls.GetImage(pcUserId)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function
End Class
