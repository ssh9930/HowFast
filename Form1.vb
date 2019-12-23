Public Class Form1


    Public Sub onload_() Handles Me.Load

        Dim mainpnl As New MainPnl(Me)
        Me.Size = mainpnl.Size
        Me.Height += 30
        Me.MaximumSize = Me.Size
        Me.Controls.Add(mainpnl)
        mainpnl.Show()

    End Sub




End Class