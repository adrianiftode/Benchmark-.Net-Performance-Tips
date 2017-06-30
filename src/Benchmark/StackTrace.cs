using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using System;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class StackTrace
    {
        [Benchmark]
        public void WithStackTraceAccess()
        {
            try
            {
                Catch_AccessStackTrace_Rethrow();
            }
            catch { }
        }

        [Benchmark]
        public void WithoutStackTraceAccess()
        {
            try
            {
                Catch_Rethrow();
            }
            catch { }
        }


        private void Catch_AccessStackTrace_Rethrow()
        {
            try
            {
                Throw();
            }
            catch (Exception ex)
            {
                var stackTrace = ex.StackTrace;
                throw;
            }
        }

        private void Catch_Rethrow()
        {
            try
            {
                Throw();
            }
            catch
            { 
                throw;
            }
        }
        private void Throw()
        {
            throw null;
        }

    }
}
