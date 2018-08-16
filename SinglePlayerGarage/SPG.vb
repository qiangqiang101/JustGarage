Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports System.IO

Public Class SPG
    Inherits Script

    Public Shared GarageList As New List(Of Garage)

    Public Sub New()
        For Each datafile In Directory.GetFiles(DataPath, "*.xml")
            Dim xml = XMLRead.ReadXmlFromFile(Of GarageData)(datafile)
            Dim garage As Garage
            With xml
                garage = New Garage(.Name, .Floor, .Cost, .Description)
                With garage
                    .GaragePath = xml.GaragePath
                    .GarageLayout = xml.Layout
                    .SaveFile = xml.SaveFile
                    .PlayerMap = xml.PlayerMap
                    .InteriorID = xml.InteriorID
                    .FootEntrance = New Vector3(xml.Vectors.FootEntrance.X, xml.Vectors.FootEntrance.Y, xml.Vectors.FootEntrance.Z)
                    .VehicleEntrance = New Vector3(xml.Vectors.VehicleEntrance.X, xml.Vectors.VehicleEntrance.Y, xml.Vectors.VehicleEntrance.Z)
                    .FootExit = New Vector3(xml.Vectors.FootExit.X, xml.Vectors.FootExit.Y, xml.Vectors.FootExit.Z)
                    .FootExit2 = New Vector3(xml.Vectors.FootExit2.X, xml.Vectors.FootExit2.Y, xml.Vectors.FootExit2.Z)
                    .Elevator = New Vector3(xml.Vectors.Elevator.X, xml.Vectors.Elevator.Y, xml.Vectors.Elevator.Z)
                    .MenuActivator = New Vector3(xml.Vectors.MenuActivator.X, xml.Vectors.MenuActivator.Y, xml.Vectors.MenuActivator.Z)
                    .VehicleOutHeading = xml.Vectors.Heading
                    .CameraPosition = New Vector3(xml.Vectors.CameraPosition.X, xml.Vectors.CameraPosition.Y, xml.Vectors.CameraPosition.Z)
                    .CameraRotation = New Vector3(xml.Vectors.CameraRotation.X, xml.Vectors.CameraRotation.Y, xml.Vectors.CameraRotation.Z)
                    .CameraFOV = xml.Vectors.FOV
                    .Interior = New Vector3(xml.Vectors.Interior.X, xml.Vectors.Interior.Y, xml.Vectors.Interior.Z)
                End With
            End With
            GarageList.Add(garage)
        Next
    End Sub

    Public Sub WriteDemoData()
        Dim garagedata = New GarageData("Demo Garage")
        With garagedata
            .Floor = 1
            .Cost = 100000
            .Description = "Description of the Garage goes here..."
            .GaragePath = ".\scripts\JustGarage\Garage\demo_garage"
            .Layout = 10
            .SaveFile = ""
            .PlayerMap = ""
            .InteriorID = 1
            .Vectors = New GVectors()
            With .Vectors
                .FootEntrance = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .VehicleEntrance = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .FootExit = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .FootExit2 = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .Elevator = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .MenuActivator = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .Heading = 100.2F
                .CameraPosition = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .CameraRotation = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .FOV = 5.0F
                .Interior = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
            End With
        End With
        XMLRead.WriteXmlToFile("data.xml", garagedata)
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick

    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted

    End Sub

End Class
