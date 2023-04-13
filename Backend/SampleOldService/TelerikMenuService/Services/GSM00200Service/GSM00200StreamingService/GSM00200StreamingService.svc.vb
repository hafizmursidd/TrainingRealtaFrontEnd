Imports R_Common
Imports GSM00200Back
Imports System.ServiceModel.Channels
Imports GSM00200Common

' NOTE: You can use the "Rename" command on the context menu to change the class name "GSM00200StreamingService" in code, svc and config file together.
Public Class GSM00200StreamingService
    Implements IGSM00200StreamingService

    Public Function GetTableHDList() As System.ServiceModel.Channels.Message Implements IGSM00200StreamingService.GetTableHDList
        Dim loException As New R_Exception
        Dim loCls As New GSM00200Cls
        Dim loRtnTemp As List(Of GSM00200DTOnon)
        Dim loRtn As Message
        Dim loList As New List(Of Byte())

        Try
            Dim lcCompId As String = R_Utility.R_GetStreamingContext("CCOMPANY_ID")

            loRtnTemp = loCls.GetTableHDList(lcCompId)

            loList = R_Utility.R_GetChunkData(Of GSM00200DTOnon)(loRtnTemp, R_BackEnd.R_BackGlobalVar.CHUNK_SIZE)

            loRtn = R_StreamUtility(Of Byte()).WriteToMessage(loList.AsEnumerable, "GetTableHDList")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function GetTableDTList() As System.ServiceModel.Channels.Message Implements IGSM00200StreamingService.GetTableDTList
        Dim loException As New R_Exception
        Dim loCls As New GSM00210Cls
        Dim loRtnTemp As List(Of GSM00210DTOnon)
        Dim loRtn As Message
        Dim loList As New List(Of Byte())

        Try
            Dim lcCompId As String = R_Utility.R_GetStreamingContext("CCOMPANY_ID")
            Dim lcTableId As String = R_Utility.R_GetStreamingContext("CTABLE_ID")

            loRtnTemp = loCls.GetTableDTList(lcCompId, lcTableId)

            loList = R_Utility.R_GetChunkData(Of GSM00210DTOnon)(loRtnTemp, R_BackEnd.R_BackGlobalVar.CHUNK_SIZE)

            loRtn = R_StreamUtility(Of Byte()).WriteToMessage(loList.AsEnumerable, "GetTableDTList")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function
End Class
