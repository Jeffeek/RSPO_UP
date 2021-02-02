namespace RSPO_UP_14.First_Task.Interfaces
{
    public interface IProduct
    {
	    string Name { get; }
	    int HashCode { get; }
	    int Quantity { get; }
        string Equipment { get; }
        bool DecreaseQuantity();
    }
}
