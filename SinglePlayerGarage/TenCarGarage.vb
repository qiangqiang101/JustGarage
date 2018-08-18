Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.IO

Public Class TenCarGarage

    Public Property Garage As Garage
    Public Property CurrentPath As String
    Public Property Vehicle1 As Vehicle
    Public Property Vehicle2 As Vehicle
    Public Property Vehicle3 As Vehicle
    Public Property Vehicle4 As Vehicle
    Public Property Vehicle5 As Vehicle
    Public Property Vehicle6 As Vehicle
    Public Property Vehicle7 As Vehicle
    Public Property Vehicle8 As Vehicle
    Public Property Vehicle9 As Vehicle
    Public Property Vehicle10 As Vehicle

    Public ReadOnly Property Elevator() As Vector3
        Get
            Return New Vector3(238.7097, -1004.8488, -98.9999)
        End Get
    End Property

    Public ReadOnly Property FootExit() As Vector3
        Get
            Return New Vector3(231.9013, -1006.686, -98.9999)
        End Get
    End Property

    Public ReadOnly Property FootExit2() As Vector3
        Get
            Return New Vector3(224.4288, -1006.6892, -98.9999)
        End Get
    End Property

    Public ReadOnly Property MenuActivator() As Vector3
        Get
            Return New Vector3(226.5738, -975.5375, -99.9999)
        End Get
    End Property

    Public ReadOnly Property ElevatorDistance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, Elevator)
        End Get
    End Property

    Public ReadOnly Property FootExitDistance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, FootExit)
        End Get
    End Property

    Public ReadOnly Property FootExit2Distance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, FootExit2)
        End Get
    End Property

    Public ReadOnly Property MenuDistance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, MenuActivator)
        End Get
    End Property

    Public ReadOnly Property Vehicle1Position() As Vector3
        Get
            Return New Vector3(223.4, -1001, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle2Position() As Vector3
        Get
            Return New Vector3(223.4, -996, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle3Position() As Vector3
        Get
            Return New Vector3(223.4, -991, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle4Position() As Vector3
        Get
            Return New Vector3(223.4, -986, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle5Position() As Vector3
        Get
            Return New Vector3(223.4, -981, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle6Position() As Vector3
        Get
            Return New Vector3(232.7, -1001, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle7Position() As Vector3
        Get
            Return New Vector3(232.7, -996, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle8Position() As Vector3
        Get
            Return New Vector3(232.7, -991, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle9Position() As Vector3
        Get
            Return New Vector3(232.7, -986, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle10Position() As Vector3
        Get
            Return New Vector3(232.7, -981, -99.0)
        End Get
    End Property

    Public ReadOnly Property Vehicle1to5Rotation() As Vector3
        Get
            Return New Vector3(0, 0, 241.3)
        End Get
    End Property

    Public ReadOnly Property Vehicle6to10Rotation() As Vector3
        Get
            Return New Vector3(0, 0, 116.3)
        End Get
    End Property

    Public Sub New(_Garage As Garage, Path As String)
        _Garage = Garage
        Path = Currentpath
    End Sub

    Public Sub DeleteGarageVehicles()
        If Not Vehicle1 = Nothing Then Vehicle1.Delete()
        If Not Vehicle2 = Nothing Then Vehicle2.Delete()
        If Not Vehicle3 = Nothing Then Vehicle3.Delete()
        If Not Vehicle4 = Nothing Then Vehicle4.Delete()
        If Not Vehicle5 = Nothing Then Vehicle5.Delete()
        If Not Vehicle6 = Nothing Then Vehicle6.Delete()
        If Not Vehicle7 = Nothing Then Vehicle7.Delete()
        If Not Vehicle8 = Nothing Then Vehicle8.Delete()
        If Not Vehicle9 = Nothing Then Vehicle9.Delete()
        If Not Vehicle10 = Nothing Then Vehicle10.Delete()
    End Sub

    Public Sub LoadGarageVehicles()
        Try
            If Not Vehicle1 = Nothing Then Vehicle1.Delete()
            If Not Vehicle2 = Nothing Then Vehicle2.Delete()
            If Not Vehicle3 = Nothing Then Vehicle3.Delete()
            If Not Vehicle4 = Nothing Then Vehicle4.Delete()
            If Not Vehicle5 = Nothing Then Vehicle5.Delete()
            If Not Vehicle6 = Nothing Then Vehicle6.Delete()
            If Not Vehicle7 = Nothing Then Vehicle7.Delete()
            If Not Vehicle8 = Nothing Then Vehicle8.Delete()
            If Not Vehicle9 = Nothing Then Vehicle9.Delete()
            If Not Vehicle10 = Nothing Then Vehicle10.Delete()

            If IO.File.Exists(CurrentPath & "Vehicle_1.xml") Then LoadGarageVehicle(Vehicle1, CurrentPath & "vehicle_1.xml", Vehicle1Position, Vehicle1to5Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_2.xml") Then LoadGarageVehicle(Vehicle2, CurrentPath & "vehicle_2.xml", Vehicle2Position, Vehicle1to5Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_3.xml") Then LoadGarageVehicle(Vehicle3, CurrentPath & "vehicle_3.xml", Vehicle3Position, Vehicle1to5Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_4.xml") Then LoadGarageVehicle(Vehicle4, CurrentPath & "vehicle_4.xml", Vehicle4Position, Vehicle1to5Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_5.xml") Then LoadGarageVehicle(Vehicle5, CurrentPath & "vehicle_5.xml", Vehicle5Position, Vehicle1to5Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_6.xml") Then LoadGarageVehicle(Vehicle6, CurrentPath & "vehicle_6.xml", Vehicle6Position, Vehicle6to10Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_7.xml") Then LoadGarageVehicle(Vehicle7, CurrentPath & "vehicle_7.xml", Vehicle7Position, Vehicle6to10Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_8.xml") Then LoadGarageVehicle(Vehicle8, CurrentPath & "vehicle_8.xml", Vehicle8Position, Vehicle6to10Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_9.xml") Then LoadGarageVehicle(Vehicle9, CurrentPath & "vehicle_9.xml", Vehicle9Position, Vehicle6to10Rotation, -60)
            If IO.File.Exists(CurrentPath & "Vehicle_10.xml") Then LoadGarageVehicle(Vehicle10, CurrentPath & "vehicle_10.xml", Vehicle10Position, Vehicle6to10Rotation, -60)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGarageVehicle(vehicle As Vehicle, file As String, pos As Vector3, rot As Vector3, head As Single)
        Try
            If vehicle = Nothing Then vehicle.Delete()
            Dim xml = XMLRead.ReadXmlFromFile(Of VehicleData)(file)
            With xml
                vehicle = CreateVehicle(xml.VehicleHash, pos, head)
                With vehicle
                    .InstallModKit()
                    .DirtLevel = 0F
                    .PrimaryColor = xml.PrimaryColor
                    .SecondaryColor = xml.PrimaryColor
                    .PearlescentColor = xml.PearlescentColor
                    If xml.HasCustomPrimaryColor Then .CustomPrimaryColor = Drawing.Color.FromArgb(xml.CustomPrimaryColorRed, xml.CustomPrimaryColorGreen, xml.CustomPrimaryColorBlue)
                    If xml.HasCustomSecondaryColor Then .CustomSecondaryColor = Drawing.Color.FromArgb(xml.CustomSecondaryColorRed, xml.CustomSecondaryColorGreen, xml.CustomSecondaryColorBlue)
                    .RimColor = xml.RimColor
                    .SetNeonLightsOn(VehicleNeonLight.Back, xml.HasNeonLightBack)
                    .SetNeonLightsOn(VehicleNeonLight.Front, xml.HasNeonLightFront)
                    .SetNeonLightsOn(VehicleNeonLight.Left, xml.HasNeonLightLeft)
                    .SetNeonLightsOn(VehicleNeonLight.Right, xml.HasNeonLightRight)
                    .NeonLightsColor = Drawing.Color.FromArgb(xml.NeonColorRed, xml.NeonColorGreen, xml.NeonColorBlue)
                    .DashboardColor = xml.DashboardColor
                    .TrimColor = xml.TrimColor
                    .WheelType = xml.WheelType
                    .Livery = xml.Livery
                    .NumberPlateType = xml.PlateType
                    .WindowTint = xml.WindowTint
                    .SetMod(VehicleMod.Spoilers, xml.Spoiler, True)
                    .SetMod(VehicleMod.FrontBumper, xml.FrontBumper, True)
                    .SetMod(VehicleMod.RearBumper, xml.RearBumper, True)
                    .SetMod(VehicleMod.SideSkirt, xml.SideSkirt, True)
                    .SetMod(VehicleMod.Frame, xml.Frame, True)
                    .SetMod(VehicleMod.Grille, xml.Grille, True)
                    .SetMod(VehicleMod.Hood, xml.Hood, True)
                    .SetMod(VehicleMod.Fender, xml.Fender, True)
                    .SetMod(VehicleMod.RightFender, xml.RightFender, True)
                    .SetMod(VehicleMod.Roof, xml.Roof, True)
                    .SetMod(VehicleMod.Exhaust, xml.Exhaust, True)
                    .SetMod(VehicleMod.FrontWheels, xml.FrontWheels, xml.FrontTireVariation)
                    .SetMod(VehicleMod.BackWheels, xml.BackWheels, xml.BackTireVariation)
                    .SetMod(VehicleMod.Suspension, xml.Suspension, True)
                    .SetMod(VehicleMod.Engine, xml.Engine, True)
                    .SetMod(VehicleMod.Brakes, xml.Brakes, True)
                    .SetMod(VehicleMod.Transmission, xml.Transmission, True)
                    .SetMod(VehicleMod.Armor, xml.Armor, True)
                    .SetMod(VehicleMod.PlateHolder, xml.PlateHolder, True)
                    .SetMod(VehicleMod.VanityPlates, xml.VanityPlates, True)
                    .SetMod(VehicleMod.TrimDesign, xml.TrimDesign, True)
                    .SetMod(VehicleMod.Ornaments, xml.Ornaments, True)
                    .SetMod(VehicleMod.Dashboard, xml.Dashboard, True)
                    .SetMod(VehicleMod.DialDesign, xml.DialDesign, True)
                    .SetMod(VehicleMod.DoorSpeakers, xml.DoorSpeakers, True)
                    .SetMod(VehicleMod.Seats, xml.Seats, True)
                    .SetMod(VehicleMod.SteeringWheels, xml.SteeringWheels, True)
                    .SetMod(VehicleMod.ColumnShifterLevers, xml.ColumnShifterLevers, True)
                    .SetMod(VehicleMod.Plaques, xml.Plaques, True)
                    .SetMod(VehicleMod.Speakers, xml.Speakers, True)
                    .SetMod(VehicleMod.Trunk, xml.Trunk, True)
                    .SetMod(VehicleMod.Hydraulics, xml.Hydraulics, True)
                    .SetMod(VehicleMod.EngineBlock, xml.EngineBlock, True)
                    .SetMod(VehicleMod.AirFilter, xml.AirFilter, True)
                    .SetMod(VehicleMod.Struts, xml.Struts, True)
                    .SetMod(VehicleMod.ArchCover, xml.ArchCover, True)
                    .SetMod(VehicleMod.Aerials, xml.Aerials, True)
                    .SetMod(VehicleMod.Trim, xml.Trim, True)
                    .SetMod(VehicleMod.Tank, xml.Tank, True)
                    .SetMod(VehicleMod.Windows, xml.Windows, True)
                    .SetMod(VehicleMod.Livery, xml.BennysLivery, True)
                    .SetMod(VehicleMod.Horns, xml.Horn, True)
                    .ToggleMod(VehicleToggleMod.XenonHeadlights, xml.XenonHeadlights)
                    .ToggleMod(VehicleToggleMod.Turbo, xml.Turbo)
                    .ToggleMod(VehicleToggleMod.TireSmoke, True)
                    .TireSmokeColor = Drawing.Color.FromArgb(xml.TyreSmokeColorRed, xml.TyreSmokeColorGreen, xml.TyreSmokeColorBlue)
                    .CanTiresBurst = xml.BulletproofTyres
                    .RoofState = xml.RoofState
                    .ToggleExtra(1, xml.Extra1)
                    .ToggleExtra(2, xml.Extra2)
                    .ToggleExtra(3, xml.Extra3)
                    .ToggleExtra(4, xml.Extra4)
                    .ToggleExtra(5, xml.Extra5)
                    .ToggleExtra(6, xml.Extra6)
                    .ToggleExtra(7, xml.Extra7)
                    .ToggleExtra(8, xml.Extra8)
                    .ToggleExtra(9, xml.Extra9)
                    .ToggleExtra(10, xml.Extra10)
                    SetTornadoCustomRoof(vehicle, xml.CustomRoof)
                    .IsPersistent = True
                End With
            End With
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
