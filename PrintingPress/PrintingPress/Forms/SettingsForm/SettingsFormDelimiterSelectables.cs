namespace PrintingPress.Forms.SettingsForm;

internal class SettingsFormDelimiterSelectables(string displayName, char charValue)
{
    public string DisplayName { get; init; } = displayName;
    public char CharValue { get; init; } = charValue;

    public static List<SettingsFormDelimiterSelectables> GetDefaultSelectables()
    {
        return
        [
            new("Comma (,)", ','),
            new("Semicolon (;)", ';'),
            new("New line (\\n)", '\n'),
            new("Tab (\\t)", '\t'),
            new("Pipe (|)", '|'),
            new("Space", ' ')
        ];
    }
}
