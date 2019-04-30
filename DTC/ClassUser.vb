Public Class ClassUser
    Private userNameValue As String
    Private userPrivilegeValue As Integer
    Private userFunctionValue As String
    Private userAreaValue As Integer
    Private userImageValue As String

    Public Property UserName() As String
        Get
            ' Gets the property value.
            Return userNameValue
        End Get
        Set(ByVal Value As String)
            ' Sets the property value.
            userNameValue = Value
        End Set
    End Property

    Public Property UserPrivilege() As Integer
        Get
            ' Gets the property value.
            Return userPrivilegeValue
        End Get
        Set(ByVal Value As Integer)
            ' Sets the property value.
            userPrivilegeValue = Value
        End Set
    End Property

    Public Property UserFunction() As String
        Get
            ' Gets the property value.
            Return userFunctionValue
        End Get
        Set(ByVal Value As String)
            ' Sets the property value.
            userFunctionValue = Value
        End Set
    End Property

    Public Property UserArea() As Integer
        Get
            ' Gets the property value.
            Return userAreaValue
        End Get
        Set(ByVal Value As Integer)
            ' Sets the property value.
            userAreaValue = Value
        End Set
    End Property

    Public Property UserImage() As String
        Get
            ' Gets the property value.
            Return userImageValue
        End Get
        Set(ByVal Value As String)
            ' Sets the property value.
            userImageValue = Value
        End Set
    End Property
End Class
