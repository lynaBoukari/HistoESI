Partial Class BDD_PRJT_EQUIPE14DataSet
    Partial Class MOYENNEMATIEREDataTable

        Private Sub MOYENNEMATIEREDataTable_MOYENNEMATIERERowChanging(sender As System.Object, e As MOYENNEMATIERERowChangeEvent) Handles Me.MOYENNEMATIERERowChanging

        End Sub

    End Class

    Partial Class MATIEREDataTable

        Private Sub MATIEREDataTable_MATIERERowChanging(sender As System.Object, e As MATIERERowChangeEvent) Handles Me.MATIERERowChanging

        End Sub

    End Class

    Partial Class GROUPEDataTable

        Private Sub GROUPEDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NGroupeColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class SECTIONDataTable

        Private Sub SECTIONDataTable_SECTIONRowChanging(sender As System.Object, e As SECTIONRowChangeEvent) Handles Me.SECTIONRowChanging

        End Sub

    End Class

    Partial Class ETUDIANTDataTable

        Private Sub ETUDIANTDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NomEtudAColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class PARCOURSDataTable

        Private Sub PARCOURSDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ADMColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

        Private Sub PARCOURSDataTable_PARCOURSRowChanging(sender As System.Object, e As PARCOURSRowChangeEvent) Handles Me.PARCOURSRowChanging

        End Sub

    End Class

End Class

Namespace Projet.BDD_PRJT_EQUIPE14DataSetTableAdapters
    
    Partial Class MOYENNEMATIERETableAdapter

    End Class

    Partial Public Class SPECIALITETableAdapter
    End Class
End Namespace
