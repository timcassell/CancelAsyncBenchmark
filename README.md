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
|   DirectCancelation |         5 |      66.54 ns |     0.189 ns |     0.177 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| ThrowNewCancelation |         5 |  72,025.48 ns |   855.458 ns |   667.885 ns | 1,082.85 |   10.26 | 0.3662 |     - |     - |    1248 B |
|  RethrowCancelation |         5 |  67,682.57 ns |   953.807 ns |   892.191 ns | 1,017.09 |   12.72 | 0.1221 |     - |     - |     568 B |
|                     |           |               |              |              |          |         |        |       |       |           |
|   DirectCancelation |        10 |     122.54 ns |     0.235 ns |     0.196 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| ThrowNewCancelation |        10 | 130,607.64 ns | 1,680.591 ns | 1,572.026 ns | 1,066.80 |   12.90 | 0.4883 |     - |     - |    2288 B |
|  RethrowCancelation |        10 | 122,223.81 ns | 1,557.350 ns | 1,380.550 ns |   997.15 |   12.62 | 0.2441 |     - |     - |     928 B |
|                     |           |               |              |              |          |         |        |       |       |           |
|   DirectCancelation |        20 |     316.12 ns |     0.388 ns |     0.363 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| ThrowNewCancelation |        20 | 251,180.92 ns | 2,165.670 ns | 2,025.769 ns |   794.58 |    6.68 | 0.9766 |     - |     - |    4368 B |
|  RethrowCancelation |        20 | 229,038.13 ns | 1,840.098 ns | 1,721.229 ns |   724.53 |    5.20 | 0.4883 |     - |     - |    1648 B |
```