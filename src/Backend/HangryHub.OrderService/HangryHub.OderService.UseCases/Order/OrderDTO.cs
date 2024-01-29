namespace HangryHub.OderService.UseCases.Order
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public PriceDTO Price { get; set; }

        public OrderDTO(Guid id, PriceDTO price)
        {
            Price = price;
            Id = id;
        }
    }
}
