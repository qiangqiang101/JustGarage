Public Class GarageData

    Public Sub New(ByVal par_name As String)
        Me.New()

        Name = par_name
    End Sub

    Public Sub New()
        RootItems = New List(Of Item)()
        Version = 1
        MinorVersion = 0
        Name = String.Empty
    End Sub

    Public Property RootItems As List(Of Item)
    Public Property Version As Integer
    Public Property MinorVersion As Integer
    Public Property Name As String

    Public Property Floor As Integer
    Public Property Cost As Integer
    Public Property Description As String
    Public Property GaragePath As String
    Public Property Layout As Integer

    Public Property SaveFile As String
    Public Property PlayerMap As String
    Public Property InteriorID As Integer
    Public Property Vectors As GVectors


    Public Overrides Function ToString() As String
        Return String.Format("'{0}' Version: {1}.{2}", Name, Version, MinorVersion)
    End Function
End Class

Public Class GVector
    Inherits Item

    Private _Parent As Item

    Public Sub New(ByRef par_parent As Item, ByVal _x As Single, ByVal _y As Single, ByVal _z As Single)
        Me.New()

        Parent = par_parent
        X = _x
        Y = _y
        Z = _z
    End Sub

    Public Sub New()
        X = 0.0F
        Y = 0.0F
        Z = 0.0F
        Parent = Nothing
    End Sub

    Public Property X As Single
    Public Property Y As Single
    Public Property Z As Single

    Public Overrides Function ToString() As String
        Return String.Format("{0}, {1}, {2}", X, Y, X)
    End Function

    Public Shared Function Zero() As GVector
        Return New GVector()
    End Function
End Class

Public Class GVectors
    Inherits Item

    Private _Parent As Item

    Public Sub New(ByRef par_parent As Item, ByVal fe As GVector, ByVal ve As GVector, ByVal fq As GVector, ByVal fq2 As GVector, ByVal e As GVector, ByVal ma As GVector, ByVal h As Single, ByVal cp As GVector, ByVal cr As GVector, ByVal fv As Single, ByVal i As GVector)
        Me.New()

        Parent = par_parent
        FootEntrance = fe
        VehicleEntrance = ve
        FootExit = fq
        FootExit2 = fq2
        Elevator = e
        MenuActivator = ma
        Heading = h
        CameraPosition = cp
        CameraRotation = cr
        FOV = fv
        Interior = i
    End Sub

    Public Sub New()
        FootEntrance = GVector.Zero
        VehicleEntrance = GVector.Zero
        FootExit = GVector.Zero
        FootExit2 = GVector.Zero
        Elevator = GVector.Zero
        MenuActivator = GVector.Zero
        Heading = 0.0F
        CameraPosition = GVector.Zero
        CameraRotation = GVector.Zero
        FOV = 0.0F
        Interior = GVector.Zero
        Parent = Nothing
    End Sub

    Public Property FootEntrance As GVector
    Public Property VehicleEntrance As GVector
    Public Property FootExit As GVector
    Public Property FootExit2 As GVector
    Public Property Elevator As GVector
    Public Property MenuActivator As GVector
    Public Property Heading As Single
    Public Property CameraPosition As GVector
    Public Property CameraRotation As GVector
    Public Property FOV As Single
    Public Property Interior As GVector

    Public Overrides Function ToString() As String
        Return String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", FootEntrance, VehicleEntrance, FootExit, FootExit2, Elevator, MenuActivator, Heading, CameraPosition, CameraRotation, FOV, Interior)
    End Function
End Class