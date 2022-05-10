using System.Collections;

public class AsyncTests
{
    public async Task Exec()
    {
        await new AsyncTests().MakeTeaAsync();
    }

    internal async Task<string> MakeTeaAsync()
    {
        var boilingWater = BoilWaterAsync();

        "take cups out".Dump();

        "put tea in cups".Dump();

        var water = await boilingWater;

        var tea = $"pour {water} in cups".Dump();

        return tea;
    }

    private async Task<string> BoilWaterAsync()
    {
        "Start the kettle".Dump();

        "waiting for the kettle".Dump();
        await Task.Delay(300);

        "kettle finished boiling".Dump();

        return "water";
    }
}
