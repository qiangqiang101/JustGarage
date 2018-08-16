''' <summary>
''' This class models the root of the tree structure. It conains the Item
''' collection that makes up the root elemnts And all other information items
''' that apply to the complete tree structure (e.g.: Version Info etc.)
''' 
''' A Public class definition Is required for XML Serialization
''' via XmlSerializer to work
''' https://docs.microsoft.com/en-us/previous-versions/windows/apps/swxzdhc0(v=vs.105)?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(System.Xml.Serialization.XmlSerializer)%3Bk(TargetFrameworkMoniker-.NETFramework%2CVersion%3Dv4.6.1)%3Bk(DevLang-csharp)%26rd%3Dtrue
''' </summary>
Public Class ModelRoot

    ''' <summary>
    ''' Parameterized class constructor
    ''' </summary>
    ''' <param name="par_name"></param>
    Public Sub New(ByVal par_name As String)
        Me.New()

        Name = par_name
    End Sub

    ''' <summary>
    ''' Class constructor
    ''' This public constructor Is required for XML Serialization
    ''' (reading Xml) to work.
    ''' </summary>
    Public Sub New()
        RootItems = New List(Of Item)()
        Version = 1
        MinorVersion = 0
        Name = String.Empty
    End Sub

    ''' <summary>
    ''' Gets/sets the list of root Items below this root item.
    ''' These items male up the root items that belong to
    ''' the base of the tree structure.
    ''' 
    ''' Public properties (Or fields) with public setter And getter
    ''' are necessary for XML Serialization via XmlSerializer to work
    ''' </summary>
    Public Property RootItems As List(Of Item)

    ''' <summary>
    ''' Gets/sets the version portion of this object.
    ''' 
    ''' Public Setter And Getter are required for the XmlSerializer
    ''' to function for writting And reading XML data.
    ''' </summary>
    Public Property Version As Integer

    ''' <summary>
    ''' Gets/sets the minor version portion of this object.
    ''' 
    ''' Public Setter And Getter are required for the XmlSerializer
    ''' to function for writting And reading XML data.
    ''' </summary>
    Public Property MinorVersion As Integer

    ''' <summary>
    ''' Gets/sets the name of this object.
    ''' 
    ''' Public Setter And Getter are required for the XmlSerializer
    ''' to function for writting And reading XML data.
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' Gets the contents of this object in a human readable way.
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Return String.Format("'{0}' Version: {1}.{2}", Name, Version, MinorVersion)
    End Function
End Class