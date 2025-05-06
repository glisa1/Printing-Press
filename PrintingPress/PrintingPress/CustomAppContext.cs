using PrintingPress.Enums;
using PrintingPress.Forms.HotkeyHandlerForms;
using PrintingPress.Forms.PreviewForm;
using PrintingPress.Service;
using System.Reflection;
using WK.Libraries.SharpClipboardNS;

namespace PrintingPress;


internal class CustomAppContext : ApplicationContext
{
    private const string IconResourceName = "PrintingPress.Resources.press.ico";
    private readonly PrintingPressService printingPressService = new();
    private readonly SharpClipboard clipboardMonitor = new();

    private readonly NotifyIcon trayIcon;
    SettingsForm.SettingsForm? settingsForm;
    private PasteHotkeyHandlerForm pasteHotkeyHandlerForm;
    private readonly CopyHotkeyHandlerForm copyHotkeyHandlerForm;

    public char SelectedDelimiter { get; private set; } = ',';

    public CustomAppContext()
    {
        var toolstripMenuItems = new ToolStripMenuItem[]
        {
            new(GetEnumAsString(ToolStripMenuItemsEnum.Start), null, StartMonitoring, GetEnumAsString(ToolStripMenuItemsEnum.Start)),
            new(GetEnumAsString(ToolStripMenuItemsEnum.Stop), null, StopMonitoring, GetEnumAsString(ToolStripMenuItemsEnum.Stop)),
            new(GetEnumAsString(ToolStripMenuItemsEnum.Preview), null, ShowPreviewForm, GetEnumAsString(ToolStripMenuItemsEnum.Preview)),
            new(GetEnumAsString(ToolStripMenuItemsEnum.Settings), null, OpenSettings, GetEnumAsString(ToolStripMenuItemsEnum.Settings)),
            new(GetEnumAsString(ToolStripMenuItemsEnum.Exit), null, Exit, GetEnumAsString(ToolStripMenuItemsEnum.Exit))
        };

        trayIcon = new NotifyIcon()
        {
            Icon = LoadTrayIcon(),
            ContextMenuStrip = new ContextMenuStrip()
            {
                Text = "Printing Press",
            },
            Visible = true,
            Text = "Printing Press",
            BalloonTipTitle = "Printing Press"
        };
        trayIcon.ContextMenuStrip!.Items.AddRange(toolstripMenuItems);
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Stop)]!.Enabled = false;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Preview)]!.Enabled = false;

        clipboardMonitor.MonitorClipboard = false;
        clipboardMonitor.ClipboardChanged += OnClipboardUpdate;

        copyHotkeyHandlerForm = new(new Action(() =>
        {
            if (!clipboardMonitor.MonitorClipboard)
            {
                NotifyPrintingPressStarted();
                StartMonitoring();
            }
        }));
    }

    private void Paste()
    {
        StopMonitoring();

        var textToPaste = printingPressService.GetOutput();

        if (string.IsNullOrEmpty(textToPaste))
        {
            return;
        }

        Clipboard.SetText(textToPaste);
        printingPressService.Clear();

        NotifyPrintingPressCompleted();
    }

    private void OnClipboardUpdate(object sender, SharpClipboard.ClipboardChangedEventArgs e)
    {
        if (e.ContentType == SharpClipboard.ContentTypes.Text)
        {
            string copiedText = e.Content.ToString();
            printingPressService.AddStringValueAndDelimiter(copiedText, SelectedDelimiter);
        }
    }

    private void Exit(object sender, EventArgs e)
    {
        pasteHotkeyHandlerForm?.Close();
        clipboardMonitor.Dispose();
        trayIcon!.Visible = false;

        Application.Exit();
    }

    private void OpenSettings(object sender, EventArgs e)
    {
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Start)]!.Enabled = false;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Settings)]!.Enabled = false;
        settingsForm = new();
        settingsForm.FormClosing += (sender, e) => SettingsFormOnClose(sender, e);
        settingsForm.Show();
    }

    private void StartMonitoring(object sender, EventArgs e)
    {
        StartMonitoring();
    }

    private void StartMonitoring()
    {
        pasteHotkeyHandlerForm = new(Paste);
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Start)]!.Enabled = false;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Settings)]!.Enabled = false;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Stop)]!.Enabled = true;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Preview)]!.Enabled = true;
        clipboardMonitor.MonitorClipboard = true;
    }

    private void StopMonitoring(object sender, EventArgs e)
    {
        StopMonitoring();
    }

    private void StopMonitoring()
    {
        pasteHotkeyHandlerForm.Close();
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Start)]!.Enabled = true;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Settings)]!.Enabled = true;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Stop)]!.Enabled = false;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Preview)]!.Enabled = false;
        clipboardMonitor.MonitorClipboard = false;
    }

    private void ShowPreviewForm(object sender, EventArgs e)
    {
        var previewForm = new PreviewForm(printingPressService.GetOutput(), PreviewFormOnClose);
        previewForm.Show();
    }

    private void SettingsFormOnClose(object sender, EventArgs e)
    {
        SelectedDelimiter = settingsForm.SelectedDelimiter;
        settingsForm.Dispose();
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Start)]!.Enabled = true;
        trayIcon.ContextMenuStrip!.Items[GetEnumAsString(ToolStripMenuItemsEnum.Settings)]!.Enabled = true;
    }

    private void PreviewFormOnClose(string text)
    {
        printingPressService.UpdateValue(text);
    }

    private void NotifyPrintingPressCompleted()
    {
        trayIcon.ShowBalloonTip(100, "Printing Press", "Text pasted to clipboard", ToolTipIcon.Info);
    }

    private void NotifyPrintingPressStarted()
    {
        trayIcon.ShowBalloonTip(100, "Printing Press", "Started monitoring copy actions.", ToolTipIcon.Info);
    }

    private static Icon LoadTrayIcon()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream? stream = assembly.GetManifestResourceStream(IconResourceName);
        if (stream != null)
        {
            return new(stream);
        }

        throw new Exception($"Resource '{IconResourceName}' not found.");
    }

    private static string GetEnumAsString<T>(T enumValue) where T : Enum
    {
        return EnumHelpers.GetEnumAsString(enumValue);
    }
}
