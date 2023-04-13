Imports R_Common
Imports GSM00200Back

' NOTE: You can use the "Rename" command on the context menu to change the class name "GSM00200Service" in code, svc and config file together.
Public Class GSM00200Service
    Implements IGSM00200Service

    Public Sub Svc_R_Delete(poEntity As GSM00200Back.GSM00200DTO) Implements R_BackEnd.R_IServicebase(Of GSM00200Back.GSM00200DTO).Svc_R_Delete
        Dim loEx As New R_Exception
        Dim loCls As New GSM00200Cls

        Try
            loCls.R_Delete(poEntity)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()
    End Sub

    Public Function Svc_R_GetRecord(poEntity As GSM00200Back.GSM00200DTO) As GSM00200Back.GSM00200DTO Implements R_BackEnd.R_IServicebase(Of GSM00200Back.GSM00200DTO).Svc_R_GetRecord
        Dim loEx As New R_Exception
        Dim loCls As New GSM00200Cls
        Dim loRtn As GSM00200DTO = Nothing

        Try
            loRtn = loCls.R_GetRecord(poEntity)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function Svc_R_Save(poEntity As GSM00200Back.GSM00200DTO, poCRUDMode As R_Common.eCRUDMode) As GSM00200Back.GSM00200DTO Implements R_BackEnd.R_IServicebase(Of GSM00200Back.GSM00200DTO).Svc_R_Save
        Dim loEx As New R_Exception
        Dim loCls As New GSM00200Cls
        Dim loRtn As GSM00200DTO = Nothing

        Try
            loRtn = loCls.R_Save(poEntity, poCRUDMode)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function
End Class
