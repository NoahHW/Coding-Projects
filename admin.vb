Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class admin
    Private Property _id As Integer = 0
    Private Property _username As String
    Private Property _password As String

    Public Sub New()

    End Sub
    Public Sub New(username As String, password As String)
        Me._username = username
        Me._password = password

    End Sub

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property




End Class

