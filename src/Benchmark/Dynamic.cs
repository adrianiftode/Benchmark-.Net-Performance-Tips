using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using System;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class Dynamic
    {
        [Benchmark]
        public void UsingDynamic()
        {
            dynamic a = 2;
            dynamic b = 3;
            dynamic s = a + b;
        }

        [Benchmark]
        public void CompileTimeAssignment()
        {
            int a = 2;
            int b = 3;
            int s = a + b;
        }
    }
}
