Imports System.Xml.Serialization
''' <summary>
''' This class models the items that make up the tree structure.
''' 
''' A Public class definition Is required for XML Serialization
''' via XmlSerializer to work
''' https://docs.microsoft.com/en-us/previous-versions/windows/apps/swxzdhc0(v=vs.105)?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(System.Xml.Serialization.XmlSerializer)%3Bk(TargetFrameworkMoniker-.NETFramework%2CVersion%3Dv4.6.1)%3Bk(DevLang-csharp)%26rd%3Dtrue
''' </summary>
Public Class Item

    Private _Parent As Item

    ''' <summary>
    ''' Class constructor
    ''' </summary>
    ''' <param name="par_parent"></param>
    ''' <param name="par_id"></param>
    Public Sub New(ByRef par_parent As Item,
                       ByVal par_id As String)
        Me.New()

        Parent = par_parent
        Text = par_id
        Children = New List(Of Item)()
    End Sub

    ''' <summary>
    ''' Parameterized class constructor
    ''' </summary>
    ''' <param name="par_parent"></param>
    ''' <param name="par_id"></param>
    ''' <param name="par_children"></param>
    Public Sub New(ByRef par_parent As Item,
                       ByVal par_id As String,
                       ByRef par_children As List(Of Item))
        Me.New()

        Parent = par_parent
        Text = par_id
        Children = par_children
    End Sub

    ''' <summary>
    ''' Class constructor
    ''' This public constructor Is required for XML Serialization
    ''' (reading Xml) to work.
    ''' </summary>
    Public Sub New()
        Text = Nothing
        Children = New List(Of Item)()
        Parent = Nothing
    End Sub

    ''' <summary>
    ''' Gets/sets the Text of a Item item.
    ''' 
    ''' Public properties (Or fields) with public setter And getter
    ''' are necessary for XML Serialization via XmlSerializer to work
    ''' </summary>
    Public Property Text As String

    ''' <summary>
    ''' Gets/sets the list of child Items below this Item item.
    ''' 
    ''' Public properties (Or fields) with public setter And getter
    ''' are necessary for XML Serialization via XmlSerializer to work
    ''' </summary>
    Public Property Children As List(Of Item)

    ''' <summary>
    ''' Gets/sets the parent Item of this Item object.
    ''' 
    ''' The [XmlIgnore] Is required here, because the XmlSerializer will
    ''' otherwise complain about a circular dependency that cannot be resolved
    ''' (this Is a limitation of the XML format).
    ''' 
    ''' Solution: Use an ParentId data item (e.g.: Text of parent) to resolve this
    ''' situation without a reference to another object.
    ''' </summary>
    <XmlIgnore>
    Public Property Parent As Item
        Get
            Return _Parent
        End Get

        Set(ByVal value As Item)
            If (_Parent Is Nothing And value Is Nothing) Then Return

            If (_Parent Is Nothing And value IsNot Nothing) Or
                    (_Parent IsNot Nothing And value Is Nothing) Then
                _Parent = value
            Else
                If _Parent.Equals(value) = False Then
                    _Parent = value
                    If _Parent IsNot Nothing Then ParentId = _Parent.Text Else ParentId = String.Empty
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets/sets the Parent Text (if there Is a parent) for this object.
    ''' 
    ''' This field should Not be set directly as it Is set through
    ''' the setter in the Parent property of this class.
    ''' 
    ''' Public Setter And Getter are required for the XmlSerializer
    ''' to function for writting And reading XML data.
    ''' </summary>
    Public Property ParentId As String

    ''' <summary>
    ''' Gets the path of this Item be collecting information
    ''' from parent Items back to the root.
    ''' </summary>
    ''' <param name="current"></param>
    ''' <returns></returns>
    Public Function GetPath(ByVal Optional current As Item = Nothing) As String
        If current Is Nothing Then current = Me

        Dim result As String = String.Empty

        ' Traverse the list of parents backwards And
        ' add each child to the path
        While current IsNot Nothing
            result = "/" & current.Text & result
            current = current.Parent
        End While

        Return result
    End Function

    ''' <summary>
    ''' Gets the contents of this object in a human readable way.
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        If Text Is Nothing Then Return "(null)"

        If Text = String.Empty Then Return "(empty)"

        If Parent Is Nothing Then Return Text

        Return String.Format("{0}  at: {1}", Text, GetPath())
    End Function
End Class