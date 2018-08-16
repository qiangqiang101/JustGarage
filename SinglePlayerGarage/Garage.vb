Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms

Public Class Garage

    Private _cost, _interiorID As Integer
    Private _owner, _name, _desc, _floor, _garagePath, _saveFile, _playerMap, _ipl, _lastIpl As String
    Private _blip As Blip
    Private _footEntrance, _footExit, _footExit2, _vehicleEntrance, _camerapos, _camerarot, _interior, _lift, _menuActivator As Vector3
    Private _vehicleOutHeading, _cameraFov As Single
    Private _enabled As Boolean
    Private _garageLayout As GarageLayout

    Public Sub New(Name As String, Floor As String, Cost As Integer, Optional Description As String = "")
        _name = Name
        _floor = Floor
        _cost = Cost
        _desc = Description
        _enabled = True
    End Sub

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

    Public Property VehicleOutHeading() As Single
        Get
            Return _vehicleOutHeading
        End Get
        Set(value As Single)
            _vehicleOutHeading = value
        End Set
    End Property

    Public Property CameraPosition() As Vector3
        Get
            Return _camerapos
        End Get
        Set(value As Vector3)
            _camerapos = value
        End Set
    End Property

    Public Property CameraRotation() As Vector3
        Get
            Return _camerarot
        End Get
        Set(value As Vector3)
            _camerarot = value
        End Set
    End Property

    Public Property CameraFOV() As Single
        Get
            Return _camerafov
        End Get
        Set(value As Single)
            _camerafov = value
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

    Public Property SaveFile() As String
        Get
            Return _savefile
        End Get
        Set(value As String)
            _savefile = value
        End Set
    End Property

    Public Property PlayerMap() As String
        Get
            Return _playermap
        End Get
        Set(value As String)
            _playermap = value
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

    Public Shared Function GetInteriorID(interior As Vector3) As Integer
        Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, interior.X, interior.Y, interior.Z)
    End Function

    Public Sub SetInteriorActive()
        Try
            Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Interior.X, Interior.Y, Interior.Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {intID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

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
