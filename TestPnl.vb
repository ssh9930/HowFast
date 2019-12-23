Imports System.Threading
Public Class TestPnl

    Public CountTimer As New Stopwatch() '반응속도 측정기 입니다.
    Public Delegate Sub g()
    Public t As Thread


    Public Sub ff() Handles Me.Load

        onload_()
    End Sub

    Public Sub onload_()
        Label2.Text = "기다리시고.."
        recallt()
        t.Start()

    End Sub
    Public nah As Boolean = False
    Public nah_ As Boolean = False

    Public Sub onclik_() Handles Me.Click
        'MsgBox(nah)
        'MsgBox(nah_)
        If nah Then
            nah = False
            nah_ = True
            onload_()
        End If

        If nah_ Then
            nah_ = False
            Exit Sub
        End If

        If CountTimer.IsRunning Then

            CountTimer.Stop()
            'TestResultListCnt += 1
            ReDim Preserve TestResultList(TestResultListCnt)
            TestResultList(TestResultListCnt) = CountTimer.ElapsedMilliseconds
            TestResultListCnt += 1
            Me.Visible = False

        Else
            t.Abort()

            Me.BackColor = Color.DarkBlue
            Label2.Text = "너무 빨리 눌렀어요!! 클릭해서 재도전하십시오"
            nah = True
            CountTimer.Stop()
        End If


    End Sub

    Public Sub recallt()
        t = Nothing
        t = New Thread(Sub()

                           Try
                               Me.Invoke(New g(Sub() Me.BackColor = Color.DarkRed))
                               Threading.Thread.Sleep(New Random().Next(3000, 7000)) '3초에서 7초 사이의 딜레이를 만듭니다.

                               Me.Invoke(New g(Sub()
                                                   Label2.Text = "누르세요"
                                                   Me.BackColor = Color.DarkGreen
                                                   CountTimer.Start()
                                               End Sub))

                           Catch ex As Exception
                           End Try
                       End Sub)
    End Sub




End Class
