using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class DelegateConstruction
    {
        delegate int MathOperation(int a, int b);

        [Params(10)]
        public int Iterations { get; set; }

        [Benchmark]
        public void OutsideLoopVariable()
        {
            MathOperation operation = Add;
            for (int i = 0; i < Iterations; i++)
            {
                DoOperation(operation, 1, 2);
            }
        }

        [Benchmark]
        public void AsArgument()
        {
            for (int i = 0; i < Iterations; i++)
            {
                DoOperation(Add, 1, 2);
            }
        }

        [Benchmark]
        public void InsideLoopVariable()
        {
            for (int i = 0; i < Iterations; i++)
            {
                MathOperation operation = Add;
                DoOperation(Add, 1, 2);
            }
        }
        
        private static int Add(int a, int b) => a + b;
        private static int DoOperation(MathOperation mathOperation, int a, int b) => mathOperation(a, b);
    }
}
