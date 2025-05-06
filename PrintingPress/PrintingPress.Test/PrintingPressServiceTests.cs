using PrintingPress.Service;

namespace PrintingPress.Test
{
    public class PrintingPressServiceTests
    {
        private readonly PrintingPressService _printingPressService = new();

        [Fact]
        public void InitialPrintState_ShouldBeEmpty()
        {
            Assert.Empty(_printingPressService.GetOutput());
        }

        [Fact]
        public void AddOneStringValueAndDelimiter_ShouldAppendValueWithoutDelimiter()
        {
            var value = "Test";
            var delimiter = ',';

            _printingPressService.AddStringValueAndDelimiter(value, delimiter);

            var output = _printingPressService.GetOutput();

            Assert.Equal(value, output);
        }

        [Fact]
        public void AddStringValuesAndDelimiter_ShouldAppendValueWithDelimiter()
        {
            string[] values = { "Test", "Test1", "Test2" };
            var delimiter = ',';
            string expectedResult = "Test,Test1,Test2";

            foreach (var value in values)
            {
                _printingPressService.AddStringValueAndDelimiter(value, delimiter);
            }

            var output = _printingPressService.GetOutput();

            Assert.Equal(expectedResult, output);
        }

        [Fact]
        public void AddStringValuesAndDelimiter_ThenClearOutput_OutputShouldBeEmpty()
        {
            string[] values = ["Test", "Test1", "Test2"];
            var delimiter = ',';

            foreach (var value in values)
            {
                _printingPressService.AddStringValueAndDelimiter(value, delimiter);
            }

            _printingPressService.Clear();
            var output = _printingPressService.GetOutput();

            Assert.Equal(string.Empty, output);
        }

        [Fact]
        public void UpdatePressValue_ShouldOutputNewValue()
        {
            string newValue = "NewTest,NewTest1,NewTest2";
            string[] values = ["Test", "Test1", "Test2"];
            var delimiter = ',';

            foreach (var value in values)
            {
                _printingPressService.AddStringValueAndDelimiter(value, delimiter);
            }

            _printingPressService.UpdateValue(newValue);
            var output = _printingPressService.GetOutput();

            Assert.Equal(newValue, output);
        }
    }
}
