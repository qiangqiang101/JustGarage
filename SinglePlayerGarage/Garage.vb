Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms

Public Class Garage

    Private _cost, _interiorID, _sellSignHash As Integer
    Private _owner, _name, _desc, _floor, _garagePath, _playerMap, _ipl, _lastIpl, _save As String
    Private _blip As Blip
    Private _footEntrance, _footExit, _footExit2, _vehicleEntrance, _interior, _lift, _menuActivator, _sellSignVector As Vector3
    Private _vehicleOutHeading As Single
    Private _enabled, _hasIPL As Boolean
    Private _garageLayout As GarageLayout
    Private _sellSignProp As Prop
    Private _layout As Object

    Public Sub New(Name As String, Floor As String, Cost As Integer, Optional Description As String = "")
        _name = Name
        _floor = Floor
        _cost = Cost
        _desc = Description
        _enabled = True
        Create(Me)
    End Sub

    Public Property Layout() As Object
        Get
            Return _layout
        End Get
        Set(value As Object)
            _layout = value
        End Set
    End Property

    Public Property Save() As String
        Get
            Return _save
        End Get
        Set(value As String)
            _save = value
        End Set
    End Property

    Public Property Owner() As String
        Get
            Return _owner
        End Get
        Set(value As String)
            _owner = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Floor() As String
        Get
            Return _floor
        End Get
        Set(value As String)
            _floor = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _desc
        End Get
        Set(value As String)
            _desc = value
        End Set
    End Property

    Public Property Cost() As Integer
        Get
            Return _cost
        End Get
        Set(value As Integer)
            _cost = value
        End Set
    End Property

    Public Property GarageBlip() As Blip
        Get
            Return _blip
        End Get
        Set(value As Blip)
            _blip = value
        End Set
    End Property

    Public Property FootEntrance() As Vector3
        Get
            Return _footEntrance
        End Get
        Set(value As Vector3)
            _footEntrance = value
        End Set
    End Property

    Public Property VehicleEntrance() As Vector3
        Get
            Return _vehicleEntrance
        End Get
        Set(value As Vector3)
            _vehicleEntrance = value
        End Set
    End Property

    Public Property FootExit() As Vector3
        Get
            Return _footExit
        End Get
        Set(value As Vector3)
            _footExit = value
        End Set
    End Property

    Public Property FootExit2() As Vector3
        Get
            Return _footExit2
        End Get
        Set(value As Vector3)
            _footExit2 = value
        End Set
    End Property

    Public Property SellSignPosition() As Vector3
        Get
            Return _sellSignVector
        End Get
        Set(value As Vector3)
            _sellSignVector = value
        End Set
    End Property

    Public ReadOnly Property SellSignProp() As Prop
        Get
            If _sellSignProp = Nothing Then _sellSignProp = World.CreateProp(_sellSignHash, _sellSignVector, True, True)
            Return _sellSignProp
        End Get
    End Property

    Public Property VehicleOutHeading() As Single
        Get
            Return _vehicleOutHeading
        End Get
        Set(value As Single)
            _vehicleOutHeading = value
        End Set
    End Property

    Public ReadOnly Property GarageDistance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, VehicleEntrance)
        End Get
    End Property

    Public ReadOnly Property FootExitDistance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, FootExit)
        End Get
    End Property

    Public ReadOnly Property FootExitDistance2() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, FootExit2)
        End Get
    End Property

    Public ReadOnly Property Position() As Vector3
        Get
            Return FootEntrance
        End Get
    End Property

    Public ReadOnly Property IsForSale() As Boolean
        Get
            If GarageBlip.Sprite = BlipSprite.GarageForSale Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Property Enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
        End Set
    End Property

    Public Property GaragePath() As String
        Get
            Return _garagePath
        End Get
        Set(value As String)
            _garagePath = value
        End Set
    End Property

    Public Property Interior() As Vector3
        Get
            Return _interior
        End Get
        Set(value As Vector3)
            _interior = value
        End Set
    End Property

    Public Property RequiredIPL() As Boolean
        Get
            Return _hasIPL
        End Get
        Set(value As Boolean)
            _hasIPL = value
        End Set
    End Property

    Public Property SellSignModel() As Integer
        Get
            Return _sellSignHash
        End Get
        Set(value As Integer)
            _sellSignHash = value
        End Set
    End Property

    Public Property IPL() As String
        Get
            Return _ipl
        End Get
        Set(value As String)
            _ipl = value
        End Set
    End Property

    Public Property LastIPL() As String
        Get
            Return _lastipl
        End Get
        Set(value As String)
            _lastipl = value
        End Set
    End Property

    Public Property InteriorID() As Integer
        Get
            Return _interiorID
        End Get
        Set(value As Integer)
            _interiorID = value
        End Set
    End Property

    Public Property Elevator() As Vector3
        Get
            Return _lift
        End Get
        Set(value As Vector3)
            _lift = value
        End Set
    End Property

    Public Property MenuActivator() As Vector3
        Get
            Return _menuActivator
        End Get
        Set(value As Vector3)
            _menuActivator = value
        End Set
    End Property

    Public Property GarageLayout() As GarageLayout
        Get
            Return _garageLayout
        End Get
        Set(value As GarageLayout)
            _garageLayout = value
        End Set
    End Property

    Public ReadOnly Property GarageElevatorDistance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, Elevator)
        End Get
    End Property

    Public ReadOnly Property GarageMenuActivatorDistance() As Single
        Get
            Return World.GetDistance(Game.Player.Character.Position, MenuActivator)
        End Get
    End Property

    Public Function GetInteriorID(interior As Vector3) As Integer
        Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, interior.X, interior.Y, interior.Z)
    End Function

    Public Sub Create(_garage As Garage)
        _garage.GarageBlip = World.CreateBlip(_garage.FootEntrance)
        _garage.GarageBlip.Sprite = BlipSprite.Garage
        Select Case _garage.Owner
            Case "Michael"
                _garage.GarageBlip.Color = INMBlipColor.Michael
            Case "Franklin"
                _garage.GarageBlip.Color = INMBlipColor.Franklin
            Case "Trevor"
                _garage.GarageBlip.Color = INMBlipColor.Trevor
            Case "Player3"
                _garage.GarageBlip.Color = INMBlipColor.Yellow
            Case Else
                _garage.GarageBlip.Sprite = BlipSprite.GarageForSale
                _garage.GarageBlip.Color = INMBlipColor.White
                _garage.GarageBlip.Name = "Garage for Sale"
        End Select
        _garage.GarageBlip.Name = _garage.Name
        _garage.GarageBlip.IsShortRange = True
    End Sub

    Public Sub Refresh(_garage As Garage)
        _garage.GarageBlip.Sprite = BlipSprite.Garage
        Select Case _garage.Owner
            Case "Michael"
                _garage.GarageBlip.Color = INMBlipColor.Michael
            Case "Franklin"
                _garage.GarageBlip.Color = INMBlipColor.Franklin
            Case "Trevor"
                _garage.GarageBlip.Color = INMBlipColor.Trevor
            Case "Player3"
                _garage.GarageBlip.Color = INMBlipColor.Yellow
            Case Else
                _garage.GarageBlip.Sprite = BlipSprite.GarageForSale
                _garage.GarageBlip.Color = INMBlipColor.White
                _garage.GarageBlip.Name = "Garage for Sale"
        End Select
        _garage.GarageBlip.Name = _garage.Name
        _garage.GarageBlip.IsShortRange = True
    End Sub

    Public Sub Refresh()
        GarageBlip.Sprite = BlipSprite.Garage
        Select Case Owner
            Case "Michael"
                GarageBlip.Color = INMBlipColor.Michael
            Case "Franklin"
                GarageBlip.Color = INMBlipColor.Franklin
            Case "Trevor"
                GarageBlip.Color = INMBlipColor.Trevor
            Case "Player3"
                GarageBlip.Color = INMBlipColor.Yellow
            Case Else
                GarageBlip.Sprite = BlipSprite.GarageForSale
                GarageBlip.Color = INMBlipColor.White
                GarageBlip.Name = "Garage for Sale"
        End Select
        GarageBlip.Name = Name
        GarageBlip.IsShortRange = True
    End Sub

    Public Function SetInteriorActive() As Integer
        Dim interiorID As Integer = 0
        Try
            interiorID = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Interior.X, Interior.Y, Interior.Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {interiorID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, interiorID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, interiorID, False)
            Dim arguments As InputArgument() = New InputArgument() {Interior.X, Interior.Y, Interior.Z, 100, True, False, False, False}
            Native.Function.Call(Hash.CLEAR_AREA, arguments)
            Dim arguments2 As InputArgument() = New InputArgument() {Interior.X, Interior.Y, Interior.Z, 100, True, True, True, True, True}
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
        Return interiorID
    End Function

    Public Function SaveVehicle(vehicle As Vehicle) As Vehicle
        Dim result As Vehicle = vehicle
        If Not IO.File.Exists(GaragePath & "Vehicle_1.xml") Then
            SaveVehicleXML(vehicle, "vehicle_1.xml")
            result = Layout.Vehicle1
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_2.xml") Then
            SaveVehicleXML(vehicle, "vehicle_2.xml")
            result = Layout.Vehicle2
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_3.xml") Then
            SaveVehicleXML(vehicle, "vehicle_3.xml")
            result = Layout.Vehicle3
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_4.xml") Then
            SaveVehicleXML(vehicle, "vehicle_4.xml")
            result = Layout.Vehicle4
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_5.xml") Then
            SaveVehicleXML(vehicle, "vehicle_5.xml")
            result = Layout.Vehicle5
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_6.xml") Then
            SaveVehicleXML(vehicle, "vehicle_6.xml")
            result = Layout.Vehicle6
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_7.xml") Then
            SaveVehicleXML(vehicle, "vehicle_7.xml")
            result = Layout.Vehicle7
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_8.xml") Then
            SaveVehicleXML(vehicle, "vehicle_8.xml")
            result = Layout.Vehicle8
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_9.xml") Then
            SaveVehicleXML(vehicle, "vehicle_9.xml")
            result = Layout.Vehicle9
        End If
        If Not IO.File.Exists(GaragePath & "Vehicle_10.xml") Then
            SaveVehicleXML(vehicle, "vehicle_10.xml")
            result = Layout.Vehicle10
        End If
        Return result
    End Function

    Private Sub SaveVehicleXML(vehicle As Vehicle, xmlFile As String)
        Dim vehData = New VehicleData(vehicle.FriendlyName)
        With vehData
            .VehicleHash = vehicle.Model.GetHashCode()
            .PrimaryColor = vehicle.PrimaryColor
            .SecondaryColor = vehicle.PrimaryColor
            .PearlescentColor = vehicle.PearlescentColor
            .HasCustomPrimaryColor = vehicle.IsPrimaryColorCustom
            .HasCustomSecondaryColor = vehicle.IsSecondaryColorCustom
            .CustomPrimaryColorRed = vehicle.CustomPrimaryColor.R
            .CustomPrimaryColorGreen = vehicle.CustomPrimaryColor.G
            .CustomPrimaryColorBlue = vehicle.CustomPrimaryColor.B
            .CustomSecondaryColorRed = vehicle.CustomSecondaryColor.R
            .CustomSecondaryColorGreen = vehicle.CustomSecondaryColor.G
            .CustomSecondaryColorBlue = vehicle.CustomSecondaryColor.B
            .RimColor = vehicle.RimColor
            .HasNeonLightBack = vehicle.IsNeonLightsOn(VehicleNeonLight.Back)
            .HasNeonLightFront = vehicle.IsNeonLightsOn(VehicleNeonLight.Front)
            .HasNeonLightLeft = vehicle.IsNeonLightsOn(VehicleNeonLight.Left)
            .HasNeonLightRight = vehicle.IsNeonLightsOn(VehicleNeonLight.Right)
            .NeonColorRed = vehicle.NeonLightsColor.R
            .NeonColorGreen = vehicle.NeonLightsColor.G
            .NeonColorBlue = vehicle.NeonLightsColor.B
            .DashboardColor = vehicle.DashboardColor
            .TrimColor = vehicle.TrimColor
            .WheelType = vehicle.WheelType
            .Livery = vehicle.Livery
            .PlateType = vehicle.NumberPlateType
            .WindowTint = vehicle.WindowTint
            .Spoiler = vehicle.GetMod(VehicleMod.Spoilers)
            .FrontBumper = vehicle.GetMod(VehicleMod.FrontBumper)
            .RearBumper = vehicle.GetMod(VehicleMod.RearBumper)
            .SideSkirt = vehicle.GetMod(VehicleMod.SideSkirt)
            .Frame = vehicle.GetMod(VehicleMod.Frame)
            .Grille = vehicle.GetMod(VehicleMod.Grille)
            .Hood = vehicle.GetMod(VehicleMod.Hood)
            .Fender = vehicle.GetMod(VehicleMod.Fender)
            .RightFender = vehicle.GetMod(VehicleMod.RightFender)
            .Roof = vehicle.GetMod(VehicleMod.Roof)
            .Exhaust = vehicle.GetMod(VehicleMod.Exhaust)
            .FrontWheels = vehicle.GetMod(VehicleMod.FrontWheels)
            .FrontTireVariation = Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, vehicle, 23)
            .BackTireVariation = Native.Function.Call(Of Boolean)(Hash.GET_VEHICLE_MOD_VARIATION, vehicle, 24)
            .Suspension = vehicle.GetMod(VehicleMod.Suspension)
            .Engine = vehicle.GetMod(VehicleMod.Engine)
            .Brakes = vehicle.GetMod(VehicleMod.Brakes)
            .Transmission = vehicle.GetMod(VehicleMod.Transmission)
            .Armor = vehicle.GetMod(VehicleMod.Armor)
            .PlateHolder = vehicle.GetMod(VehicleMod.PlateHolder)
            .VanityPlates = vehicle.GetMod(VehicleMod.VanityPlates)
            .TrimDesign = vehicle.GetMod(VehicleMod.TrimDesign)
            .Ornaments = vehicle.GetMod(VehicleMod.Ornaments)
            .Dashboard = vehicle.GetMod(VehicleMod.Dashboard)
            .DialDesign = vehicle.GetMod(VehicleMod.DialDesign)
            .DoorSpeakers = vehicle.GetMod(VehicleMod.DoorSpeakers)
            .Seats = vehicle.GetMod(VehicleMod.Seats)
            .SteeringWheels = vehicle.GetMod(VehicleMod.SteeringWheels)
            .ColumnShifterLevers = vehicle.GetMod(VehicleMod.ColumnShifterLevers)
            .Plaques = vehicle.GetMod(VehicleMod.Plaques)
            .Speakers = vehicle.GetMod(VehicleMod.Speakers)
            .Trunk = vehicle.GetMod(VehicleMod.Trunk)
            .Hydraulics = vehicle.GetMod(VehicleMod.Hydraulics)
            .EngineBlock = vehicle.GetMod(VehicleMod.EngineBlock)
            .AirFilter = vehicle.GetMod(VehicleMod.AirFilter)
            .Struts = vehicle.GetMod(VehicleMod.Struts)
            .ArchCover = vehicle.GetMod(VehicleMod.ArchCover)
            .Aerials = vehicle.GetMod(VehicleMod.Aerials)
            .Trim = vehicle.GetMod(VehicleMod.Trim)
            .Tank = vehicle.GetMod(VehicleMod.Tank)
            .Windows = vehicle.GetMod(VehicleMod.Windows)
            .BennysLivery = vehicle.GetMod(VehicleMod.Livery)
            .Horn = vehicle.GetMod(VehicleMod.Horns)
            .XenonHeadlights = vehicle.IsToggleModOn(VehicleToggleMod.XenonHeadlights)
            .Turbo = vehicle.IsToggleModOn(VehicleToggleMod.Turbo)
            .TyreSmokeColorRed = vehicle.TireSmokeColor.R
            .TyreSmokeColorGreen = vehicle.TireSmokeColor.G
            .TyreSmokeColorBlue = vehicle.TireSmokeColor.B
            .BulletproofTyres = vehicle.CanTiresBurst
            .RoofState = vehicle.RoofState
            .CustomRoof = GetTornadoCustomRoof(vehicle)
            .Extra1 = vehicle.IsExtraOn(1)
            .Extra2 = vehicle.IsExtraOn(2)
            .Extra3 = vehicle.IsExtraOn(3)
            .Extra4 = vehicle.IsExtraOn(4)
            .Extra5 = vehicle.IsExtraOn(5)
            .Extra6 = vehicle.IsExtraOn(6)
            .Extra7 = vehicle.IsExtraOn(7)
            .Extra8 = vehicle.IsExtraOn(8)
            .Extra9 = vehicle.IsExtraOn(9)
            .Extra10 = vehicle.IsExtraOn(10)
        End With
        XMLRead.WriteXmlToFile(xmlFile, vehData)
    End Sub

    Public Sub OnTick()
        Try
            Dim pp As Ped = Game.Player.Character

            If Not Game.IsLoading Then
                If (Not pp.IsInVehicle AndAlso Not pp.IsDead) AndAlso Owner = GetPlayerName() Then
                    If GarageDistance <= 3.0 Then 'Outside teleport to Garage Door
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            pp.Position = FootExit
                            Layout.LoadGarageVehicles()
                            Script.Wait(1000)
                            Game.FadeScreenIn(1000)
                        Else
                            DisplayHelpTextThisFrame(String.Format("Press ~INPUT_CONTEXT to enter {0}.", Name))
                        End If
                    End If

                    If FootExitDistance <= 3.0 Or FootExitDistance2 <= 3.0 Then 'Garage Door teleport to Outside
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            pp.Position = VehicleEntrance
                            Layout.DeleteGarageVehicles()
                            Script.Wait(1000)
                            Game.FadeScreenIn(1000)
                        Else
                            DisplayHelpTextThisFrame(String.Format("Press ~INPUT_CONTEXT to exit {0}.", Name))
                        End If
                    End If
                End If

                If (Not pp.IsInVehicle AndAlso Not pp.IsDead) AndAlso Owner = Nothing AndAlso pp.IsNearEntity(SellSignProp, pp.Position) Then 'Buy Garage
                    If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                        pp.Money = (pp.Money - Cost)
                        Owner = GetPlayerName()
                        WriteCfgValue(Save, GetPlayerName(), ConfigFile)
                        Refresh()
                    Else
                        DisplayHelpTextThisFrame(String.Format("Press ~INPUT_CONTEXT to purchase {0}.", Name))
                    End If
                End If

                If (pp.IsInVehicle AndAlso pp.IsAlive) AndAlso Owner = GetPlayerName() Then
                    If GarageDistance <= 3.0 Then 'In Vehicle Outside teleport to Garage and Save vehicle
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If InteriorID = 0 Then InteriorID = SetInteriorActive()
                            Layout.LoadGarageVehicles()

                            Dim pv As Vehicle = pp.LastVehicle
                            Dim sv As Vehicle = SaveVehicle(pv)
                            pv.Delete()
                            pp.Position = Interior
                            SetIntoVehicle(pp, sv, VehicleSeat.Driver)
                            pp.Task.LeaveVehicle(pp.LastVehicle, True)

                            Script.Wait(1000)
                            Game.FadeScreenIn(1000)
                        Else
                            DisplayHelpTextThisFrame(String.Format("Press ~INPUT_CONTEXT to enter {0}.", Name))
                        End If
                    End If

                    'Exiting Garage teleport to outside with vehicle
                    Dim layout_ As TenCarGarage = Layout
                    Select Case pp.CurrentVehicle
                        Case layout_.Vehicle1
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle1.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_1.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle2
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle2.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_2.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle3
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle3.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_3.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle4
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle4.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_4.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle5
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle5.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_5.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle6
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle6.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_6.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle7
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle7.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_7.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle8
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle8.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_8.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle9
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle9.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_9.xml")
                                GoTo ExitGarage
                            End If
                        Case layout_.Vehicle10
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If layout_.Vehicle10.Speed >= 1.5 Then
                                IO.File.Delete(GaragePath & "vehicle_10.xml")
                                GoTo ExitGarage
                            End If
                        Case Else
                            Exit Sub
                    End Select

