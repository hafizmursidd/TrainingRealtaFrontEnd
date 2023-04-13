Imports System.Data
Imports R_Common
Imports R_BackEnd
Imports System.Data.Common
Imports GSM00200Common
Imports R_CommonFrontBackAPI

Public Class GSM00200Cls
    Inherits R_BusinessObject(Of GSM00200DTO)

    Protected Overrides Sub R_Deleting(poEntity As GSM00200DTO)
        Dim lcQuery As String
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "DELETE GSM_AUDIT_CONFIG_HD "
            lcQuery += "WHERE CCOMPANY_ID = '{0}' AND CTABLE_ID = '{1}' "
            lcQuery = String.Format(lcQuery, poEntity.CCOMPANY_ID, poEntity.CTABLE_ID)

            loDb.SqlExecNonQuery(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
    End Sub

    Protected Overrides Function R_Display(poEntity As GSM00200DTO) As GSM00200DTO
        Dim lcQuery As String
        Dim loResult As GSM00200DTO
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT * "
            lcQuery += "FROM GSM_AUDIT_CONFIG_HD (NOLOCK) "
            lcQuery += "WHERE CCOMPANY_ID = '{0}' AND CTABLE_ID = '{1}' "
            lcQuery = String.Format(lcQuery, poEntity.CCOMPANY_ID, poEntity.CTABLE_ID)

            loResult = loDb.SqlExecObjectQuery(Of GSM00200DTO)(lcQuery).FirstOrDefault
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function

    Protected Overrides Sub R_Saving(poNewEntity As GSM00200DTO, poCRUDMode As eCRUDMode)
        Dim loEx As New R_Exception()
        Dim loDb As New R_Db()
        Dim loConn As DbConnection
        Dim lcQuery As String
        Dim loResult As GSM00200DTO

        Try
            loConn = loDb.GetConnection()

            If poCRUDMode = eCRUDMode.AddMode Then
                lcQuery = "SELECT * "
                lcQuery += "FROM GSM_AUDIT_CONFIG_HD (NOLOCK) "
                lcQuery += "WHERE CCOMPANY_ID = '{0}' AND CTABLE_ID = '{1}' "
                lcQuery = String.Format(lcQuery, poNewEntity.CCOMPANY_ID, poNewEntity.CTABLE_ID)

                loResult = loDb.SqlExecObjectQuery(Of GSM00200DTO)(lcQuery, loConn, False).FirstOrDefault
                If loResult IsNot Nothing Then
                    Throw New Exception("Table ID " + poNewEntity.CTABLE_ID.Trim + " Already Exist")
                End If

                lcQuery = "INSERT INTO GSM_AUDIT_CONFIG_HD (CCOMPANY_ID, CTABLE_ID, LAUDIT_ENABLE, CCREATE_BY, DCREATE_DATE, CUPDATE_BY, DUPDATE_DATE) "
                lcQuery += "VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{3}', {4})"
                lcQuery = String.Format(lcQuery, poNewEntity.CCOMPANY_ID, poNewEntity.CTABLE_ID, poNewEntity.LAUDIT_ENABLE, _
                                        poNewEntity.CUSER_ID, _GetDate(poNewEntity.DDATE))
                loDb.SqlExecNonQuery(lcQuery, loConn, False)

            ElseIf poCRUDMode = eCRUDMode.EditMode Then
                lcQuery = "UPDATE GSM_AUDIT_CONFIG_HD "
                lcQuery += "SET "
                lcQuery += "LAUDIT_ENABLE = '{0}', "
                lcQuery += "CUPDATE_BY = '{1}', "
                lcQuery += "DUPDATE_DATE = '{2}' "
                lcQuery += "WHERE CCOMPANY_ID = '{3}' AND CTABLE_ID = '{4}' "
                lcQuery = String.Format(lcQuery, poNewEntity.LAUDIT_ENABLE, poNewEntity.CUSER_ID, _GetDate(poNewEntity.DDATE), _
                                        poNewEntity.CCOMPANY_ID, poNewEntity.CTABLE_ID)

                loDb.SqlExecNonQuery(lcQuery, loConn, False)
            End If

        Catch ex As Exception
            loEx.Add(ex)
        Finally
            If loConn IsNot Nothing Then
                If Not (loConn.State = ConnectionState.Closed) Then
                    loConn.Close()
                End If
                loConn.Dispose()
                loConn = Nothing
            End If
        End Try

        loEx.ThrowExceptionIfErrors()
    End Sub

    Private Function _GetDate(pcDate As String) As String
        Return String.Format("CONVERT(DATETIME, '{0}')", pcDate)
    End Function

    Public Function GetTableHDList(pcCompId As String) As List(Of GSM00200DTOnon)
        Dim lcQuery As String
        Dim loResult As List(Of GSM00200DTOnon)
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT A.*, C.CTABLE_NAME FROM GSM_AUDIT_CONFIG_HD A (NOLOCK) "
            lcQuery += "INNER JOIN (SELECT DISTINCT A.CTABLE_ID FROM SAM_AUDIT_CONFIG_GROUP_TABLE A (NOLOCK)) B "
            lcQuery += "ON B.CTABLE_ID = A.CTABLE_ID "
            lcQuery += "INNER JOIN SAM_AUDIT_CONFIG_HD C (NOLOCK) "
            lcQuery += "ON C.CTABLE_ID = A.CTABLE_ID "
            lcQuery += "WHERE A.CCOMPANY_ID = '{0}' "
            lcQuery = String.Format(lcQuery, pcCompId)

            loResult = loDb.SqlExecObjectQuery(Of GSM00200DTOnon)(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function
End Class
