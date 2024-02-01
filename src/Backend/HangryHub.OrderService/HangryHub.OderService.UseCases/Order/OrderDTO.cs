namespace HangryHub.OderService.UseCases.Order
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public PriceDTO Price { get; set; }
        public AcceptDTO Accepted { get; set; }

        public OrderDTO(Guid id, PriceDTO price, AcceptDTO accepted)
        {
            Id = id;
            Price = price;
            Accepted = accepted;
        }
    }
}
