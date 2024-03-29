﻿using CommandLine;

namespace ApiIntegrationTest.Cli
{
    internal class RestaurantSearchApplicationOption
    {
        [Option('o', "outcode", Required = true, HelpText = "Provides the outcode to perform the search on.")]
        public string Outcode { get; init; }
    }
}
