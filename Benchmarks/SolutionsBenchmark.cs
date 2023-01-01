using AXICodility;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SolutionsBenchmark
{
    [ParamsSource(nameof(ValuesForInput))]
    public string Input { get; set; } = default!;

    public static List<string> ValuesForInput() => new()
    {
        "id,name,age,score\n1,Jack,NULL,12\n17,Betty,28,11",
        "header,header\nANNUL,ANNULLED\nnull,NILL\nNULL,NULL",
        "country,population,area\nUK,67m,242000km2"
    };

    [Benchmark]
    public void MainSolution() => Solution.solution(Input);

    [Benchmark]
    public void SimpleSolution() => Solution.simple_solution(Input);
}
