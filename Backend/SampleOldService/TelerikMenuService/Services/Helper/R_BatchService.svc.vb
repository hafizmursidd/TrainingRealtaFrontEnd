Imports R_Common

' NOTE: You can use the "Rename" command on the context menu to change the class name "R_BatchService" in code, svc and config file together.
Public Class R_BatchService
    Implements R_Common.IR_BatchService

    Public Sub Svc_R_DeleteBatch(ByVal poBatchPar As R_Common.R_BatchPar) Implements R_Common.IR_BatchService.Svc_R_DeleteBatch
        Dim loException As New R_Exception

        Try
            Dim loClass As New R_BackEnd.R_BatchBack

            loClass.R_DeleteBatch(poBatchPar)
        Catch ex As Exception
            loException.Add(ex)
        End Try
        loException.ConvertAndThrowToServiceExceptionIfErrors()
    End Sub

    Public Sub Svc_R_ProcessBatch(ByVal poBatchPar As R_Common.R_BatchPar, ByVal pcDll As String) Implements R_Common.IR_BatchService.Svc_R_ProcessBatch ', Optional ByVal poParameter As Object = Nothing
        Dim loException As New R_Exception

        Try
            Dim loClass As New R_BackEnd.R_BatchBack
            'Process
            loClass.R_ProcessBatch(poBatchPar, pcDll)
            'Delete after process
            loClass.R_DeleteBatch(poBatchPar)
        Catch ex As Exception
            loException.Add(ex)
        End Try
        loException.ConvertAndThrowToServiceExceptionIfErrors()
    End Sub

    Public Sub Svc_R_SaveBatch(ByVal poBatchPar As R_Common.R_BatchPar) Implements R_Common.IR_BatchService.Svc_R_SaveBatch
        Dim loException As New R_Exception

        Try
            Dim loClass As New R_BackEnd.R_BatchBack

            loClass.R_SaveBatch(poBatchPar)
        Catch ex As Exception
            loException.Add(ex)
        End Try
        loException.ConvertAndThrowToServiceExceptionIfErrors()
    End Sub
End Class
