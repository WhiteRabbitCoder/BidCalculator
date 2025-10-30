using BidCalculatorAPI.Models;
using BidCalculatorAPI.Services.Interfaces;
using BidCalculatorAPI.Services.FeeCalculators;

namespace BidCalculatorAPI.Services
{
    public class TotalFeeService
    {
        private readonly BuyerFeeCalculator _buyerFee;
        private readonly SpecialFeeCalculator _specialFee;
        private readonly AssociationFeeCalculator _associationFee;
        private readonly StorageFeeCalculator _storageFee;

        public TotalFeeService(
            BuyerFeeCalculator buyerFee,
            SpecialFeeCalculator specialFee,
            AssociationFeeCalculator associationFee,
            StorageFeeCalculator storageFee)
        {
            _buyerFee = buyerFee;
            _specialFee = specialFee;
            _associationFee = associationFee;
            _storageFee = storageFee;
        }

        public FeeBreakdown CalculateBreakdown(Vehicle vehicle)
        {
            var breakdown = new FeeBreakdown
            {
                BuyerFee = _buyerFee.Calculate(vehicle),
                SpecialFee = _specialFee.Calculate(vehicle),
                AssociationFee = _associationFee.Calculate(vehicle),
                StorageFee = _storageFee.Calculate(vehicle),
            };

            breakdown.Total = breakdown.BuyerFee + breakdown.SpecialFee + 
                              breakdown.AssociationFee + breakdown.StorageFee;

            return breakdown;
        }
    }
}