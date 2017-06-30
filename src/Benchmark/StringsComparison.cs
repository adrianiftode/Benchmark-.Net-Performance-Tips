using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using System;
using System.Linq;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class StringsComparisons
    {
        private string source;
        private string destination;
        public StringsComparisons()
        {
            source = GenerateRandomString(10);
            destination = GenerateRandomString(10);
        }
        [Benchmark]
        public void StringComparisonOrdinal() => String.Compare(source, destination, StringComparison.Ordinal);
        [Benchmark]
        public void StringComparisonOrdinalIgnoreCase() => String.Compare(source, destination, StringComparison.OrdinalIgnoreCase);
        [Benchmark]
        public void StringComparisonOrdinalCurrentCulture() => String.Compare(source, destination, StringComparison.CurrentCulture);
        [Benchmark]
        public bool StringComparisonToLower() => source.ToLower() == destination.ToLower();
        [Benchmark]
        public bool StringComparisonToToUpper() => source.ToUpper() == destination.ToUpper();
        [Benchmark]
        public bool EqualsOperator() => source == destination;


        private static Random random = new Random();
        private static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijsklmmnoprqrstuwzyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
