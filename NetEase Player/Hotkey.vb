Public NotInheritable Class Hotkey : Inherits NativeWindow : Implements IDisposable
    Private Declare Function RegisterHotKey Lib "user32" (
          ByVal Hwnd As IntPtr, ByVal ID As Integer,
          ByVal Modifiers As Integer, ByVal Key As Integer) As Integer
    Private Declare Function UnregisterHotKey Lib "user32" (
          ByVal Hwnd As IntPtr, ByVal ID As Integer) As Integer
    Public Event Pressed As EventHandler
    Public Const WinKey As Keys = DirectCast(Keys.Alt << 1, Keys)
    Private _Value As Keys
    Public Sub New(Optional ByVal Value As Keys = Keys.None)
        Me.CreateHandle(New CreateParams)
        TryRegister(Value)
    End Sub
    Public ReadOnly Property Value() As Keys
        Get
            Return _Value
        End Get
    End Property
    Public Function TryRegister(ByVal Key As Keys) As Boolean
        Dim ApiModifier = 0
        If CBool(Key And WinKey) Then ApiModifier += 8
        If CBool(Key And Keys.Shift) Then ApiModifier += 4
        If CBool(Key And Keys.Control) Then ApiModifier += 2
        If CBool(Key And Keys.Alt) Then ApiModifier += 1
        'Für die API-Registrierung die Modifier-Komponente (oberhalb &HFFFF)
        '                                 der Keys-Enumeration wegmaskieren
        Dim unregistered = UnregisterHotKey(Me.Handle, _Value)
        If Key = Keys.None Then Return True
        Debug.WriteLine(unregistered.ToString)
        If RegisterHotKey(Me.Handle, Key, ApiModifier, Key And &HFFFF) = 0 Then Return False
        _Value = Key
        Return True
    End Function
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_HOTKEY As Integer = &H312
        If m.Msg = WM_HOTKEY Then RaiseEvent Pressed(Me, EventArgs.Empty)
        MyBase.WndProc(m)
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        If Me.Handle = IntPtr.Zero Then Return
        If UnregisterHotKey(Me.Handle, _Value) = 0 Then Stop
        Me.ReleaseHandle()
    End Sub
End Class
