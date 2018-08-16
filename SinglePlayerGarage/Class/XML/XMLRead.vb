Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class XMLRead

    '''<summary>
    ''' Writes the associated XML of class Model T into string And returns it.
    '''</summary>
    Public Shared Function WriteXmlToString(Of T)(ByVal rootModel As T) As String

        Using writer = New StringWriter()
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            serializer.Serialize(writer, rootModel)
            Return writer.ToString()
        End Using
    End Function

    '''<summary>
    ''' Writes the associated XML of class Model T into a file.
    '''</summary>
    Public Shared Sub WriteXmlToFile(Of T)(ByVal filename As String, ByVal rootModel As T)

        Using writer As StreamWriter = New StreamWriter(filename)
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            serializer.Serialize(writer, rootModel)
        End Using
    End Sub

    '''<summary>
    ''' Reads the associated XML of class Model T from a string into an
    ''' instance of class model T And returns it.
    '''
    ''' An exception Is thrown if the XML appears to be invalid for class model T.
    '''</summary>
    Public Shared Function ReadXmlFromString(Of T)(ByVal input As String) As T

        Using reader = New StringReader(input)
            Dim deserializer As XmlSerializer = New XmlSerializer(GetType(T))
            Return CType(deserializer.Deserialize(reader), T)
        End Using
    End Function

    '''<summary>
    ''' Reads the associated XML of class Model T
    ''' from a file into an instance of class model T
    ''' And returns it.
    '''
    ''' An exception Is thrown if the XML appears to be invalid for class model T.
    '''</summary>
    Public Shared Function ReadXmlFromFile(Of T)(ByVal filename As String) As T

        Using reader = XmlReader.Create(filename)
            Dim deserializer As XmlSerializer = New XmlSerializer(GetType(T))
            Return CType(deserializer.Deserialize(reader), T)
        End Using
    End Function

End Class
