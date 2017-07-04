using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class StringsOperations
    {
        string first = "A".PadLeft(50, 's');
        string second = "B".PadLeft(50, 's');
        public StringsOperations()
        {
            first = "A".PadLeft(50, 's');
            second = "B".PadLeft(50, 's');
        }
        [Benchmark]
        public void Concatenation()
        {
	        var result = first + second;
        }

        [Benchmark]
        public void Format()
        {
	        var result = string.Format("{0}{1}", first, second);

        }
	    [Benchmark]
	    public void Interpolation()
	    {
		    var result = $"{first}{second}";
	    }

	    [Benchmark]
	    public void StringBuilder()
	    {
		    var result = new StringBuilder().Append(first).Append(second).ToString();
	    }
	}
}
