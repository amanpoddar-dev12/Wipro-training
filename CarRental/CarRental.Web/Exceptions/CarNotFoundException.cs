namespace CarRental.Web.Exceptions
{
    public class CarNotFoundException : Exception
    { public CarNotFoundException(int id) : base($"Car with id {id} not found.") { } }
}
