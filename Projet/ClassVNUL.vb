Public Class VNUL

#Region "METHODES"
    Public Function TestValeurNullSTR(ByVal var As String) As String
        TestValeurNullSTR = var
    End Function

    Public Function TestValeurNullSTR(ByVal var As DBNull) As String
        TestValeurNullSTR = " "
    End Function

    Public Function TestValeurNullNBR(ByVal var As DBNull) As Integer
        TestValeurNullNBR = 0
    End Function

    Public Function TestValeurNullNBR(ByVal var As Double) As Double
        TestValeurNullNBR = var
    End Function


    Public Function TestValeurNullSYNTHESE(ByVal var As DBNull) As Double
        Return 0
    End Function

    Public Function TestValeurNullSYNTHESE(ByVal var As Double) As Double
        Return var
    End Function

    Public Function TestValeurNullRATRNO(ByVal var As DBNull) As Integer
        Return 3
    End Function

    Public Function TestValeurNullRATRNO(ByVal var As Integer) As Integer
        Return var
    End Function

    Public Function TestValeurNullBOOL(ByVal var As Boolean) As Boolean
        TestValeurNullBOOL = var
    End Function

    Public Function TestValeurNullBOOL(ByVal var As DBNull) As Boolean
        Return False
    End Function
#End Region





End Class

