using System.Composition;
using System.Text.RegularExpressions;

namespace MEFSample_Calculator
{
    public class HelperMethods
    {
        [Export("CalculationParser")]
        public CalculationModel Parse(string input)
        {
            Regex regex = new Regex(@"(\d+)(.)(\d+)");
            Match match = regex.Match(input);

            CalculationModel calculation = new CalculationModel()
            {
                Input1 = int.Parse(match.Groups[1].Value),
                Input2 = int.Parse(match.Groups[3].Value),
                Operation = match.Groups[2].Value
            };
            return calculation;
        }
    }
}
