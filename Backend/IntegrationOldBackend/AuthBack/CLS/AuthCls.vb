Imports R_Common
Imports R_BackEnd
Imports System.Data
Imports System.Data.Common

Public Class AuthCls
    Public Function GetUserAuthById(poPar As GetUserAuthByIdParameterBackDTO) As GetUserAuthResultBackDTO
        Dim loException As New R_Exception
        Dim loRtn As GetUserAuthResultBackDTO
        Dim loDb As New R_Db
        Dim lcCmd As String
        Try
            lcCmd = "Select CCOMPANY_ID,CUSER_ID,CUSER_PASSWORD,CREFRESH_TOKEN,DREFRESH_TOKEN_UTC_CREATED,DREFRESH_TOKEN_UTC_EXPIRES,CTOKEN_IP_ADDRESS FROM SAM_USER_COMPANY WHERE CCOMPANY_ID={0} AND CUSER_ID={1} "
            loRtn = loDb.SqlExecObjectQuery(Of GetUserAuthResultBackDTO)(lcCmd, poPar.CCOMPANY_ID.Trim, poPar.CUSER_ID.Trim).FirstOrDefault
        Catch ex As Exception
            loException.Add(ex)
        End Try
        loException.ThrowExceptionIfErrors()

        Return loRtn
    End Function
    Public Function GetUserAuthByRefreshToken(poPar As GetUserAuthByRefreshTokenParameterBackDTO) As GetUserAuthResultBackDTO
        Dim loException As New R_Exception
        Dim loRtn As GetUserAuthResultBackDTO
        Dim loDb As New R_Db
        Dim lcCmd As String
        Try
            lcCmd = "Select CCOMPANY_ID,CUSER_ID,CUSER_PASSWORD,CREFRESH_TOKEN,DREFRESH_TOKEN_UTC_CREATED,DREFRESH_TOKEN_UTC_EXPIRES,CTOKEN_IP_ADDRESS FROM SAM_USER_COMPANY WHERE CREFRESH_TOKEN={0} "
            loRtn = loDb.SqlExecObjectQuery(Of GetUserAuthResultBackDTO)(lcCmd, poPar.CREFRESH_TOKEN.Trim).FirstOrDefault
        Catch ex As Exception
            loException.Add(ex)
        End Try
        loException.ThrowExceptionIfErrors()

        Return loRtn
    End Function
    Public Sub UpdateRefreshToken(poPar As UpdateRefreshTokenParameterBackDTO)
        Dim loException As New R_Exception
        Dim loDb As New R_Db
        Dim loCommand As DbCommand
        Dim loParameter As DbParameter
        Dim lcCmd As String
        Try
            loCommand = loDb.GetCommand()
            loCommand.CommandText = "Update SAM_USER_COMPANY Set CREFRESH_TOKEN=@Token,DREFRESH_TOKEN_UTC_CREATED=@TokenCreate,DREFRESH_TOKEN_UTC_EXPIRES=@TokenExpires,CTOKEN_IP_ADDRESS=@TokenIp WHERE CCOMPANY_ID=@CoId AND CUSER_ID=@UserId "

            'Add Parameter
            _AddParameter(loCommand, "Token", DbType.String, 500, poPar.CREFRESH_TOKEN.Trim)
            _AddParameter(loCommand, "TokenCreate", DbType.DateTime, 0, poPar.DREFRESH_TOKEN_UTC_CREATED)
            _AddParameter(loCommand, "TokenExpires", DbType.DateTime, 0, poPar.DREFRESH_TOKEN_UTC_EXPIRES)
            _AddParameter(loCommand, "TokenIp", DbType.String, 20, poPar.CTOKEN_IP_ADDRESS.Trim)
            _AddParameter(loCommand, "CoId", DbType.String, 8, poPar.CCOMPANY_ID.Trim)
            _AddParameter(loCommand, "UserId", DbType.String, 8, poPar.CUSER_ID.Trim)

            loDb.SqlExecNonQuery(loDb.GetConnection(), loCommand, True)

        Catch ex As Exception
            loException.Add(ex)
        Finally
            If loCommand IsNot Nothing Then
                loCommand.Dispose()
                loCommand = Nothing
            End If

        End Try
        loException.ThrowExceptionIfErrors()
    End Sub

    Private Sub _AddParameter(poCommand As DbCommand, pcParameterName As String, poParameterType As DbType, piParameterSize As Integer, poParameterValue As Object)
        Dim loParameter As DbParameter
        Dim loException As New R_Exception

        Try
            loParameter = poCommand.CreateParameter()
            With loParameter
                .ParameterName = pcParameterName.Trim
                .DbType = poParameterType
                .Size = piParameterSize
                .Value = poParameterValue
            End With
            poCommand.Parameters.Add(loParameter)
        Catch ex As Exception
            loException.Add(ex)
        Finally
            If loParameter IsNot Nothing Then
                loParameter = Nothing
            End If
        End Try
        loException.ThrowExceptionIfErrors()
    End Sub


End Class
