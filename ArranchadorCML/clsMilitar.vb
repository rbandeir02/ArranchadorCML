Imports System.Xml.Serialization
<Serializable()>
Public Class Militar

    Private _id As Integer
    Private _usuario As String
    Private _cpf As String
    Private _senha As String
    Private _status As String
    Private _agenda As TipoAgendamento
    Public Enum TipoAgendamento
        TodoDia = 1
        SegundaQuinta = 2
        SegundaSexta = 3
    End Enum

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property

    Public Property CPF As String
        Get
            Return _cpf
        End Get
        Set(value As String)
            _cpf = value
        End Set
    End Property

    Public Property Senha As String
        Get
            Return _senha
        End Get
        Set(value As String)
            _senha = value
        End Set
    End Property

    Public Property Agenda As TipoAgendamento
        Get
            Return _agenda
        End Get
        Set(value As TipoAgendamento)
            _agenda = value
        End Set
    End Property

    Public Property AgendaView As String
        Get
            Select Case _agenda
                Case TipoAgendamento.SegundaQuinta
                    Return "SegundaQuinta"
                Case TipoAgendamento.SegundaSexta
                    Return "SegundaSexta"
                Case TipoAgendamento.TodoDia
                    Return "TodoDia"
                Case Else
                    Return ""
            End Select
        End Get
        Set(value As String)
            Select Case value
                Case "SegundaQuinta"
                    _agenda = TipoAgendamento.SegundaQuinta
                Case "SegundaSexta"
                    _agenda = TipoAgendamento.SegundaSexta
                Case "TodoDia"
                    _agenda = TipoAgendamento.TodoDia
            End Select
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public Sub New()
        _agenda = TipoAgendamento.SegundaQuinta
    End Sub
End Class
