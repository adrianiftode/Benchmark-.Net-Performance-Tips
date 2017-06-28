# Benchmark-.Net-Performance-Tips

Benchmark .Net Performance Tips


## Delegate Create Tests



``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215229 Hz, Resolution=311.0198 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |              Method | Iterations |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
 |-------------------- |----------- |---------:|----------:|----------:|-------:|----------:|
 | OutsideLoopVariable |         10 | 47.91 ns | 0.5051 ns | 0.4725 ns | 0.0101 |      32 B |
 |          AsArgument |         10 | 88.95 ns | 0.7711 ns | 0.6836 ns | 0.1017 |     320 B |
 |  InsideLoopVariable |         10 | 88.57 ns | 0.7067 ns | 0.6265 ns | 0.1017 |     320 B |