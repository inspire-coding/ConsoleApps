``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1889 (21H2)
Intel Core i5-8500 CPU 3.00GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK=6.0.303
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|                       Method |     Mean |   Error |  StdDev | Rank |   Gen 0 |  Gen 1 | Allocated |
|----------------------------- |---------:|--------:|--------:|-----:|--------:|-------:|----------:|
|       GetSecondHighestNumber | 255.0 μs | 0.68 μs | 0.56 μs |    2 | 13.6719 | 1.4648 |     64 KB |
| GetSecondHighestNumberByLinq | 197.7 μs | 0.87 μs | 0.81 μs |    1 | 13.9160 | 1.7090 |     64 KB |
