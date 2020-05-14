
Imports System.IO
Imports System.Xml.Serialization
Imports log4net.Config
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Public Class frmArranchador

    Private _lstMilitares As List(Of Militar)
    Private binding As BindingSource
    Private dtUltimoArranchamento As Date
    Private Shared oLog As log4net.ILog

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim xml_serializer As New XmlSerializer(GetType(List(Of Militar)))
        Dim string_reader As StringReader

        Try
            tmrHorario.Interval = New TimeSpan(0, 0, 1).TotalMilliseconds
            tmrHorario.Start()
            lblStatus.ForeColor = Color.Black
            lblStatus.Text = "Parado"
            'oLog = log4net.LogManager.GetLogger("Log4NetAssembly1")
            ' log4net.Config.XmlConfigurator.Configure()
            oLog = log4net.LogManager.GetLogger("ArranchadorCML")
            log4net.Config.XmlConfigurator.Configure(New IO.FileInfo(System.AppDomain.CurrentDomain.CurrentDomain.BaseDirectory & "log4net.config"))
            'tmrRancho.Start()
            Log("Arranchador CML iniciado!")
            'Carrego o arquivo
            If (IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "militares.xml") = True) Then
                string_reader = New StringReader(IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "militares.xml"))
                _lstMilitares = DirectCast(xml_serializer.Deserialize(string_reader), List(Of Militar))
                string_reader.Close()
            Else
                _lstMilitares = New List(Of Militar)
            End If

            binding = New BindingSource()
            binding.DataSource = Nothing
            binding.DataSource = _lstMilitares

            dgMilitares.AutoGenerateColumns = False
            dgMilitares.AutoSize = True
            dgMilitares.DataSource = binding
            dgMilitares.Refresh()

            ConfiguraGrid()

            CarregaAgenda()

        Catch ex As Exception
            MessageBox.Show("Erro: " & ex.Message)
            Close()
        Finally
            xml_serializer = Nothing
            string_reader = Nothing
        End Try

    End Sub

    Private Sub btnFechat_Click(sender As Object, e As EventArgs) Handles btnFechat.Click
        Close()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        Try
            GravarArquivoMilitares()
            MessageBox.Show(Me, "Dados salvos com sucesso.", "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(Me, "Erro: " & ex.Message, "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ConfiguraGrid()

        Dim column As DataGridViewColumn = New DataGridViewTextBoxColumn()
        column.DataPropertyName = "Id"
        column.Name = "Id"
        column.Width = 30
        dgMilitares.Columns.Add(column)

        column = New DataGridViewTextBoxColumn()
        column.DataPropertyName = "Usuario"
        column.Name = "Usuário"
        column.Width = 150
        dgMilitares.Columns.Add(column)

        column = New DataGridViewTextBoxColumn()
        column.DataPropertyName = "CPF"
        column.Name = "CPF"
        column.Width = 90
        dgMilitares.Columns.Add(column)

        column = New DataGridViewTextBoxColumn()
        column.DataPropertyName = "Senha"
        column.Name = "Senha"
        column.Width = 80
        dgMilitares.Columns.Add(column)

        Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        combo.DataSource = {"TodoDia", "SegundaQuinta", "SegundaSexta"}
        combo.DataPropertyName = "AgendaView"
        combo.Name = "Dia da Semana"
        combo.Width = 120
        dgMilitares.Columns.Add(combo)

        column = New DataGridViewTextBoxColumn()
        column.DataPropertyName = "Status"
        column.Name = "Último Status"
        column.Width = 454
        column.ReadOnly = True
        dgMilitares.Columns.Add(column)

        'With dgMilitares

        '    .Columns(0).HeaderText = "Id"
        '    .Columns(0).Width = 30
        '    ' .Columns(0).DisplayIndex = 1
        '    .Columns(0).DataPropertyName = "Id"

        '    Dim column As DataGridViewColumn = New DataGridViewTextBoxColumn()
        '    .Columns(1).HeaderText = "Usuário"
        '    .Columns(1).Width = 70
        '    ' .Columns(1).DisplayIndex = 2
        '    .Columns(1).DataPropertyName = "Usuario"

        '    .Columns(2).HeaderText = "CPF"
        '    .Columns(2).Width = 70
        '    '.Columns(2).DisplayIndex = 3
        '    .Columns(2).DataPropertyName = "CPF"

        '    .Columns(3).HeaderText = "Senha"
        '    .Columns(3).Width = 70
        '    '  .Columns(3).DisplayIndex = 4
        '    .Columns(3).DataPropertyName = "Senha"

        '.Columns(4).DisplayIndex = 5
        '.Columns(4).DataPropertyName = "Agenda"
        '.Columns(4).HeaderText = "Dia da Semana"
        '.Columns(4).Width = 100

        ' .Columns(4).HeaderText = "Último Status"
        '.Columns(4).Width = 268
        ' .Columns(4).DisplayIndex = 5
        ' .Columns(4).ReadOnly = True
        ' .Columns(4).DataPropertyName = "Status"

        ''adiciono o combobox column
        'Dim comboBoxCol As New DataGridViewComboBoxColumn
        'comboBoxCol.HeaderText = "Dia da Semana"
        'comboBoxCol.Items.Add("TodoDia")
        'comboBoxCol.Items.Add("SegundaQuinta")
        'comboBoxCol.Items.Add("SegundaSexta")

        ''---Inclui a coluna combobox ao DataGridView---
        'dgMilitares.Columns.Add(comboBoxCol)
        '.Columns(6).DisplayIndex = 4
        '.Columns(6).Width = 110

        '.Columns(4).Visible = False



        ' End With
        dgMilitares.Refresh()
    End Sub

    Private Sub dgMilitares_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgMilitares.CellValidated
        'MessageBox.Show("teste")
        'If e.ColumnIndex = 5 Then
        '    MessageBox.Show(dgMilitares.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)



        'End If
    End Sub

    Private Sub dgMilitares_ColumnDisplayIndexChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgMilitares.ColumnDisplayIndexChanged
        'MessageBox.Show("teste2")
    End Sub

    Private Sub dgMilitares_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgMilitares.CellValueChanged
        Dim oMilitar As Militar
        If e.ColumnIndex = 5 Then
            'MessageBox.Show(dgMilitares.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
            'oMilitar = RecuperarMilitar(dgMilitares.Rows(e.RowIndex).Cells(0).Value)
            'If IsNothing(oMilitar) = False Then
            '    Select Case dgMilitares.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            '        Case "TodoDia"
            '            oMilitar.Agenda = Militar.TipoAgendamento.TodoDia
            '        Case "SegundaQuinta"
            '            oMilitar.Agenda = Militar.TipoAgendamento.SegundaQuinta
            '        Case "SegundaSexta"
            '            oMilitar.Agenda = Militar.TipoAgendamento.SegundaSexta
            '    End Select
            '    dgMilitares.Refresh()
            'End If
        End If
    End Sub

    Private Function RecuperarMilitar(id As Integer)
        For Each oMilitar In _lstMilitares
            If oMilitar.Id = id Then
                Return oMilitar
            End If
        Next
        Return Nothing
    End Function

    Private Sub CarregaAgenda()
        Dim r As DataGridViewRow
        'For Each r In dgMilitares.Rows
        '    'MessageBox.Show(r.Cells(3).Value)
        '    Select Case r.Cells(3).Value
        '        Case Militar.TipoAgendamento.TodoDia
        '            r.Cells(4).Value = "TodoDia"
        '        Case Militar.TipoAgendamento.SegundaQuinta
        '            r.Cells(4).Value = "SegundaQuinta"
        '        Case Militar.TipoAgendamento.SegundaSexta
        '            r.Cells(4).Value = "SegundaSexta"
        '    End Select

        'Next
    End Sub

    Private Sub tmrRancho_Tick(sender As Object, e As EventArgs) Handles tmrRancho.Tick

        txtUltimaExecucao.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        txtProximaExecucao.Text = Format(Now.Date.AddDays(1), "dd/MM/yyyy hh:mm:ss")

        Try
            Me.Cursor = Cursors.WaitCursor
            lblStatus.ForeColor = Color.Green
            lblStatus.Text = "Executando..."
            For Each militar In _lstMilitares
                Try
                    Log("==== Arranchando o militar " & militar.Usuario & " na agenda " & militar.AgendaView & "====")
                    Arranchar(militar)
                    militar.Status = "Arranchamento realizado em " & Format(Now, "dd/MM/yyyy HH:mm:ss") & "!"
                    Log("Arranchamento realizado em " & Format(Now, "dd/MM/yyyy HH:mm:ss") & "!")
                    lblHorário.Text = "Execução OK em " & Format(Now, "dd/MM/yyyy hh:mm:ss")
                    dgMilitares.Refresh()
                    GravarArquivoMilitares()
                Catch ex2 As SenhaInvalidaException
                    militar.Status = "Senha inválida!"
                    Log("Senha do Militar " & militar.Usuario & " é inválida!")
                    dgMilitares.Refresh()
                    GravarArquivoMilitares()
                Catch ex1 As Exception
                    militar.Status = "Erro: " & ex1.Message
                    Log("Erro ao arranchar militar " & militar.Usuario & ": " & ex1.Message)
                    dgMilitares.Refresh()
                    GravarArquivoMilitares()
                End Try
            Next

            'MessageBox.Show(Me, "Arranchamento realizado com sucesso. ", "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'MessageBox.Show(Me, "Erro realizando arranchamento: " & ex.Message, "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Log("Erro realizando arranchamento: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            lblStatus.ForeColor = Color.Black
            lblStatus.Text = "Parado"
        End Try
    End Sub

    Private Sub btnExecutarAgora_Click(sender As Object, e As EventArgs) Handles btnExecutarAgora.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            lblStatus.ForeColor = Color.Green
            lblStatus.Text = "Executando..."
            For Each militar In _lstMilitares
                Try
                    Log("==== Arranchando o militar " & militar.Usuario & " na agenda " & militar.AgendaView & "====")
                    Arranchar(militar)
                    militar.Status = "Arranchamento realizado em " & Format(Now, "dd/MM/yyyy HH:mm:ss") & "!"
                    Log("Arranchamento realizado em " & Format(Now, "dd/MM/yyyy HH:mm:ss") & "!")
                    dgMilitares.Refresh()
                    GravarArquivoMilitares()
                Catch ex2 As SenhaInvalidaException
                    militar.Status = "Senha inválida!"
                    Log("Senha do Militar " & militar.Usuario & " é inválida!")
                    dgMilitares.Refresh()
                    GravarArquivoMilitares()
                Catch ex1 As Exception
                    militar.Status = "Erro: " & ex1.Message
                    Log("Erro ao arranchar militar " & militar.Usuario & ": " & ex1.Message)
                    dgMilitares.Refresh()
                    GravarArquivoMilitares()
                End Try
            Next

            MessageBox.Show(Me, "Arranchamento realizado com sucesso. ", "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(Me, "Erro realizando arranchamento: " & ex.Message, "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            lblStatus.ForeColor = Color.Black
            lblStatus.Text = "Parado"
        End Try


    End Sub

    Private Sub Arranchar(oMilitar As Militar)

        Dim driver As IWebDriver, chromeService As ChromeDriverService, cOptions As ChromeOptions
        Dim element As IWebElement, alert As IAlert
        Dim lsElements As IList(Of IWebElement)
        Dim strURLRancho As String, dia As Date
        Dim uriRancho As Uri, i As Integer
        'Dim phantomService As OpenQA.Selenium.Phan
        Try
        strURLRancho = My.Settings.URLRancho.ToString()
            If Strings.Trim(strURLRancho) = "" Then
                Throw New Exception("Erro ao carregar URL da página do Rancho!")
            End If
            uriRancho = New Uri(strURLRancho)

            'Inicializa e abre a página inicial
            chromeService = ChromeDriverService.CreateDefaultService()
            chromeService.HideCommandPromptWindow = True
            cOptions = New ChromeOptions()
            cOptions.AddArgument("--incognito")
            cOptions.AddArgument("--disable-extensions")
            cOptions.AddArgument("headless")


            driver = New ChromeDriver(chromeService, cOptions)
            'phantomService = New NReco.PhantomJS.PhantomJS()
            driver.Manage.Timeouts.ImplicitWait = TimeSpan.FromSeconds(10)
            'phantomService.
            driver.Navigate().GoToUrl(strURLRancho)
            'WaitForLoad(driver, 30)
            System.Threading.Thread.Sleep(5000)
            'Verifica se há o alert de entrada
            Try
                alert = driver.SwitchTo().Alert()
                alert.Accept()
            Catch ex As Exception

            End Try

            Log("Iniciado!")
            'Faz o logon
            element = driver.FindElement(By.Id("txUsuario"))
            element.SendKeys(oMilitar.CPF)
            System.Threading.Thread.Sleep(2000)
            element = driver.FindElement(By.Id("txSenha"))
            element.SendKeys(oMilitar.Senha)
            element = driver.FindElement(By.XPath("//input[@value='Entrar']"))
            element.Click()

            'Verifica se logou corretamente
            System.Threading.Thread.Sleep(5000)
            Try
                alert = driver.SwitchTo().Alert()
                If (alert.Text.Contains("Inválidos")) Then
                    alert.Accept()
                    Throw New SenhaInvalidaException("Senha incorreta.")
                End If
                alert.Accept()
            Catch ex1 As SenhaInvalidaException
                Throw ex1
            Catch ex As Exception

            End Try
            'driver.GetScreenshot().SaveAsFile(System.AppDomain.CurrentDomain.BaseDirectory & "teste.jpg")
            Log("Logon Feito.")

            'Aceita o alert de Bem Vindo
            'Verifica se logou corretamente
            System.Threading.Thread.Sleep(5000)
            Try
                alert = driver.SwitchTo().Alert()
                alert.Accept()
            Catch ex As Exception

            End Try

            'Navego para a página de arranchamento
            driver.Navigate().GoToUrl(uriRancho.AbsoluteUri & "/sisarr/acesso/usuario_arranchar_novo.php")
            Log("Realizando Arranchamento!")

            While True
                Try
                    lsElements = driver.FindElements(By.XPath("//a[contains(@href,'novo_arranchar.php?refeicao=almoco')]"))
                    For i = 0 To lsElements.Count - 1
                        element = lsElements(i)
                        dia = New Date(Strings.Mid(element.GetAttribute("href"), Strings.InStr(element.GetAttribute("href"), "dia=") + 10, 4),
                                   Strings.Mid(element.GetAttribute("href"), Strings.InStr(element.GetAttribute("href"), "dia=") + 7, 2),
                                   Strings.Mid(element.GetAttribute("href"), Strings.InStr(element.GetAttribute("href"), "dia=") + 4, 2))
                        Select Case oMilitar.Agenda
                            Case Militar.TipoAgendamento.SegundaQuinta
                                If ((dia.DayOfWeek = DayOfWeek.Monday) Or (dia.DayOfWeek = DayOfWeek.Tuesday) Or (dia.DayOfWeek = DayOfWeek.Wednesday) _
                                            Or (dia.DayOfWeek = DayOfWeek.Thursday)) Then
                                    Log("Arranchando almoco do dia " & Format(dia, "dd/MM/yyyy"))
                                    element.Click()
                                    System.Threading.Thread.Sleep(10000)
                                    lsElements = driver.FindElements(By.XPath("//a[contains(@href,'novo_arranchar.php?refeicao=almoco')]"))
                                    i = i - 1
                                End If
                            Case Militar.TipoAgendamento.SegundaSexta
                                If ((dia.DayOfWeek = DayOfWeek.Monday) Or (dia.DayOfWeek = DayOfWeek.Tuesday) Or (dia.DayOfWeek = DayOfWeek.Wednesday) _
                                            Or (dia.DayOfWeek = DayOfWeek.Thursday) Or (dia.DayOfWeek = DayOfWeek.Friday)) Then
                                    Log("Arranchando almoco do dia " & Format(dia, "dd/MM/yyyy"))
                                    element.Click()
                                    System.Threading.Thread.Sleep(10000)
                                    lsElements = driver.FindElements(By.XPath("//a[contains(@href,'novo_arranchar.php?refeicao=almoco')]"))
                                    i = i - 1
                                End If
                            Case Militar.TipoAgendamento.TodoDia
                                Log("Arranchando almoco do dia " & Format(dia, "dd/MM/yyyy"))
                                element.Click()
                                System.Threading.Thread.Sleep(10000)
                                lsElements = driver.FindElements(By.XPath("//a[contains(@href,'novo_arranchar.php?refeicao=almoco')]"))
                                i = i - 1
                        End Select
                        Application.DoEvents()
                        'dia = Strings.Mid(dia, Strings.InStr(dia, "dia=") + 4, 10)
                    Next
                    Exit While
                Catch ex As Exception
                    Exit While
                End Try
            End While

        Catch ex1 As SenhaInvalidaException
            oMilitar.Status = ex1.Message
            Throw ex1
        Catch ex As Exception
            'MessageBox.Show(Me, "Erro realizando arranchamento: " & ex.Message, "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
            oMilitar.Status = "Erro: " & ex.Message
        Finally
            Try
                driver.Close()
                driver.Dispose()
            Catch
            End Try
        End Try
    End Sub

    Private Sub Log(msg As String)
        lstStatus.Items.Add(Format(Now, "dd/MM/yyyy hh:mm:ss") & " -> " & msg)
        lstStatus.TopIndex = lstStatus.Items.Count - 1
        oLog.Info(msg)
    End Sub

    Private Shared Sub WaitForLoad(driver As IWebDriver, Optional timeoutSec As Integer = 15)

        Dim js As IJavaScriptExecutor = CType(driver, IJavaScriptExecutor)
        Dim wait As WebDriverWait = New WebDriverWait(driver, New TimeSpan(0, 0, timeoutSec))
        wait.Until(Function(wd) js.ExecuteScript("return document.readyState").ToString() = "complete")
    End Sub

    Private Sub GravarArquivoMilitares()
        Dim xml_serializer As New XmlSerializer(GetType(List(Of Militar)))
        Dim string_writer As New StringWriter

        Try

            xml_serializer.Serialize(string_writer, _lstMilitares)
            'txtSerialization.Text = string_writer.ToString()
            IO.File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory & "militares.xml", string_writer.ToString())
            string_writer.Close()

            'MessageBox.Show(Me, "Dados salvos com sucesso.", "ArranchadorCML", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Throw ex
        Finally
            string_writer.Dispose()
            string_writer = Nothing
        End Try
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        tmrRancho.Interval = New TimeSpan(1, 0, 0, 0).TotalMilliseconds
        tmrRancho.Start()
        Call tmrRancho_Tick(Nothing, Nothing)

    End Sub

    Private Sub tmrHorario_Tick(sender As Object, e As EventArgs) Handles tmrHorario.Tick
        lblHorário.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
    End Sub
End Class
