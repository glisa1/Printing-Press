namespace PrintingPress.Enums;

internal enum ToolStripMenuItemsEnum
{
    Start,
    Stop,
    Preview,
    Settings,
    Exit
}

public static class EnumHelpers
{
    public static string GetEnumAsString<T>(T enumValue) where T : Enum
    {
        return enumValue.ToString();
    }
}
