namespace BidCalculatorAPI.Helpers
{
    public static class FeeHelper
    {
        public static decimal Round(decimal value) =>
            Math.Round(value, 2, MidpointRounding.AwayFromZero);
    }
}