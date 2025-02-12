Public Class Knowledge

    Private Sub Knowledge_Load(sender As Object, e As EventArgs) Handles Me.Load
        Loadknowledge()
    End Sub

    Private Sub Loadknowledge()
        lstKnowledge.Items.Clear()
        For Each Entry As KnowledgeEntry In Utils.Knowledge
            Dim Row As New ListViewItem
            Row.Text = Entry.Key
            Row.SubItems.Add(Entry.Text)
            Row.SubItems.Add(Entry.Tokens)
            Row.SubItems.Add(Entry.Size)
            Row.Tag = Entry
            lstKnowledge.Items.Add(Row)
        Next
    End Sub

    Private Sub btnAddKnowledge_Click(sender As Object, e As EventArgs) Handles btnAddKnowledge.Click, mnuAdd.Click
        Dim MyForm As New frmKnowledge
        If MyForm.ShowDialog(Me.ParentForm) = DialogResult.OK Then
            Utils.Knowledge.Add(MyForm.NewKnowledge)
            AddListItem(MyForm.NewKnowledge)
        End If
    End Sub

    Private Sub AddListItem(Kn As KnowledgeEntry)
        Dim MyItem As New ListViewItem
        lstKnowledge.Items.Add(MyItem)
        UpdateListItem(Kn, MyItem)
        MyItem.EnsureVisible()
    End Sub

    Private Sub UpdateListItem(Kn As KnowledgeEntry, Item As ListViewItem)
        Item.SubItems.Clear()
        Item.Text = Kn.Key
        Item.SubItems.Add(Kn.Name)
        Item.SubItems.Add(Kn.Tokens)
        Item.SubItems.Add(Kn.Size)
        Item.Tag = Kn
        Item.EnsureVisible()
    End Sub

    Private Sub lstKnowledge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstKnowledge.SelectedIndexChanged
        If lstKnowledge.SelectedItems.Count = 0 Then
            btnEditKnowledge.Enabled = False
            btnDeleteKnowledge.Enabled = False
        Else
            btnEditKnowledge.Enabled = True
            btnDeleteKnowledge.Enabled = True
        End If
    End Sub

    Private Sub btnEditKnowledge_Click(sender As Object, e As EventArgs) Handles btnEditKnowledge.Click, mnuEdit.Click
        If lstKnowledge.SelectedItems.Count = 1 Then
            Dim MyForm As New frmKnowledge
            MyForm.NewKnowledge = lstKnowledge.SelectedItems(0).Tag
            If MyForm.ShowDialog(Me.ParentForm) = DialogResult.OK Then
                UpdateListItem(MyForm.NewKnowledge, lstKnowledge.SelectedItems(0))
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click, mnuSaveAll.Click
        Utils.Knowledge.Save()
        MsgBox("Knowledge Saved ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Knowledge")
    End Sub

    Private Sub btnDeleteKnowledge_Click(sender As Object, e As EventArgs) Handles btnDeleteKnowledge.Click, mnuDelete.Click
        If lstKnowledge.SelectedItems.Count = 1 Then
            Dim KN = lstKnowledge.SelectedItems(0).Tag
            If MsgBox($"Delete {KN.key}?", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "Delete Knowledge") Then
                Utils.Knowledge.Remove(KN)
                lstKnowledge.Items.Remove(lstKnowledge.SelectedItems(0))
            End If
        End If
    End Sub

    Private Sub MenuList_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuList.Opening
        If lstKnowledge.SelectedItems.Count = 0 Then
            mnuEdit.Enabled = False
            mnuDelete.Enabled = False
            mnuSaveAll.Enabled = True
            mnuAdd.Enabled = True
        Else
            mnuEdit.Enabled = True
            mnuDelete.Enabled = True
            mnuSaveAll.Enabled = True
            mnuAdd.Enabled = True
        End If
    End Sub
End Class
