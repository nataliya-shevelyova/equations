Public Class Theory

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim st, path As String
        path = Application.StartupPath & "\Info\"
        st = TreeView1.SelectedNode.Name
        If st = "nd1" Then
            RichTextBox1.LoadFile(path & "1.rtf")
        ElseIf st = "nd2" Then
            RichTextBox1.LoadFile(path & "123.rtf")
        ElseIf st = "nd3" Then
            RichTextBox1.LoadFile(path & "2.rtf")
        ElseIf st = "nd11" Then
            RichTextBox1.LoadFile(path & "3.rtf")
        ElseIf st = "nd4" Then
            RichTextBox1.LoadFile(path & "6.rtf")
        ElseIf st = "nd13" Then
            RichTextBox1.LoadFile(path & "5.rtf")
        ElseIf st = "nd14" Then
            RichTextBox1.LoadFile(path & "7.rtf")
        ElseIf st = "nd15" Then
            RichTextBox1.LoadFile(path & "4.rtf")
        ElseIf st = "nd17" Then
            RichTextBox1.LoadFile(path & "2.1.rtf")
        ElseIf st = "nd18" Then
            RichTextBox1.LoadFile(path & "3.1.rtf")
        ElseIf st = "nd16" Then
            RichTextBox1.LoadFile(path & "4.1.rtf")
        ElseIf st = "nd16" Then
            RichTextBox1.LoadFile(path & "4.1.rtf")
        ElseIf st = "nd19" Then
            RichTextBox1.LoadFile(path & "6.1.rtf")
        ElseIf st = "nd20" Then
            RichTextBox1.LoadFile(path & "5.1.rtf")
        ElseIf st = "nd21" Then
            RichTextBox1.LoadFile(path & "7.1.rtf")
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Meny.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Meny.Show()
    End Sub

    Private Sub Theory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub Theory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class