ExitGarage:
                    pp.CurrentVehicle.Position = VehicleEntrance
                    pp.CurrentVehicle.Heading = VehicleOutHeading
                    Script.Wait(1000)
                    Game.FadeScreenIn(1000)
                End If
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnAborted()
        If Not GarageBlip Is Nothing Then GarageBlip.Remove()
    End Sub
End Class

Public Class PersonalVehicle

    Private _owner As String
    Public Property Owner() As String
        Get
            Return _owner
        End Get
        Set(value As String)
            _owner = value
        End Set
    End Property

    Private _file As String
    Public Property FilePath() As String
        Get
            Return _file
        End Get
        Set(value As String)
            _file = value
        End Set
    End Property

    Private _vehicle As Vehicle
    Public Property Vehicle() As Vehicle
        Get
            Return _vehicle
        End Get
        Set(value As Vehicle)
            _vehicle = value
        End Set
    End Property

    Private _enable As Boolean
    Public Property Enable() As Boolean
        Get
            Return _enable
        End Get
        Set(value As Boolean)
            _enable = value
        End Set
    End Property

    Public ReadOnly Property Exist() As Boolean
        Get
            Return Not _file = Nothing
        End Get
    End Property

    Private _insurance As Integer
    Public Property Insurance() As Integer
        Get
            Return _insurance
        End Get
        Set(value As Integer)
            _insurance = value
        End Set
    End Property

    Public Sub New()
        _enable = False
    End Sub

    Public Sub New(Owner As String, FilePath As String, ByRef Vehicle As Vehicle)
        _owner = Owner
        _file = FilePath
        _vehicle = Vehicle
        _enable = True
        _insurance = 1
    End Sub

    Public Sub Delete()
        Owner = Nothing
        FilePath = Nothing
        Vehicle = Nothing
        Enable = False
    End Sub
End Class

Public Enum INMBlipColor
    White = 0
    Franklin = 43
    Michael = 42
    Trevor = 44
    Yellow = 66
End Enum

Public Class SPGVehicle
    Public Handle As Vehicle
    Public State As VehicleState
End Class

Public Enum VehicleState
    ' Fields
    Active = 1
    InGarage = 0
    Destroyed = 2
End Enum

Public Enum GarageLayout
    TwoCarGarage = 2
    SixCarGarage = 6
    TenCarGarage = 10
End Enum
