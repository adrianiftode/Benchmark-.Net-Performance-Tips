using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using System;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class ParseGuid
    {
        private Guid guid;
        public ParseGuid()
        {
            guid = Guid.NewGuid();
        }
        [Benchmark]
        public void FromGuidToString() => guid.ToString();
        [Benchmark]
        public void FromStringToGuid() => new Guid("F7F3F3CF-02E3-4DD0-8156-39C01711F2E3");
    }
}
