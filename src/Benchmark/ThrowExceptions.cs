using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class ThrowExceptions
    {

        [Benchmark] public void Catch0() { try {  } catch { } }
        [Benchmark] public void Catch1() { try { Method1(); } catch { } }
        [Benchmark] public void Catch2() { try { Method2(); } catch { } }
        [Benchmark] public void Catch3() { try { Method3(); } catch { } }
        [Benchmark] public void Catch4() { try { Method4(); } catch { } }
        [Benchmark] public void Catch5() { try { Method5(); } catch { } }
        [Benchmark] public void Catch6() { try { Method6(); } catch { } }
        [Benchmark] public void Catch7() { try { Method7(); } catch { } }
        [Benchmark] public void Catch8() { try { Method8(); } catch { } }
        [Benchmark] public void Catch9() { try { Method9(); } catch { } }
        [Benchmark] public void Catch10() { try { Method10(); } catch { } }

        private void Method10()
        {
            try
            {
                Method9();
            }
            catch
            {
                throw;
            }
        }

        private void Method9()
        {
            try
            {
                Method8();
            }
            catch
            {
                throw;
            }
        }

        private void Method8()
        {
            try
            {
                Method7();
            }
            catch
            {
                throw;
            }
        }
        private void Method7()
        {
            try
            {
                Method6();
            }
            catch
            {
                throw;
            }
        }
        private void Method6()
        {
            try
            {
                Method5();
            }
            catch
            {
                throw;
            }
        }
        private void Method5()
        {
            try
            {
                Method4();
            }
            catch
            {
                throw;
            }
        }
        private void Method4()
        {
            try
            {
                Method3();
            }
            catch
            {
                throw;
            }
        }
        private void Method3()
        {
            try
            {
                Method2();
            }
            catch
            {
                throw;
            }
        }
        private void Method2()
        {
            try
            {
                Method1();
            }
            catch
            {
                throw;
            }
        }
        private void Method1()
        {
            try
            {
                throw null;
            }
            catch
            {
                throw;
            }
        }

    }
}
