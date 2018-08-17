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

    Public Sub New(Name As String, Floor As String, Cost As Integer, Optional Description As String = "")
        _name = Name
        _floor = Floor
        _cost = Cost
        _desc = Description
        _enabled = True
        Create(Me)
    End Sub

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

    Public Sub OnTick()
        Try
            Dim pp As Ped = Game.Player.Character

            If Not Game.IsLoading Then
                If (Not pp.IsInVehicle AndAlso Not pp.IsDead) AndAlso Owner = GetPlayerName() Then
                    If GarageDistance <= 3.0 Then
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            pp.Position = FootExit
                            Script.Wait(1000)
                            Game.FadeScreenIn(1000)
                        Else
                            DisplayHelpTextThisFrame(String.Format("Press ~INPUT_CONTEXT to enter {0}.", Name))
                        End If
                    End If

                    If FootExitDistance <= 3.0 Or FootExitDistance2 <= 3.0 Then
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            pp.Position = VehicleEntrance
                            Script.Wait(1000)
                            Game.FadeScreenIn(1000)
                        Else
                            DisplayHelpTextThisFrame(String.Format("Press ~INPUT_CONTEXT to exit {0}.", Name))
                        End If
                    End If
                End If

                If (Not pp.IsInVehicle AndAlso Not pp.IsDead) AndAlso Owner = Nothing AndAlso pp.IsNearEntity(SellSignProp, pp.Position) Then
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
                    If GarageDistance <= 3.0 Then
                        If Game.IsControlJustPressed(0, GTA.Control.Context) Then
                            Game.FadeScreenOut(1000)
                            Script.Wait(1000)
                            If InteriorID = 0 Then InteriorID = SetInteriorActive()
                            pp.Position = Interior
                            Script.Wait(1000)
                            Game.FadeScreenIn(1000)
                        Else
                            DisplayHelpTextThisFrame(String.Format("Press ~INPUT_CONTEXT to enter {0}.", Name))
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

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
