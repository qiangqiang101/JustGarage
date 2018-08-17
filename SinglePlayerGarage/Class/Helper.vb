Imports GTA
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
End Module
