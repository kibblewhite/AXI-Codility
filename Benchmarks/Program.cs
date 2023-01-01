using BenchmarkDotNet.Running;

namespace Benchmarks;

internal class Program
{
    /// <summary>
    /// dotnet run --project Benchmarks -c Release
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args) => BenchmarkRunner.Run<SolutionsBenchmark>();
}
