﻿using System.Collections.Generic;

namespace Tests;

public static class TestDataSet
{
    public static IEnumerable<object[]> GenerateBasicDataSet()
    {
        List<object[]> data = new()
        {
            new object[] { "Example.1", "id,name,age,score\n1,Jack,NULL,12\n17,Betty,28,11", "id,name,age,score\n17,Betty,28,11" },
            new object[] { "Example.2", "header,header\nANNUL,ANNULLED\nnull,NILL\nNULL,NULL", "header,header\nANNUL,ANNULLED\nnull,NILL" },
            new object[] { "Example.3", "country,population,area\nUK,67m,242000km2", "country,population,area\nUK,67m,242000km2" }
        };
        return data;
    }
}
