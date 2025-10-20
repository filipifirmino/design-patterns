namespace BuilderPattern.Model;

public class Order
{
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public List<Itens> OrderItems { get; set; }

    public Order()
    {
        
    }


    public class Builder
    {
        private readonly Order _order = new Order();
        
        public Builder WithCustomerName(string customerName)
        {
            _order.CustomerName = customerName;
            return this;
        }
        public Builder WithCustomerAddress(string customerAddress)
        {
            _order.CustomerAddress = customerAddress;
            return this;
        }

        public Builder WithOrderItems(List<Itens> orderItems)
        {
            _order.OrderItems = orderItems;
            return this;
        }

        public Order Build() => _order;

    }
}