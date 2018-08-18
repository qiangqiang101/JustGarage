Imports GTA
Imports GTA.Math
Imports GTA.Native

Module Helper

    Public DataPath As String = ".\scripts\JustGarage\Data"
    Public GaragePath As String = ".\scripts\JustGarage\Garage"
    Public ConfigFile As String = ".\scripts\JustGarage\JustGarage.cfg"

    Public Sub DisplayHelpTextThisFrame(helpText As String, Optional Shape As Integer = -1)
        Native.Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "CELL_EMAIL_BCON")
        Const maxStringLength As Integer = 99

        Dim i As Integer = 0
        While i < helpText.Length
            Native.Function.Call(Hash._0x6C188BE134E074AA, helpText.Substring(i, System.Math.Min(maxStringLength, helpText.Length - i)))
            i += maxStringLength
        End While
        Native.Function.Call(Hash._DISPLAY_HELP_TEXT_FROM_STRING_LABEL, 0, 0, 1, Shape)
    End Sub

    Public Function GetPlayerName() As String
        Dim Name As String = "Player3"
        Select Case Game.Player.Character.Model.GetHashCode
            Case 225514697
                Name = "Michael"
            Case -1692214353
                Name = "Franklin"
            Case -1686040670
                Name = "Trevor"
            Case Else
                Name = "Player3"
        End Select
        Return Name
    End Function

    Private Function WorldCreateVehicle(model As Model, position As Vector3, Optional heading As Single = 0F) As Vehicle
        If Not model.IsVehicle OrElse Not model.Request(1000) Then
            Return Nothing
        End If

        Return New Vehicle([Function].[Call](Of Integer)(Hash.CREATE_VEHICLE, model.Hash, position.X, position.Y, position.Z, heading,
        False, False))
    End Function

    Public Function CreateVehicle(VehicleHash As Integer, Position As Vector3, Optional Heading As Single = 0) As Vehicle
        Dim Result As Vehicle = Nothing

        Dim model = New Model(VehicleHash)
        model.Request(250)
        If model.IsInCdImage AndAlso model.IsValid Then
            While Not model.IsLoaded
                Script.Wait(0)
            End While
            Result = WorldCreateVehicle(model, Position, Heading)
        End If
        model.MarkAsNoLongerNeeded()
        Return Result
    End Function

    Public Function GetTornadoCustomRoof(veh As Vehicle) As Integer
        Return Native.Function.Call(Of Integer)(DirectCast(&H60190048C0764A26UL, Hash), veh.Handle)
    End Function

    Public Sub SetTornadoCustomRoof(veh As Vehicle, liv As Integer)
        Native.Function.Call(DirectCast(&HA6D3A8750DC73270UL, Hash), veh.Handle, liv)
    End Sub

    Public Sub SetIntoVehicle(ped As Ped, vehicle As Vehicle, seat As VehicleSeat)
        Native.Function.Call(Hash.SET_PED_INTO_VEHICLE, ped, vehicle.Handle, seat)
    End Sub
End Module
