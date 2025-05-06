using System.Runtime.InteropServices;

namespace PrintingPress.Forms.HotkeyHandlerForms;

internal class PasteHotkeyHandlerForm : Form
{
    private const byte VK_V = 0x56;

    private const int HOTKEY_ID = 1;
    private const uint MOD_ALT = 0x0001;
    private const uint MOD_CONTROL = 0x0002;
    //private const uint MOD_SHIFT = 0x0004;

    private readonly Action notifyPasteHotkeyPressed;

    public PasteHotkeyHandlerForm(Action notifyOnPastePressed)
    {
        RegisterHotKey(Handle, HOTKEY_ID, MOD_ALT | MOD_CONTROL, VK_V);
        notifyPasteHotkeyPressed = notifyOnPastePressed;
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_HOTKEY = 0x0312;

        if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
        {
            PastePressed();
        }

        base.WndProc(ref m);
    }

    private void PastePressed()
    {
        notifyPasteHotkeyPressed();
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
