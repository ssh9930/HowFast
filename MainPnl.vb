Public Class MainPnl
    Public target_ As Form

    Sub New(target As Form)
        target_ = target

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

        AddHandler Button1.Click, AddressOf teststart

    End Sub

    Public Sub teststart()
        Dim testpnl As New TestPnl
        Me.Visible = False
        target_.Controls.Add(testpnl)
        testpnl.Size = Me.Size
        testpnl.Show()
        testpnl.Visible = True
        testpnl.Label2.Location = New Point(Me.Width / 2 - Label2.Width, Me.Height / 2 - Label2.Height)
        AddHandler testpnl.VisibleChanged, Sub()

                                               testpnl.Dispose()
                                               Me.Visible = True

                                               ResultListBox.Items.Clear()

                                               Dim max As Integer = Integer.MaxValue
                                               Dim cnt As Integer = 0

                                               For Each i In TestResultList
                                                   cnt += 1
                                                   If i < max Then
                                                       max = i
                                                   End If
                                                   ResultListBox.Items.Add("#" + cnt.ToString + " " + i.ToString + "ms")

                                               Next

                                               Label4.Text = "최고기록: " + max.ToString + "ms"
                                           End Sub

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("목록을 초기화 하시겠습니까?", vbYesNo, "") = vbYes Then
            ResultListBox.Items.Clear()
            TestResultList = {}
            TestResultListCnt = 0
            Label4.Text = ""
        End If

    End Sub
End Class
