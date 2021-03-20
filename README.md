This is a test benchmark to compare the difference between existing async cancelation behavior vs a theoretical direct cancelation method.



BenchmarkDotNet=v0.12.1, OS=Windows 7 SP1 (6.1.7601.0)
AMD Phenom(tm) II X6 1055T Processor, 1 CPU, 6 logical and 6 physical cores
Frequency=2746650 Hz, Resolution=364.0799 ns, Timer=TSC
.NET Core SDK=5.0.103
  [Host]     : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  Job-CISRVJ : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50

|            Method | Recursion |          Mean |        Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |---------- |--------------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|  ThrowCancelation |         5 |  70,043.62 ns |   464.745 ns |   434.722 ns | 947.31 |    5.80 | 0.3662 |     - |     - |    1248 B |
| DirectCancelation |         5 |      73.89 ns |     0.067 ns |     0.056 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                   |           |               |              |              |        |         |        |       |       |           |
|  ThrowCancelation |        10 | 129,229.64 ns | 1,018.271 ns |   952.492 ns | 930.42 |    7.07 | 0.4883 |     - |     - |    2288 B |
| DirectCancelation |        10 |     138.90 ns |     0.311 ns |     0.291 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                   |           |               |              |              |        |         |        |       |       |           |
|  ThrowCancelation |        20 | 245,769.72 ns | 2,475.064 ns | 2,315.176 ns | 733.60 |    6.91 | 1.2207 |     - |     - |    4368 B |
| DirectCancelation |        20 |     335.02 ns |     0.342 ns |     0.320 ns |   1.00 |    0.00 |      - |     - |     - |         - |