using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;

namespace Benchmark
{
    [MemoryDiagnoser, MarkdownExporter]
    public class StatelessServicesInstantiation
    {
        public StatelessServicesInstantiation()
        {
            var controller1 = new Controller1();
        }
        [Benchmark]
        public void InstantiateInConstructor()
        {
            var controller1 = new Controller1();
            controller1.UseCase1();
        }

        [Benchmark]
        public void InstantiateInMethod()
        {
            var controller2 = new Controller2();
            controller2.UseCase1();
        }
    }

    internal class Controller1
    {
        InfrastructureService1 _service1;
        InfrastructureService2 _service2;
        InfrastructureService3 _service3;
        InfrastructureService4 _service4;
        public Controller1()
        {
            _service1 = new InfrastructureService1();
            _service2 = new InfrastructureService2();
            _service3 = new InfrastructureService3();
            _service4 = new InfrastructureService4();
        }

        public void UseCase1() => _service1.DoThings();
        public void UseCase2() => _service2.DoThings();
        public void UseCase3() => _service3.DoThings();
        public void UseCase4() => _service4.DoThings();
    }

    internal class Controller2
    {
        InfrastructureService1 _service1;
        InfrastructureService2 _service2;
        InfrastructureService3 _service3;
        InfrastructureService4 _service4;

        public void UseCase1()
        {
            _service1 = new InfrastructureService1();
            _service1.DoThings();
        }

        public void UseCase2()
        {
            _service2 = new InfrastructureService2();
            _service2.DoThings();
        }
        public void UseCase3()
        {
            _service3 = new InfrastructureService3();
            _service3.DoThings();
        }
        public void UseCase4()
        {
            _service4 = new InfrastructureService4();
            _service4.DoThings();
        }
    }

    internal class InfrastructureService1
    {
        public void DoThings() { }
    }

    internal class InfrastructureService2
    {
        public void DoThings() { }
    }

    internal class InfrastructureService3
    {
        public void DoThings() { }
    }

    internal class InfrastructureService4
    {
        public void DoThings() { }
    }
}
