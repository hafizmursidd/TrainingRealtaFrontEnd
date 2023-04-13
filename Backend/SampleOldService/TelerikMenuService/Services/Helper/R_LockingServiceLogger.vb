Imports R_Common

Public Class R_LockingServiceLogger
    Private Shared loLogger As R_LoggerBase

    Private Sub New()
    End Sub
    Public Shared ReadOnly Property Log() As R_LoggerBase
        Get
            Return loLogger
        End Get
    End Property
    Shared Sub New()
        loLogger = New R_LoggerBase(GetType(R_LockingServiceLogger))
    End Sub
End Class
