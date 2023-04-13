Imports R_Common
Imports GSM00200Back
' NOTE: You can use the "Rename" command on the context menu to change the class name "GSM00210Service" in code, svc and config file together.
Public Class GSM00210Service
    Implements IGSM00210Service

    Public Sub Svc_R_Delete(poEntity As GSM00200Back.GSM00210DTO) Implements R_BackEnd.R_IServicebase(Of GSM00200Back.GSM00210DTO).Svc_R_Delete
        Dim loEx As New R_Exception
        Dim loCls As New GSM00210Cls

        Try
            loCls.R_Delete(poEntity)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()
    End Sub

    Public Function Svc_R_GetRecord(poEntity As GSM00200Back.GSM00210DTO) As GSM00200Back.GSM00210DTO Implements R_BackEnd.R_IServicebase(Of GSM00200Back.GSM00210DTO).Svc_R_GetRecord
        Dim loEx As New R_Exception
        Dim loCls As New GSM00210Cls
        Dim loRtn As GSM00210DTO = Nothing

        Try
            loRtn = loCls.R_GetRecord(poEntity)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function Svc_R_Save(poEntity As GSM00200Back.GSM00210DTO, poCRUDMode As R_Common.eCRUDMode) As GSM00200Back.GSM00210DTO Implements R_BackEnd.R_IServicebase(Of GSM00200Back.GSM00210DTO).Svc_R_Save
        Dim loEx As New R_Exception
        Dim loCls As New GSM00210Cls
        Dim loRtn As GSM00210DTO = Nothing

        Try
            loRtn = loCls.R_Save(poEntity, poCRUDMode)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function
End Class
