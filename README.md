This is a test benchmark to compare the difference between existing async cancelation behavior vs a theoretical direct cancelation method.



```
BenchmarkDotNet=v0.12.1, OS=Windows 7 SP1 (6.1.7601.0)
AMD Phenom(tm) II X6 1055T Processor, 1 CPU, 6 logical and 6 physical cores
Frequency=2746650 Hz, Resolution=364.0799 ns, Timer=TSC
.NET Core SDK=5.0.103
  [Host]     : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  Job-BPSQHN : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Runtime=.NET Core 5.0  Toolchain=netcoreapp50

|              Method | Recursion |          Mean |        Error |       StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |---------- |--------------:|-------------:|-------------:|---------:|--------:|-------:|------:|------:|----------:|
|   DirectCancelation |         5 |      66.53 ns |     0.193 ns |     0.161 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| ThrowNewCancelation |         5 |  70,834.43 ns |   451.118 ns |   399.905 ns | 1,065.02 |    6.72 | 0.3662 |     - |     - |    1248 B |
|  RethrowCancelation |         5 |  66,003.14 ns |   613.233 ns |   543.615 ns |   992.29 |    8.66 | 0.1221 |     - |     - |     568 B |
|                     |           |               |              |              |          |         |        |       |       |           |
|   DirectCancelation |        10 |     122.94 ns |     0.063 ns |     0.053 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| ThrowNewCancelation |        10 | 128,770.42 ns | 1,330.938 ns | 1,244.960 ns | 1,046.39 |   10.72 | 0.4883 |     - |     - |    2288 B |
|  RethrowCancelation |        10 | 119,599.25 ns |   695.557 ns |   616.593 ns |   972.49 |    5.02 | 0.2441 |     - |     - |     928 B |
|                     |           |               |              |              |          |         |        |       |       |           |
|   DirectCancelation |        20 |     320.03 ns |     0.403 ns |     0.377 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| ThrowNewCancelation |        20 | 249,736.53 ns | 2,580.620 ns | 2,413.913 ns |   780.35 |    7.51 | 0.9766 |     - |     - |    4368 B |
|  RethrowCancelation |        20 | 227,962.82 ns | 2,017.599 ns | 1,887.263 ns |   712.32 |    5.93 | 0.4883 |     - |     - |    1648 B |
```