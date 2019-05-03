Imports DTC.ClassUser
Imports DTC.LoginForm

Public Class MainForm
    Public connectedOnServer As Boolean
    Private isMouseDown As Boolean
    Private mouseOffset As Point
    Dim masterDetail As MasterControl
    Sub ClearFields()
        Panel15.Controls.Clear()
        masterDetail = Nothing
        Refresh()
    End Sub
    Sub LoadData()
        ClearFields()
        Me.OrderReportsTableAdapter1.Fill(Me.NwindDataSet.OrderReports)
        Me.InvoicesTableAdapter1.Fill(Me.NwindDataSet.Invoices)
        Me.CustomersTableAdapter1.Fill(Me.NwindDataSet.Customers)
        CreateMasterDetailView()
    End Sub
    Sub CreateMasterDetailView()
        masterDetail = New MasterControl(NwindDataSet)
        Panel15.Controls.Add(masterDetail)
        masterDetail.setParentSource(NwindDataSet.Customers.TableName, "CustomerID")
        masterDetail.childView.Add(NwindDataSet.OrderReports.TableName, "Orders")
        masterDetail.childView.Add(NwindDataSet.Invoices.TableName, "Invoices")
    End Sub

    Private Function LoadUsers() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Usuario")
        dt.Columns.Add("Senha")
        dt.Columns.Add("Nome")
        dt.Columns.Add("Função")
        dt.Columns.Add("Área")
        dt.Columns.Add("Nível de Acesso")
        dt.Columns.Add("Foto de Perfil")

        For i = 0 To 4
            dt.Rows.Add()
            For j = 0 To 6
                dt.Rows(i).Item(j) = LoginForm.users(i, j)
            Next
        Next
        Return dt
    End Function
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'itens a serem excluidos
        '
        connectedOnServer = True

        '
        '
        applyGridTheme(DataGridView1, False)
        applyGridTheme(DataGridView2, False)
        applyGridTheme(DataGridView3, False)
        applyGridTheme(DataGridView4, False)
        applyGridTheme(DataGridView5, False)
        applyGridTheme(DataGridView6, True)

        LoadData()
        If LoginForm.user.UserPrivilege = 3 Then
            Button2.Hide()
            Button5.Hide()
        End If

        Panel15.Width = Panel14.Width
        TabControl1.Appearance = TabAppearance.FlatButtons
        TabControl1.ItemSize = New Size(0, 1)
        TabControl1.SizeMode = TabSizeMode.Fixed
        For Each tab As TabPage In TabControl1.TabPages
            tab.Text = ""
        Next

        If connectedOnServer Then
            PictureBox3.Image = My.Resources.icons8_online
        Else
            PictureBox3.Image = My.Resources.icons8_offline
        End If

        Label1.Text = LoginForm.user.UserName
        Label2.Text = LoginForm.user.UserFunction
        PictureBox2.ImageLocation = LoginForm.user.UserImage
        DataGridView1.DataSource = LoadUsers()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button1.Top
        Panel6.Height = Button1.Height
        'chama as funções da janela inicial
        TabControl1.SelectedTab = TabPage1

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel8.Hide()
        Button3.Show()
        Panel6.Top = Button2.Top
        Panel6.Height = Button2.Height
        Button11.Show()
        'TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button4.Top
        Panel6.Height = Button4.Height
        TabControl1.SelectedTab = TabPage4
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button5.Top
        Panel6.Height = Button5.Height
        TabControl1.SelectedTab = TabPage5

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button6.Top
        Panel6.Height = Button6.Height
        TabControl1.SelectedTab = TabPage6
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Panel4.Width = 240 Then
            Panel4.Width = 40
            Panel5.Hide()
            Panel7.Hide()
            PictureBox1.Image = My.Resources.dinamica_eletrica_icon
        Else
            Panel4.Width = 240
            Panel5.Show()
            Panel7.Show()
            PictureBox1.Image = My.Resources.dinamica_eletrica_wht_v2_uai_258x58
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        LoginForm.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Panel7.Top
        Panel6.Height = Button9.Height
        TabControl1.SelectedTab = TabPage7
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, Panel12.MouseDown
        If e.Button = MouseButtons.Left Then
            mouseOffset = New Point(Cursor.Position.X - Me.Location.X, Cursor.Position.Y - Me.Location.Y)
            isMouseDown = True
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove, Panel12.MouseMove
        If isMouseDown Then
            Me.Location = New Point(Cursor.Position.X - mouseOffset.X, Cursor.Position.Y - mouseOffset.Y)
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp, Panel12.MouseUp
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panel8.Hide()
        Button3.Hide()
        Button11.Hide()
        Panel6.Top = Button12.Top
        Panel6.Height = Button12.Height
        TabControl1.SelectedTab = TabPage3
    End Sub


    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Panel8.Show()
        Panel8.Top = Button11.Top
        Panel8.Height = Button11.Height
        TabControl1.SelectedTab = TabPage2
        ' loadUsers()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel8.Show()
        Panel8.Top = Button3.Top
        Panel8.Height = Button3.Height
        TabControl1.SelectedTab = TabPage8
    End Sub

    Private Function ImageLoad() As String
        Dim pic As New OpenFileDialog With {
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            .Filter = "Arquivo de Imagem(*.PNG, *JPG, *BMP)|*.PNG;*.JPG;*.BMP"
        }

        ' salvar a imagem reduzida para 71x71 com o circulo em torno em pastado de fotos gerais do sistema
        ' Usar o imageMagick
        If pic.ShowDialog = DialogResult.OK Then
            Return pic.FileName
        Else
            Return ""
        End If
    End Function
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim imageLocation As String
        imageLocation = ImageLoad()

        If imageLocation.Length > 0 Then
            PictureBox4.ImageLocation = imageLocation
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        TextBox5.Text = "123456"
    End Sub

    Private Sub PictureBox4_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox4.DoubleClick
        Dim imageLocation As String
        imageLocation = ImageLoad()

        If imageLocation.Length > 0 Then
            PictureBox4.ImageLocation = imageLocation
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        CheckBox1.Checked = False
        PictureBox4.ImageLocation = ""
    End Sub

    Private index As Integer
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        index = e.RowIndex
        If e.Button = MouseButtons.Right Then
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            ComboBox1.SelectedIndex = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            ComboBox2.SelectedIndex = DataGridView1.Rows(e.RowIndex).Cells(5).Value
            PictureBox4.ImageLocation = DataGridView1.Rows(e.RowIndex).Cells(6).Value
            DataGridView1.ClearSelection()
            DataGridView1.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        TextBox1.Text = DataGridView1.Rows(index).Cells(2).Value
        TextBox2.Text = DataGridView1.Rows(index).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(index).Cells(0).Value
        TextBox5.Text = DataGridView1.Rows(index).Cells(1).Value
        ComboBox1.SelectedIndex = DataGridView1.Rows(index).Cells(4).Value
        ComboBox2.SelectedIndex = DataGridView1.Rows(index).Cells(5).Value
        PictureBox4.ImageLocation = DataGridView1.Rows(index).Cells(6).Value
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        CheckBox1.Checked = False
        PictureBox4.ImageLocation = ""
        index = -2
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If index = -2 Then
            DataGridView1.Rows.Add(TextBox4.Text, TextBox5.Text, TextBox1.Text, TextBox2.Text, ComboBox1.SelectedIndex, ComboBox2.SelectedIndex, PictureBox4.ImageLocation)
        Else

            DataGridView1.Rows(index).Cells(0).Value = TextBox4.Text
            DataGridView1.Rows(index).Cells(1).Value = TextBox5.Text
            DataGridView1.Rows(index).Cells(2).Value = TextBox1.Text
            DataGridView1.Rows(index).Cells(3).Value = TextBox2.Text
            DataGridView1.Rows(index).Cells(4).Value = ComboBox1.SelectedIndex
            DataGridView1.Rows(index).Cells(5).Value = ComboBox2.SelectedIndex
            DataGridView1.Rows(index).Cells(6).Value = PictureBox4.ImageLocation
        End If
    End Sub
    Private senhaatualOk As Boolean
    Private userPassUpdade As Integer
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        For i = 0 To 4
            If LoginForm.user.UserName = LoginForm.users(i, 0) Then
                If TextBox7.Text = LoginForm.users(i, 2) Then
                    senhaatualOk = True
                    userPassUpdade = i
                Else
                    senhaatualOk = False
                End If
            End If
        Next

        If senhaatualOk AndAlso TextBox8.Text = TextBox9.Text Then
            LoginForm.users(userPassUpdade, 2) = TextBox8.Text
        ElseIf Not senhaatualOk Then
            MsgBox("Senha digitada não corresponde com a atual")
        Else
            MsgBox("As duas digitações não correspondem")
        End If
    End Sub

    Sub CellMouseClick_DetailGrid(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim grid As DataGridView = CType(sender, DataGridView)
        If e.RowIndex > -1 Then
            Panel15.Width = 317
            Panel17.Show()
        End If

    End Sub

    Sub CellMouseClick_MasterGrid(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim grid As DataGridView = CType(sender, DataGridView)
        If grid.Tag = "True" Then
            Panel15.Width = 670
            Panel17.Hide()
        Else
            Panel15.Width = Panel14.Width
            Panel17.Hide()
        End If

    End Sub

    Private Sub Panel15_Resize(sender As Object, e As EventArgs) Handles Panel15.Resize
        If Panel15.Width = 317 Then
            Button29.Show()
        Else
            Button29.Hide()

        End If
    End Sub

    Private areasEnvolvidas() As CheckBox

    Private Sub TabPage8_Enter(sender As Object, e As EventArgs) Handles TabPage8.Enter

        Dim idx As Integer
        idx = 0
        Threading.Thread.Sleep(100)
        For Each chbox As CheckBox In Panel19.Controls
            ReDim Preserve areasEnvolvidas(idx)
            areasEnvolvidas(idx) = chbox
            idx += 1
        Next

    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        If TextBox11.Text.Length > 0 Then
            GroupBox6.Show()
        End If
    End Sub

End Class
