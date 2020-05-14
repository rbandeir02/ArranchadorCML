Public Class SenhaInvalidaException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(erro As String)
        MyBase.New(erro)
    End Sub

End Class
