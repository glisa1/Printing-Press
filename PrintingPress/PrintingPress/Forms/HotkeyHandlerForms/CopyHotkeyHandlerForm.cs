using System.Runtime.InteropServices;

namespace PrintingPress.Forms.HotkeyHandlerForms;

internal class CopyHotkeyHandlerForm : Form
{
    private const byte VK_C = 0x43;

    private const int HOTKEY_ID = 1;
    private const uint MOD_ALT = 0x0001;
    private const uint MOD_CONTROL = 0x0002;
    //private const uint MOD_SHIFT = 0x0004;

    private readonly Action notifyCopyHotkeyPressed;

    public CopyHotkeyHandlerForm(Action notifyOnCopyPressed)
    {
        RegisterHotKey(Handle, HOTKEY_ID, MOD_ALT | MOD_CONTROL, VK_C);
        notifyCopyHotkeyPressed = notifyOnCopyPressed;
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_HOTKEY = 0x0312;

        if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
        {
            CopyPressed();
        }

        base.WndProc(ref m);
    }

    private void CopyPressed()
    {
        notifyCopyHotkeyPressed();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        UnregisterHotKey(Handle, HOTKEY_ID);
        base.OnFormClosing(e);
    }

    #region externals

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(nint hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(nint hWnd, int id);

    #endregion
}
