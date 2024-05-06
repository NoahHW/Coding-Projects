Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class adminpage

    Public Property level As String
    Private Property connectionString = "server=localhost;user id=root;password=;database=vb_finalblockproject"
    Private Property connect As MySqlConnection

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        adminlogin.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Me.Hide()
        adminchangepassword.Show()
    End Sub

    Private Sub CreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateToolStripMenuItem.Click
        Me.Hide()
        createEmployee.Show()
    End Sub

    Private Sub ListOfEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfEmployeesToolStripMenuItem.Click
        Me.Hide()
        employeelist.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Me.Hide()
        deleteEmployee.Show()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Me.Hide()
        editEmployee.Show()
    End Sub

    Private Sub CreateToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CreateToolStripMenuItem1.Click
        Me.Hide()
        createVideo.Show()
    End Sub

    Private Sub ListOfVideosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfVideosToolStripMenuItem.Click
        Me.Hide()
        videoList.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        Me.Hide()
        deleteVideo.Show()
    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        Me.Hide()
        editVideo.Show()
    End Sub

    Private Sub CreateToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CreateToolStripMenuItem2.Click
        Me.Hide()
        createClient.Show()
    End Sub

    Private Sub ListOfClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfClientsToolStripMenuItem.Click
        Me.Hide()
        clientlist.Show()
    End Sub
    Private Sub DeleteToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem2.Click
        Me.Hide()
        deleteClient.Show()
    End Sub

    Private Sub EditToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem2.Click
        Me.Hide()
        editClient.Show()
    End Sub

    Private Sub QuickToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickToolStripMenuItem.Click
        Me.Hide()
        quickSearch.Show()
    End Sub

    Private Sub AdvancedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedToolStripMenuItem.Click
        Me.Hide()
        advancedSearch.Show()
    End Sub

    Private Sub RentAVideoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RentAVideoToolStripMenuItem.Click
        Me.Hide()
        rentVideo.Show()
    End Sub

    Private Sub ListOfRentedVideosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfRentedVideosToolStripMenuItem.Click
        Me.Hide()
        listRentedVideos.Show()
    End Sub

    Private Sub adminpage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case level
            Case "Low"
                ToolStripMenuItem5.Enabled = False
                ToolStripMenuItem3.Enabled = False
                EditToolStripMenuItem1.Enabled = False
                DeleteToolStripMenuItem1.Enabled = False
            Case "Medium"
                ToolStripMenuItem5.Enabled = False
                ToolStripMenuItem3.Enabled = False
                EditToolStripMenuItem1.Enabled = True
                DeleteToolStripMenuItem1.Enabled = False
            Case "High"
                ToolStripMenuItem5.Enabled = False
                ToolStripMenuItem3.Enabled = False
                EditToolStripMenuItem1.Enabled = True
                DeleteToolStripMenuItem1.Enabled = True
        End Select

    End Sub


End Class