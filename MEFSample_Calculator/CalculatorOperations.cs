using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MEFSample_Calculator
{
    class CalculatorOperations
    {
        [Export]
        [ExportMetadata("Op", "+")]
        public int Add(int input1, int input2)
        {
            return input1 + input2;
        }

        [Export]
        [ExportMetadata("Op", "-")]
        public int Subtract(int input1, int input2)
        {
            return input1 - input2;
        }

        [Export]
        [ExportMetadata("Op", "*")]
        public int Multiply(int input1, int input2)
        {
            return input1 * input2;
        }

        [Export]
        [ExportMetadata("Op", "/")]
        public int Divide(int input1, int input2)
        {
            return input1 / input2;
        }
    }
}
