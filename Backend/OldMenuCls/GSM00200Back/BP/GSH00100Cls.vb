Imports R_Common
Imports R_BackEnd
Imports System.Data.Common

Public Class GSH00100Cls

    Private Function _GetDate(pcDate As String) As String
        Return String.Format("CONVERT(DATETIME, '{0}')", pcDate)
    End Function

    Public Function GetCmbGroup() As List(Of CmbDTO)
        Dim lcQuery As String
        Dim loResult As List(Of CmbDTO)
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT CGROUP_ID AS CCODE, CGROUP_NAME AS CVALUE "
            lcQuery += "FROM SAM_AUDIT_CONFIG_GROUP_HD (NOLOCK) "

            loResult = loDb.SqlExecObjectQuery(Of CmbDTO)(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function

    Public Function GetCmbByField(pcCompId As String) As List(Of CmbDTO)
        Dim lcQuery As String
        Dim loResult As List(Of CmbDTO)
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT A.CFIELD_ID AS CCODE, C.CFIELD_NAME AS CVALUE FROM GSM_AUDIT_CONFIG_DT A (NOLOCK) "
            lcQuery += "INNER JOIN SAM_AUDIT_CONFIG_HD B (NOLOCK) "
            lcQuery += "ON B.CTABLE_ID = A.CTABLE_ID "
            lcQuery += "INNER JOIN SAM_AUDIT_CONFIG_DT C (NOLOCK) "
            lcQuery += "ON C.CFIELD_ID = A.CFIELD_ID AND C.CTABLE_ID = A.CTABLE_ID "
            lcQuery += "WHERE A.CCOMPANY_ID = '{0}' AND A.LAUDIT_ENABLE = 1 "
            lcQuery = String.Format(lcQuery, pcCompId)

            loResult = loDb.SqlExecObjectQuery(Of CmbDTO)(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function

    Public Function GetCmbUser() As List(Of CmbDTO)
        Dim lcQuery As String
        Dim loResult As List(Of CmbDTO)
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT CUSER_ID AS CCODE, CUSER_NAME AS CVALUE "
            lcQuery += "FROM SAM_USER (NOLOCK) "

            loResult = loDb.SqlExecObjectQuery(Of CmbDTO)(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function

    Public Function GetCmbProgram() As List(Of CmbDTO)
        Dim lcQuery As String
        Dim loResult As List(Of CmbDTO)
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT CPROGRAM_ID AS CCODE, CPROGRAM_NAME AS CVALUE "
            lcQuery += "FROM SAM_PROGRAM (NOLOCK) "

            loResult = loDb.SqlExecObjectQuery(Of CmbDTO)(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function

    Public Function GetAuditHistory(poParam As ParameterDTO) As List(Of GSH00100DTOnon)
        Dim lcQuery As String
        Dim loResult As List(Of GSH00100DTOnon)
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception
        Dim loCmd As DbCommand
        Dim loPar As DbParameter
        Dim loConn As DbConnection
        Dim loRtn As DataTable

        Try
            loConn = loDb.GetConnection()

            loCmd = loDb.GetCommand()
            With poParam
                lcQuery = "EXEC RSP_GetAuditHistory "
                lcQuery += "@CCOMPANY_ID, @CGROUP_LIST, @CFIELD_LIST, @CDATE_FROM, @CDATE_TO, @CUSER_LIST, @CACTION_LIST, @CPROGRAM_LIST "
                'lcQuery = String.Format(lcQuery)
            End With
            loCmd.CommandText = lcQuery

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CCOMPANY_ID"
                .DbType = DbType.String
                .Value = IIf(poParam.CCOMPANY_ID Is Nothing, DBNull.Value, poParam.CCOMPANY_ID)
            End With
            loCmd.Parameters.Add(loPar)

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CGROUP_LIST"
                .DbType = DbType.String
                .Value = IIf(poParam.CGROUP_LIST Is Nothing, DBNull.Value, poParam.CGROUP_LIST)
            End With
            loCmd.Parameters.Add(loPar)

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CFIELD_LIST"
                .DbType = DbType.String
                .Value = IIf(poParam.CFIELD_LIST Is Nothing, DBNull.Value, poParam.CFIELD_LIST)
            End With
            loCmd.Parameters.Add(loPar)

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CDATE_FROM"
                .DbType = DbType.String
                .Value = IIf(poParam.CDATE_FROM Is Nothing, DBNull.Value, poParam.CDATE_FROM)
            End With
            loCmd.Parameters.Add(loPar)

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CDATE_TO"
                .DbType = DbType.String
                .Value = IIf(poParam.CDATE_TO Is Nothing, DBNull.Value, poParam.CDATE_TO)
            End With
            loCmd.Parameters.Add(loPar)

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CUSER_LIST"
                .DbType = DbType.String
                .Value = IIf(poParam.CUSER_LIST Is Nothing, DBNull.Value, poParam.CUSER_LIST)
            End With
            loCmd.Parameters.Add(loPar)

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CACTION_LIST"
                .DbType = DbType.String
                .Value = IIf(poParam.CACTION_LIST Is Nothing, DBNull.Value, poParam.CACTION_LIST)
            End With
            loCmd.Parameters.Add(loPar)

            loPar = loDb.GetParameter()
            With loPar
                .ParameterName = "@CPROGRAM_LIST"
                .DbType = DbType.String
                .Value = IIf(poParam.CPROGRAM_LIST Is Nothing, DBNull.Value, poParam.CPROGRAM_LIST)
            End With
            loCmd.Parameters.Add(loPar)

            loRtn = loDb.SqlExecQuery(loConn, loCmd, True)
            loRtn.AcceptChanges()
            loRtn.TableName = "ResultTable"

            loResult = R_Utility.R_ConvertTo(Of GSH00100DTOnon)(loRtn)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function
End Class
