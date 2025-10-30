namespace BidCalculatorAPI.Models
{
    public class FeeBreakdown
    {
        public decimal BuyerFee { get; set; }
        public decimal SpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; }
        public decimal Total { get; set; }
    }
}