Imports System.Drawing.Drawing2D

Public Class frmServers

    Private DarkMode As DarkModeForms.DarkModeCS

    Private Sub frmServers_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each Server In Utils.OllamaServers
            Dim MyNode As New ListViewItem
            MyNode.Text = Server.Name
            MyNode.SubItems.Add(Server.FullString)
            MyNode.Tag = Server
            If Server.isCurrent Then
                MyNode.ImageIndex = 0
            Else
                MyNode.ImageIndex = -1
            End If
            lstServers.Items.Add(MyNode)
        Next
    End Sub
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DarkMode = New DarkModeCS(Me, True, True) With {.ColorMode = DarkModeCS.DisplayMode.DarkMode}

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        OllamaServers.Save(Utils.OllamaServers)
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim server = Utils.OllamaServers.AddServer()
        Dim MyNode As New ListViewItem
        MyNode.Text = server.Name
        MyNode.SubItems.Add(server.FullString)

        MyNode.Tag = server
        lstServers.Items.Add(MyNode)
        lstServers.SelectedItems.Clear()
        MyNode.Selected = True
    End Sub
    Private amUpdating As Boolean
    Private Sub lstServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstServers.SelectedIndexChanged
        If lstServers.SelectedItems.Count = 1 Then
            amUpdating = True
            Dim Server As OllamaServer = lstServers.SelectedItems(0).Tag
            Me.txtName.Text = Server.Name
            Me.txtPort.Value = Server.Port
            Me.txtProtocol.Text = Server.Protocol
            Me.txtServer.Text = Server.Server
            PopulateModelList(Server)
            btnDelete.Enabled = True
            btnSetDefault.Enabled = Not Server.isCurrent
            grpServer.Enabled = True
            amUpdating = False
        Else
            btnDelete.Enabled = False
            btnSetDefault.Enabled = False
            grpServer.Enabled = False
        End If
    End Sub

    Private Sub PopulateModelList(Server As OllamaServer)
        cmbModel.Items.Clear()
        If Server.Models.Count = 0 Then
            cmbModel.Enabled = False
        Else
            cmbModel.Enabled = True
            For Each model In Server.Models
                cmbModel.Items.Add(model)
            Next
            If Server.DefaultModel IsNot Nothing Then
                cmbModel.SelectedItem = Server.DefaultModel
            End If
        End If
    End Sub
    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged, txtProtocol.TextChanged, txtServer.TextChanged, txtPort.ValueChanged
        If lstServers.SelectedItems.Count = 1 And Not amUpdating Then
            Dim Server As OllamaServer = lstServers.SelectedItems(0).Tag
            Server.Name = txtName.Text
            Server.Port = txtPort.Value
            Server.Protocol = txtProtocol.Text
            Server.Server = txtServer.Text
            lstServers.SelectedItems(0).Text = Server.Name
            lstServers.SelectedItems(0).SubItems(1).Text = Server.FullString
        End If
    End Sub



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstServers.SelectedItems.Count = 1 Then
            Dim Server As OllamaServer = lstServers.SelectedItems(0).Tag
            If MsgBox("Delete Server " & Server.Name & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Ollama") = MsgBoxResult.Yes Then
                Utils.OllamaServers.Remove(Server)
                lstServers.Items.Remove(lstServers.SelectedItems(0))
            End If
        End If

    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        If lstServers.SelectedItems.Count = 1 Then
            Dim Server = lstServers.SelectedItems(0).Tag
            Dim MyServer As New Ollama(Server)
            If MyServer.VerifyConnection() Then
                If cmbModel.Enabled = False Then
                    Server.models = MyServer.GetModels()
                    PopulateModelList(Server)
                End If
                MsgBox("Connection Successful", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Ollama")
            Else
                MsgBox("Connection Failed", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Ollama")
            End If

        End If
    End Sub

    Private Sub btnSetDefault_Click(sender As Object, e As EventArgs) Handles btnSetDefault.Click
        If lstServers.SelectedItems.Count = 1 Then
            Dim Server As OllamaServer = lstServers.SelectedItems(0).Tag
            Utils.OllamaServers.CurrentServer = Server
            For Each item As ListViewItem In Me.lstServers.Items
                If item.Tag.Equals(Server) Then
                    item.ImageIndex = 0
                Else
                    item.ImageIndex = -1
                End If
            Next
        End If
    End Sub

    Private Sub cmbModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbModel.SelectedIndexChanged
        If cmbModel.SelectedItem IsNot Nothing Then
            If lstServers.SelectedItems.Count = 1 Then
                Dim Server As OllamaServer = lstServers.SelectedItems(0).Tag
                Dim MyModel As LLMmodel = cmbModel.SelectedItem
                Server.DefaultModel = MyModel
                Me.lblModelDetails.Text = $"Name: {MyModel.Name} {vbCrLf}Size: {MyModel.SizeString} {vbCrLf}Parameters: {MyModel.ParameterSize} {vbCrLf}Quantization: {MyModel.Quantization}"
            End If
        End If
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        If lstServers.SelectedItems.Count = 1 Then
            Dim Server As OllamaServer = lstServers.SelectedItems(0).Tag
            Dim MyServer As New Ollama(Server)
            Server.Models = MyServer.GetModels()
            PopulateModelList(Server)
        End If
    End Sub


End Class