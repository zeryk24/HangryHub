namespace HangryHub.OderService.UseCases.Order
{
    public class OrderDTO
    {
        public PriceDTO Price { get; set; }

        public OrderDTO(PriceDTO price)
        {
            Price = price;
        }
    }
}
