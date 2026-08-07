using FluentValidation;

namespace IMS.CoreBusiness.Validations;

public class InventoryTransactionValidator : AbstractValidator<InventoryTransaction>
{
    public InventoryTransactionValidator()
    {
        /* Required Properties */
        
        RuleFor(it => it.InventoryId)
            .NotEmpty().WithMessage("Inventory is required");
        
        RuleFor(it => it.QuantityBefore)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity before transaction must be greater than or equal to 0");
        
        RuleFor(it => it.QuantityAfter)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity after transaction must be greater than or equal to 0");
        
        RuleFor(it => it.TransactionDate)
            .NotEmpty().WithMessage("Transaction date is required");
        
        RuleFor(it => it.DoneBy)
            .NotEmpty().WithMessage("Transaction initiator is required");
        
        /* Transaction Type Rules */
        
        RuleFor(it => it.QuantityAfter)
            .LessThan(it => it.QuantityBefore)
            .When(it => it.Activity == InventoryTransactionType.PurchaseInventory)
            .WithMessage("Quantity after transaction must be less than quantity before transaction");
    }
}