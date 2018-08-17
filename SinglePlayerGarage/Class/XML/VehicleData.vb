Imports GTA
Imports GTA.Math

Public Class VehicleData

    Public Sub New(ByVal par_name As String)
        Me.New()

        VehicleName = par_name
    End Sub

    Public Sub New()
        Version = 1
        MinorVersion = 0
        VehicleName = String.Empty
    End Sub

    Public Property Version As Integer
    Public Property MinorVersion As Integer

    Public Property VehicleName As String
    Public Property VehicleHash As Integer
    Public Property PrimaryColor As VehicleColor
    Public Property SecondaryColor As VehicleColor
    Public Property PearlescentColor As VehicleColor
    Public Property HasCustomPrimaryColor As Boolean
    Public Property HasCustomSecondaryColor As Boolean
    Public Property CustomPrimaryColorRed As Integer
    Public Property CustomPrimaryColorGreen As Integer
    Public Property CustomPrimaryColorBlue As Integer
    Public Property CustomSecondaryColorRed As Integer
    Public Property CustomSecondaryColorGreen As Integer
    Public Property CustomSecondaryColorBlue As Integer
    Public Property RimColor As VehicleColor
    Public Property HasNeonLightBack As Boolean
    Public Property HasNeonLightFront As Boolean
    Public Property HasNeonLightLeft As Boolean
    Public Property HasNeonLightRight As Boolean
    Public Property NeonColorRed As Integer
    Public Property NeonColorGreen As Integer
    Public Property NeonColorBlue As Integer
    Public Property TyreSmokeColorRed As Integer
    Public Property TyreSmokeColorGreen As Integer
    Public Property TyreSmokeColorBlue  As Integer
    Public Property TrimColor As VehicleColor
    Public Property DashboardColor As VehicleColor
    Public Property WheelType As VehicleWheelType
    Public Property Livery As Integer
    Public Property PlateType As NumberPlateType
    Public Property PlateNumber As String
    Public Property WindowTint As VehicleWindowTint
    Public Property Spoiler As Integer
    Public Property FrontBumper As Integer
    Public Property RearBumper As Integer
    Public Property SideSkirt As Integer
    Public Property Frame As Integer
    Public Property Grille As Integer
    Public Property Hood As Integer
    Public Property Fender As Integer
    Public Property RightFender As Integer
    Public Property Roof As Integer
    Public Property Exhaust As Integer
    Public Property FrontWheels As Integer
    Public Property BackWheels As Integer
    Public Property Suspension As Integer
    Public Property Engine As Integer
    Public Property Brakes As Integer
    Public Property Transmission As Integer
    Public Property Armor As Integer
    Public Property XenonHeadlights As Boolean
    Public Property Turbo As Integer
    Public Property Horn As Integer
    Public Property BulletproofTyres As Integer
    Public Property FrontTireVariation As Boolean
    Public Property BackTireVariation As Boolean
    Public Property PlateHolder As Integer
    Public Property VanityPlates As Integer
    Public Property TrimDesign As Integer
    Public Property Ornaments As Integer
    Public Property Dashboard As Integer
    Public Property DialDesign As Integer
    Public Property DoorSpeakers As Integer
    Public Property Seats As Integer
    Public Property SteeringWheels As Integer
    Public Property ColumnShifterLevers As Integer
    Public Property Plaques As Integer
    Public Property Speakers As Integer
    Public Property Trunk As Integer
    Public Property Hydraulics As Integer
    Public Property EngineBlock As Integer
    Public Property AirFilter As Integer
    Public Property Struts As Integer
    Public Property ArchCover As Integer
    Public Property Aerials As Integer
    Public Property Trim As Integer
    Public Property Tank As Integer
    Public Property Windows As Integer
    Public Property BennysLivery As Integer
    Public Property Extra1 As Integer
    Public Property Extra2 As Integer
    Public Property Extra3 As Integer
    Public Property Extra4 As Integer
    Public Property Extra5 As Integer
    Public Property Extra6 As Integer
    Public Property Extra7 As Integer
    Public Property Extra8 As Integer
    Public Property Extra9 As Integer
    Public Property CustomRoof As Integer

    Public Overrides Function ToString() As String
        Return String.Format("'{0}' Version: {1}.{2}", VehicleName, Version, MinorVersion)
    End Function
End Class