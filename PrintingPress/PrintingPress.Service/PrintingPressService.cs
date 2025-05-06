using System.Text;

namespace PrintingPress.Service;

public class PrintingPressService
{
    private readonly StringBuilder _outputBuilder = new();

    public void Clear() => _outputBuilder.Clear();

    public void AddStringValueAndDelimiter(string value, char delimiter)
    {
        if (_outputBuilder.Length == 0)
        {
            _outputBuilder.Append(value);
        }
        else
        {
            _outputBuilder.Append($"{delimiter}{value}");
        }
    }

    public string GetOutput() => _outputBuilder.ToString();

    public void UpdateValue(string newValue)
    {
        _outputBuilder.Clear();
        _outputBuilder.Append(newValue);
    }
}
