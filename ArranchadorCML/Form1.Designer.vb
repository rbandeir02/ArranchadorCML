<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArranchador
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArranchador))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.dgMilitares = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstStatus = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExecutarAgora = New System.Windows.Forms.Button()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.btnFechat = New System.Windows.Forms.Button()
        Me.lblMonitoramento = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblHorário = New System.Windows.Forms.Label()
        Me.txtProximaExecucao = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUltimaExecucao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tmrRancho = New System.Windows.Forms.Timer(Me.components)
        Me.tmrHorario = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgMilitares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSalvar)
        Me.GroupBox1.Controls.Add(Me.dgMilitares)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(973, 253)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Militares a serem arranchados"
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = CType(resources.GetObject("btnSalvar.Image"), System.Drawing.Image)
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(841, 209)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(126, 38)
        Me.btnSalvar.TabIndex = 1
        Me.btnSalvar.Text = "Salvar Militares"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'dgMilitares
        '
        Me.dgMilitares.AllowUserToResizeRows = False
        Me.dgMilitares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMilitares.Location = New System.Drawing.Point(6, 19)
        Me.dgMilitares.MultiSelect = False
        Me.dgMilitares.Name = "dgMilitares"
        Me.dgMilitares.Size = New System.Drawing.Size(961, 181)
        Me.dgMilitares.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstStatus)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnExecutarAgora)
        Me.GroupBox2.Controls.Add(Me.btnIniciar)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 271)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(743, 207)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Marcações"
        '
        'lstStatus
        '
        Me.lstStatus.BackColor = System.Drawing.Color.Black
        Me.lstStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstStatus.ForeColor = System.Drawing.Color.Green
        Me.lstStatus.FormattingEnabled = True
        Me.lstStatus.Location = New System.Drawing.Point(60, 14)
        Me.lstStatus.Name = "lstStatus"
        Me.lstStatus.ScrollAlwaysVisible = True
        Me.lstStatus.Size = New System.Drawing.Size(677, 147)
        Me.lstStatus.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Status:"
        '
        'btnExecutarAgora
        '
        Me.btnExecutarAgora.Image = CType(resources.GetObject("btnExecutarAgora.Image"), System.Drawing.Image)
        Me.btnExecutarAgora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExecutarAgora.Location = New System.Drawing.Point(236, 163)
        Me.btnExecutarAgora.Name = "btnExecutarAgora"
        Me.btnExecutarAgora.Size = New System.Drawing.Size(139, 38)
        Me.btnExecutarAgora.TabIndex = 1
        Me.btnExecutarAgora.Text = "Executar Agora    "
        Me.btnExecutarAgora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExecutarAgora.UseVisualStyleBackColor = True
        '
        'btnIniciar
        '
        Me.btnIniciar.Image = CType(resources.GetObject("btnIniciar.Image"), System.Drawing.Image)
        Me.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIniciar.Location = New System.Drawing.Point(526, 162)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(131, 38)
        Me.btnIniciar.TabIndex = 0
        Me.btnIniciar.Text = "Iniciar            "
        Me.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'btnFechat
        '
        Me.btnFechat.Image = CType(resources.GetObject("btnFechat.Image"), System.Drawing.Image)
        Me.btnFechat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFechat.Location = New System.Drawing.Point(871, 439)
        Me.btnFechat.Name = "btnFechat"
        Me.btnFechat.Size = New System.Drawing.Size(114, 39)
        Me.btnFechat.TabIndex = 2
        Me.btnFechat.Text = "Fechar      "
        Me.btnFechat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechat.UseVisualStyleBackColor = True
        '
        'lblMonitoramento
        '
        Me.lblMonitoramento.AutoSize = True
        Me.lblMonitoramento.Location = New System.Drawing.Point(484, 298)
        Me.lblMonitoramento.Name = "lblMonitoramento"
        Me.lblMonitoramento.Size = New System.Drawing.Size(0, 13)
        Me.lblMonitoramento.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblStatus)
        Me.GroupBox3.Controls.Add(Me.lblHorário)
        Me.GroupBox3.Controls.Add(Me.txtProximaExecucao)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtUltimaExecucao)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(761, 271)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(224, 160)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Timers"
        '
        'lblHorário
        '
        Me.lblHorário.AutoSize = True
        Me.lblHorário.Location = New System.Drawing.Point(9, 26)
        Me.lblHorário.Name = "lblHorário"
        Me.lblHorário.Size = New System.Drawing.Size(0, 13)
        Me.lblHorário.TabIndex = 4
        '
        'txtProximaExecucao
        '
        Me.txtProximaExecucao.Location = New System.Drawing.Point(20, 131)
        Me.txtProximaExecucao.Name = "txtProximaExecucao"
        Me.txtProximaExecucao.Size = New System.Drawing.Size(100, 20)
        Me.txtProximaExecucao.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Próxima Execução"
        '
        'txtUltimaExecucao
        '
        Me.txtUltimaExecucao.Location = New System.Drawing.Point(18, 92)
        Me.txtUltimaExecucao.Name = "txtUltimaExecucao"
        Me.txtUltimaExecucao.Size = New System.Drawing.Size(100, 20)
        Me.txtUltimaExecucao.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Última Execução"
        '
        'tmrRancho
        '
        '
        'tmrHorario
        '
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(6, 52)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 5
        '
        'frmArranchador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 483)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblMonitoramento)
        Me.Controls.Add(Me.btnFechat)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmArranchador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Arranchador CML"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgMilitares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgMilitares As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnIniciar As Button
    Friend WithEvents btnFechat As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnExecutarAgora As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMonitoramento As Label
    Friend WithEvents lstStatus As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblHorário As Label
    Friend WithEvents txtProximaExecucao As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUltimaExecucao As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tmrRancho As Timer
    Friend WithEvents tmrHorario As Timer
    Friend WithEvents lblStatus As Label
End Class
