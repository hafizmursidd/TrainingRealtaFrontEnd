Imports System.Data
Imports R_Common
Imports R_BackEnd
Imports System.Data.Common
Imports GSM00200Common
Imports R_CommonFrontBackAPI

Public Class GSM00210Cls
    Inherits R_BusinessObject(Of GSM00210DTO)

    Private Function _GetDate(pcDate As String) As String
        Return String.Format("CONVERT(DATETIME, '{0}')", pcDate)
    End Function

    Protected Overrides Sub R_Deleting(poEntity As GSM00210DTO)
        Dim lcQuery As String
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "DELETE GSM_AUDIT_CONFIG_DT "
            lcQuery += "WHERE CCOMPANY_ID = '{0}' AND CTABLE_ID = '{1}' AND CFIELD_ID = '{2}' "
            lcQuery = String.Format(lcQuery, poEntity.CCOMPANY_ID, poEntity.CTABLE_ID, poEntity.CFIELD_ID)

            loDb.SqlExecNonQuery(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
    End Sub

    Protected Overrides Function R_Display(poEntity As GSM00210DTO) As GSM00210DTO
        Dim lcQuery As String
        Dim loResult As GSM00210DTO
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT A.*, C.CFIELD_NAME FROM GSM_AUDIT_CONFIG_DT A (NOLOCK) "
            lcQuery += "INNER JOIN GSM_AUDIT_CONFIG_HD B (NOLOCK) "
            lcQuery += "ON B.CCOMPANY_ID = A.CCOMPANY_ID AND B.CTABLE_ID = A.CTABLE_ID "
            lcQuery += "INNER JOIN SAM_AUDIT_CONFIG_DT C (NOLOCK) "
            lcQuery += "ON C.CTABLE_ID = A.CTABLE_ID AND C.CFIELD_ID = A.CFIELD_ID "
            lcQuery += "WHERE A.CCOMPANY_ID = '{0}' AND A.CTABLE_ID = '{1}' AND A.CFIELD_ID = '{2}' "
            lcQuery = String.Format(lcQuery, poEntity.CCOMPANY_ID, poEntity.CTABLE_ID, poEntity.CFIELD_ID)

            loResult = loDb.SqlExecObjectQuery(Of GSM00210DTO)(lcQuery).FirstOrDefault
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function

    Protected Overrides Sub R_Saving(poNewEntity As GSM00210DTO, poCRUDMode As eCRUDMode)
        Dim loEx As New R_Exception()
        Dim loDb As New R_Db()
        Dim loConn As DbConnection
        Dim lcQuery As String
        Dim loResult As GSM00210DTO

        Try
            loConn = loDb.GetConnection()

            If poCRUDMode = eCRUDMode.AddMode Then
                'no add mode

            ElseIf poCRUDMode = eCRUDMode.EditMode Then
                lcQuery = "UPDATE GSM_AUDIT_CONFIG_DT "
                lcQuery += "SET "
                lcQuery += "LAUDIT_ENABLE = '{0}', "
                lcQuery += "CUPDATE_BY = '{1}', "
                lcQuery += "DUPDATE_DATE = {2} "
                lcQuery += "WHERE CCOMPANY_ID = '{3}' AND CTABLE_ID = '{4}' AND CFIELD_ID = '{5}' "
                lcQuery = String.Format(lcQuery, poNewEntity.LAUDIT_ENABLE, poNewEntity.CUSER_ID, _GetDate(poNewEntity.DDATE), _
                                        poNewEntity.CCOMPANY_ID, poNewEntity.CTABLE_ID, poNewEntity.CFIELD_ID)

                loDb.SqlExecNonQuery(lcQuery, loConn, False)
            End If

            lcQuery = "SELECT A.*, C.CFIELD_NAME FROM GSM_AUDIT_CONFIG_DT A (NOLOCK) "
            lcQuery += "INNER JOIN GSM_AUDIT_CONFIG_HD B (NOLOCK) "
            lcQuery += "ON B.CCOMPANY_ID = A.CCOMPANY_ID AND B.CTABLE_ID = A.CTABLE_ID "
            lcQuery += "INNER JOIN SAM_AUDIT_CONFIG_DT C (NOLOCK) "
            lcQuery += "ON C.CTABLE_ID = A.CTABLE_ID AND C.CFIELD_ID = A.CFIELD_ID "
            lcQuery += "WHERE A.CCOMPANY_ID = '{0}' AND A.CTABLE_ID = '{1}' AND A.LAUDIT_ENABLE = 1 "
            lcQuery = String.Format(lcQuery, poNewEntity.CCOMPANY_ID, poNewEntity.CTABLE_ID)

            loResult = loDb.SqlExecObjectQuery(Of GSM00210DTO)(lcQuery, loConn, False).FirstOrDefault

            lcQuery = "UPDATE GSM_AUDIT_CONFIG_HD "
            lcQuery += "SET "
            lcQuery += "LAUDIT_ENABLE = {0}, "
            lcQuery += "CUPDATE_BY = '{1}', "
            lcQuery += "DUPDATE_DATE = {2} "
            lcQuery += "WHERE CCOMPANY_ID = '{3}' AND CTABLE_ID = '{4}' "
            lcQuery = String.Format(lcQuery, IIf(loResult IsNot Nothing, 1, 0), poNewEntity.CUSER_ID, _GetDate(poNewEntity.DDATE), _
                                    poNewEntity.CCOMPANY_ID, poNewEntity.CTABLE_ID)

            loDb.SqlExecNonQuery(lcQuery, loConn, False)
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

    Public Function GetTableDTList(pcCompId As String, pcTableId As String) As List(Of GSM00210DTOnon)
        Dim lcQuery As String
        Dim loResult As List(Of GSM00210DTOnon)
        Dim loDb As New R_Db()
        Dim loEx As New R_Exception

        Try
            lcQuery = "SELECT A.*, C.CFIELD_NAME FROM GSM_AUDIT_CONFIG_DT A (NOLOCK) "
            lcQuery += "INNER JOIN GSM_AUDIT_CONFIG_HD B (NOLOCK) "
            lcQuery += "ON B.CCOMPANY_ID = A.CCOMPANY_ID AND B.CTABLE_ID = A.CTABLE_ID "
            lcQuery += "INNER JOIN SAM_AUDIT_CONFIG_DT C (NOLOCK) "
            lcQuery += "ON C.CTABLE_ID = A.CTABLE_ID AND C.CFIELD_ID = A.CFIELD_ID "
            lcQuery += "WHERE A.CCOMPANY_ID = '{0}' AND A.CTABLE_ID = '{1}' "
            lcQuery = String.Format(lcQuery, pcCompId, pcTableId)

            loResult = loDb.SqlExecObjectQuery(Of GSM00210DTOnon)(lcQuery)
        Catch ex As Exception
            loEx.Add(ex)
        End Try

        loEx.ThrowExceptionIfErrors()
        Return loResult
    End Function
End Class
