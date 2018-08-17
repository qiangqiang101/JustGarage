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
        If Not Game.IsLoading Then
            For Each datafile In Directory.GetFiles(DataPath, "*.xml")
                Dim xml = XMLRead.ReadXmlFromFile(Of GarageData)(datafile)
                Dim garage As Garage
                With xml
                    garage = New Garage(.Name, .Floor, .Cost, .Description)
                    With garage
                        .Save = xml.Save
                        .Owner = ReadCfgValue(xml.Save, ConfigFile)
                        .GaragePath = xml.GaragePath
                        .GarageLayout = xml.Layout
                        .RequiredIPL = xml.RequiredIPL
                        .InteriorID = .SetInteriorActive()
                        .FootEntrance = New Vector3(xml.Vectors.FootEntrance.X, xml.Vectors.FootEntrance.Y, xml.Vectors.FootEntrance.Z)
                        .VehicleEntrance = New Vector3(xml.Vectors.VehicleEntrance.X, xml.Vectors.VehicleEntrance.Y, xml.Vectors.VehicleEntrance.Z)
                        .FootExit = New Vector3(xml.Vectors.FootExit.X, xml.Vectors.FootExit.Y, xml.Vectors.FootExit.Z)
                        .FootExit2 = New Vector3(xml.Vectors.FootExit2.X, xml.Vectors.FootExit2.Y, xml.Vectors.FootExit2.Z)
                        .Elevator = New Vector3(xml.Vectors.Elevator.X, xml.Vectors.Elevator.Y, xml.Vectors.Elevator.Z)
                        .MenuActivator = New Vector3(xml.Vectors.MenuActivator.X, xml.Vectors.MenuActivator.Y, xml.Vectors.MenuActivator.Z)
                        .VehicleOutHeading = xml.Vectors.Heading
                        .Interior = New Vector3(xml.Vectors.Interior.X, xml.Vectors.Interior.Y, xml.Vectors.Interior.Z)
                        .SellSignModel = xml.SellSignModel
                        .SellSignPosition = New Vector3(xml.Vectors.SellSignPosition.X, xml.Vectors.SellSignPosition.Y, xml.Vectors.SellSignPosition.Z)
                    End With
                End With
                GarageList.Add(garage)
            Next
        End If
    End Sub

    Public Sub WriteDemoData()
        Dim garagedata = New GarageData("Demo Garage")
        With garagedata
            .Floor = 1
            .Cost = 100000
            .Description = "Description of the Garage goes here..."
            .GaragePath = ".\scripts\JustGarage\Garage\demo_garage"
            .Layout = 10
            .RequiredIPL = False
            .InteriorID = 1
            .SellSignModel = ""
            .Save = "DemoGarage"
            .Vectors = New GVectors()
            With .Vectors
                .FootEntrance = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .VehicleEntrance = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .FootExit = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .FootExit2 = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .Elevator = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .MenuActivator = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .Heading = 100.2F
                .Interior = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
                .SellSignPosition = New GVector(garagedata.Vectors, 1.0F, 2.0F, 3.0F)
            End With
        End With
        XMLRead.WriteXmlToFile("data.xml", garagedata)
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        For Each grg In GarageList
            grg.OnTick()
        Next
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        For Each grg In GarageList
            grg.OnAborted()
        Next
    End Sub

End Class
