Imports R_Common
Imports GSI00100Back
Imports System.ServiceModel.Channels
Imports GSI00100Common
Imports GSM00200Back

' NOTE: You can use the "Rename" command on the context menu to change the class name "GSH00100StreamingService" in code, svc and config file together.
Public Class GSI00100StreamingService
    Implements IGSI00100StreamingService

    Public Function GetCmbByField() As System.ServiceModel.Channels.Message Implements IGSI00100StreamingService.GetCmbByField
        Dim loException As New R_Exception
        Dim loCls As New GSI00100Cls
        Dim loRtnTemp As List(Of CmbDTO)
        Dim loRtn As Message

        Try
            Dim lcCompId As String = R_Utility.R_GetStreamingContext("CCOMPANY_ID")

            loRtnTemp = loCls.GetCmbByField(lcCompId)

            loRtn = R_StreamUtility(Of CmbDTO).WriteToMessage(loRtnTemp.AsEnumerable, "GetCmbByField")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function GetCmbGroup() As System.ServiceModel.Channels.Message Implements IGSI00100StreamingService.GetCmbGroup
        Dim loException As New R_Exception
        Dim loCls As New GSI00100Cls
        Dim loRtnTemp As List(Of CmbDTO)
        Dim loRtn As Message

        Try
            loRtnTemp = loCls.GetCmbGroup()

            loRtn = R_StreamUtility(Of CmbDTO).WriteToMessage(loRtnTemp.AsEnumerable, "GetCmbGroup")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function GetCmbProgram() As System.ServiceModel.Channels.Message Implements IGSI00100StreamingService.GetCmbProgram
        Dim loException As New R_Exception
        Dim loCls As New GSI00100Cls
        Dim loRtnTemp As List(Of CmbDTO)
        Dim loRtn As Message

        Try
            loRtnTemp = loCls.GetCmbProgram()

            loRtn = R_StreamUtility(Of CmbDTO).WriteToMessage(loRtnTemp.AsEnumerable, "GetCmbProgram")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function GetCmbUser() As System.ServiceModel.Channels.Message Implements IGSI00100StreamingService.GetCmbUser
        Dim loException As New R_Exception
        Dim loCls As New GSI00100Cls
        Dim loRtnTemp As List(Of CmbDTO)
        Dim loRtn As Message

        Try
            loRtnTemp = loCls.GetCmbUser()

            loRtn = R_StreamUtility(Of CmbDTO).WriteToMessage(loRtnTemp.AsEnumerable, "GetCmbUser")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function GetAuditHistory() As System.ServiceModel.Channels.Message Implements IGSI00100StreamingService.GetAuditHistory
        Dim loException As New R_Exception
        Dim loCls As New GSI00100Cls
        Dim loRtnTemp As List(Of GSI00100DTOnon)
        Dim loRtn As Message
        Dim poParam As New ParameterDTO
        Dim loList As New List(Of Byte())

        Try
            With poParam
                .CCOMPANY_ID = R_Utility.R_GetStreamingContext("CCOMPANY_ID")
                .CGROUP_LIST = R_Utility.R_GetStreamingContext("CGROUP_LIST")
                .CFIELD_LIST = R_Utility.R_GetStreamingContext("CFIELD_LIST")
                .CDATE_FROM = R_Utility.R_GetStreamingContext("CDATE_FROM")
                .CDATE_TO = R_Utility.R_GetStreamingContext("CDATE_TO")
                .CUSER_LIST = R_Utility.R_GetStreamingContext("CUSER_LIST")
                .CACTION_LIST = R_Utility.R_GetStreamingContext("CACTION_LIST")
                .CPROGRAM_LIST = R_Utility.R_GetStreamingContext("CPROGRAM_LIST")
            End With

            loRtnTemp = loCls.GetAuditHistory(poParam)

            loList = R_Utility.R_GetChunkData(Of GSI00100DTOnon)(loRtnTemp, R_BackEnd.R_BackGlobalVar.CHUNK_SIZE)

            loRtn = R_StreamUtility(Of Byte()).WriteToMessage(loList.AsEnumerable, "GetAuditHistory")
            'loRtn = R_StreamUtility(Of GSI00100DTOnon).WriteToMessage(loRtnTemp.AsEnumerable, "GetAuditHistory")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Function GetAuditHistoryByPK() As System.ServiceModel.Channels.Message Implements IGSI00100StreamingService.GetAuditHistoryByPK
        Dim loException As New R_Exception
        Dim loCls As New GSI00100Cls
        Dim loRtnTemp As List(Of GSI00100DTOnon)
        Dim loRtn As Message
        Dim poParam As New ParameterDTO
        Dim loList As New List(Of Byte())

        Try
            With poParam
                .CCOMPANY_ID = R_Utility.R_GetStreamingContext("CCOMPANY_ID")
                .CTABLE_ID = R_Utility.R_GetStreamingContext("CTABLE_ID")
                .CFILTER_MODE = R_Utility.R_GetStreamingContext("CFILTER_MODE")
                .CPK_FILTER = R_Utility.R_GetStreamingContext("CPK_FILTER")
            End With

            loRtnTemp = loCls.GetAuditHistoryByPK(poParam)

            loList = R_Utility.R_GetChunkData(Of GSI00100DTOnon)(loRtnTemp, R_BackEnd.R_BackGlobalVar.CHUNK_SIZE)

            loRtn = R_StreamUtility(Of Byte()).WriteToMessage(loList.AsEnumerable, "GetAuditHistoryByPK")
            'loRtn = R_StreamUtility(Of GSI00100DTOnon).WriteToMessage(loRtnTemp.AsEnumerable, "GetAuditHistoryByPK")
        Catch ex As Exception
            loException.Add(ex)
        End Try

        loException.ConvertAndThrowToServiceExceptionIfErrors()

        Return loRtn
    End Function

    Public Sub Dummy(poPar As System.Collections.Generic.List(Of GSI00100Back.CmbDTO), poPar2 As System.Collections.Generic.List(Of GSI00100Back.ParameterDTO)) Implements IGSI00100StreamingService.Dummy

    End Sub
End Class
