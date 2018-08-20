Public Class Form
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'データ追加
        For i As Integer = 1 To 10
            dgView.Rows.Add(i.ToString(), "テストデータ" + i.ToString())
        Next
    End Sub

    ''' <summary>
    ''' データグリッドビューでのマウスクリック時処理
    ''' </summary>
    ''' <param name="sender">イベント送信元</param>
    ''' <param name="e">イベント引数</param>
    Private Sub dgView_MouseDown(sender As Object, e As MouseEventArgs) Handles dgView.MouseDown

        ' 左クリックの場合
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim dgv As DataGridView = CType(sender, DataGridView)

            Select Case dgv.HitTest(e.X, e.Y).Type
                ' 全選択処理の場合
                Case Is = DataGridViewHitTestType.TopLeftHeader
                    dgv.ClearSelection()
                    dgv.SelectAll()

                ' 列選択の場合
                Case Is = DataGridViewHitTestType.ColumnHeader

                    ' 列選択モードに切り替え
                    dgv.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect

                    ' 選択対象外のセルは選択状態を解除する
                    If Not dgv.SelectedColumns.Contains(dgv.Columns(dgv.CurrentCell.ColumnIndex)) Then
                        dgv.CurrentCell.Selected = False
                    End If

                ' 行選択の場合
                Case Is = DataGridViewHitTestType.RowHeader
                    ' 行選択モードに切り替える
                    dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect

                    ' 選択対象外のセルは選択状態を解除する
                    If Not dgv.SelectedRows.Contains(dgv.Rows(dgv.CurrentCell.RowIndex)) Then
                        dgv.CurrentCell.Selected = False
                    End If
            End Select
        End If
    End Sub
End Class
