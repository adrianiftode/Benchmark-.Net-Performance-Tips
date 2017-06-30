# Benchmark .Net Performance Tips

Test a series of recommendations about using .Net on matters related to performance.

## DelegateConstruction



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

## ThrowExceptions
 
 ``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215228 Hz, Resolution=311.0199 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |  Method |            Mean |       Error |      StdDev |  Gen 0 | Allocated |
 |-------- |----------------:|------------:|------------:|-------:|----------:|
 |  Catch0 |       0.0301 ns |   0.0097 ns |   0.0086 ns |      - |       0 B |
 |  Catch1 |  28,071.5707 ns | 172.9626 ns | 161.7893 ns | 0.0916 |     300 B |
 |  Catch2 |  36,996.0008 ns | 312.6082 ns | 292.4139 ns | 0.1221 |     408 B |
 |  Catch3 |  46,083.3359 ns | 322.4509 ns | 301.6208 ns | 0.1221 |     408 B |
 |  Catch4 |  54,385.5435 ns | 278.3401 ns | 260.3595 ns | 0.1221 |     408 B |
 |  Catch5 |  63,614.6189 ns | 127.2318 ns |  91.9969 ns | 0.1221 |     612 B |
 |  Catch6 |  72,141.7621 ns | 404.2889 ns | 378.1721 ns | 0.1221 |     612 B |
 |  Catch7 |  79,969.1452 ns | 466.6514 ns | 436.5060 ns | 0.1221 |     612 B |
 |  Catch8 |  90,166.3367 ns | 547.4280 ns | 512.0645 ns | 0.1221 |     612 B |
 |  Catch9 |  99,040.9038 ns | 685.2426 ns | 640.9763 ns | 0.1221 |     612 B |
 | Catch10 | 107,170.1923 ns | 726.2933 ns | 679.3751 ns | 0.1221 |     612 B |

## AccessStackTrace

``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215228 Hz, Resolution=311.0199 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |                  Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
 |------------------------ |---------:|----------:|----------:|-------:|----------:|
 |    WithStackTraceAccess | 50.57 us | 0.3511 us | 0.3284 us | 0.6104 |    1977 B |
 | WithoutStackTraceAccess | 27.93 us | 0.0823 us | 0.0643 us | 0.0916 |     300 B |

## Dynamic

 ``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215228 Hz, Resolution=311.0199 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |                Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
 |---------------------- |-----------:|----------:|----------:|-------:|----------:|
 |          UsingDynamic | 17.9361 ns | 0.0999 ns | 0.0934 ns | 0.0114 |      36 B |
 | CompileTimeAssignment |  0.0182 ns | 0.0062 ns | 0.0058 ns |      - |       0 B |


## ParseGuid

``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215228 Hz, Resolution=311.0199 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |           Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
 |----------------- |----------:|----------:|----------:|-------:|----------:|
 | FromGuidToString |  81.96 ns | 0.3147 ns | 0.2790 ns | 0.0279 |      88 B |
 | FromStringToGuid | 498.20 ns | 2.3758 ns | 2.2223 ns |      - |       0 B |

## StringsComparisons

``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4590 CPU 3.30GHz (Haswell), ProcessorCount=4
Frequency=3215228 Hz, Resolution=311.0199 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


```
 |                                Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
 |-------------------------------------- |-----------:|----------:|----------:|-------:|----------:|
 |               StringComparisonOrdinal |   2.649 ns | 0.0220 ns | 0.0206 ns |      - |       0 B |
 |     StringComparisonOrdinalIgnoreCase |  10.447 ns | 0.0361 ns | 0.0320 ns |      - |       0 B |
 | StringComparisonOrdinalCurrentCulture |  87.079 ns | 0.3474 ns | 0.3249 ns |      - |       0 B |
 |               StringComparisonToLower | 212.555 ns | 0.8068 ns | 0.7546 ns | 0.0226 |      72 B |
 |             StringComparisonToToUpper | 213.768 ns | 0.6787 ns | 0.6016 ns | 0.0226 |      72 B |
 |                        EqualsOperator |   4.549 ns | 0.0226 ns | 0.0212 ns |      - |       0 B |


 Benchmarked with [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)