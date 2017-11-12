using ShoppingCart.Data.Size;

namespace ShoppingCart.Services.Voucher
{
    public class VoucherModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public SizeRecord Size { get; set; }
    }
}