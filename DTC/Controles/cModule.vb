Module cModule
#Region "CustomGrid"
    Dim dateCellStyle As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleRight}
    Dim amountCellStyle As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleRight, .Format = "N2"}
    Dim gridCellStyle As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle With {
       .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
       .BackColor = System.Drawing.Color.FromArgb(82, 119, 148),'aqui cor do cabeçalho
       .Font = New System.Drawing.Font("Bebas Neue", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)),
       .ForeColor = System.Drawing.SystemColors.ControlLightLight,
       .SelectionBackColor = System.Drawing.Color.FromArgb(199, 32, 38),'aqui não seii
       .SelectionForeColor = System.Drawing.SystemColors.HighlightText,
       .WrapMode = System.Windows.Forms.DataGridViewTriState.[True]}
    Dim gridCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle With {
        .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
        .BackColor = System.Drawing.SystemColors.ControlLightLight,
        .Font = New System.Drawing.Font("Bebas Neue", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)),
        .ForeColor = System.Drawing.SystemColors.ControlText,
        .SelectionBackColor = System.Drawing.Color.FromArgb(232, 109, 0),'aqui cor do selecionado
        .SelectionForeColor = System.Drawing.SystemColors.HighlightText,
        .WrapMode = System.Windows.Forms.DataGridViewTriState.[False]}
    Dim gridCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle With {
        .Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
        .BackColor = System.Drawing.Color.Lavender,
        .Font = New System.Drawing.Font("Bebas Neue", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)),
        .ForeColor = System.Drawing.SystemColors.WindowText,
        .SelectionBackColor = System.Drawing.Color.FromArgb(232, 109, 0),'aqui cor do selecionado
        .SelectionForeColor = System.Drawing.SystemColors.HighlightText,
        .WrapMode = System.Windows.Forms.DataGridViewTriState.[True]}
    Sub applyGridTheme(ByRef grid As DataGridView, ByVal UserPrivilege As Boolean)
        grid.AllowUserToAddRows = UserPrivilege
        grid.AllowUserToDeleteRows = UserPrivilege
        grid.BackgroundColor = System.Drawing.SystemColors.Window
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        grid.ColumnHeadersDefaultCellStyle = gridCellStyle
        grid.ColumnHeadersHeight = 32
        grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grid.DefaultCellStyle = gridCellStyle2
        grid.EnableHeadersVisualStyles = False
        grid.GridColor = System.Drawing.SystemColors.GradientInactiveCaption
        grid.ReadOnly = Not UserPrivilege
        grid.RowHeadersVisible = Not UserPrivilege
        grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        grid.RowHeadersDefaultCellStyle = gridCellStyle3
        grid.Font = gridCellStyle.Font
    End Sub
    Sub setGridRowHeader(ByRef dgv As DataGridView, Optional ByVal hSize As Boolean = False)
        dgv.TopLeftHeaderCell.Value = "NO "
        dgv.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders)
        For Each cCol As DataGridViewColumn In dgv.Columns
            If cCol.ValueType.ToString() = GetType(DateTime).ToString Then
                cCol.DefaultCellStyle = dateCellStyle
            ElseIf cCol.ValueType.ToString() = GetType(Decimal).ToString Or cCol.ValueType.ToString() = GetType(Double).ToString Then
                cCol.DefaultCellStyle = amountCellStyle
            End If
        Next
        If hSize Then
            dgv.RowHeadersWidth = dgv.RowHeadersWidth + 16
        End If
        dgv.AutoResizeColumns()
    End Sub
    Sub rowPostPaint_HeaderCount(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        'set rowheader count
        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Center
        centerFormat.LineAlignment = StringAlignment.Center
        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top,
            grid.RowHeadersWidth, e.RowBounds.Height - sender.rows(e.RowIndex).DividerHeight)
        e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText,
            headerBounds, centerFormat)
    End Sub


#End Region
End Module
