using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MEFSample_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);

            var calculator = container.GetExportedValue<Calculator>();

            while (true)
            {
                Console.Write("Enter calculation: ");
                string input = Console.ReadLine();

                Console.WriteLine("Result: {0}", calculator.Calculate(input));
            }
        }
    }

    [Export]
    public class Calculator
    {
        [ImportMany]
        IEnumerable<Lazy<Func<int, int, int>, Dictionary<string, object>>> computationMethods;

        [Import("CalculationParser")]
        private Func<string, CalculationModel> parseCalculation;
        public int Calculate(string input)
        {
            var calculation = parseCalculation(input);
            var actionToRun = computationMethods.First(c => c.Metadata["Op"].ToString().Equals(calculation.Operation));
            int result = actionToRun.Value(calculation.Input1, calculation.Input2);

            return result;
        }
    }
}
