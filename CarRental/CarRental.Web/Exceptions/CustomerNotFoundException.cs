namespace CarRental.Web.Exceptions
{
    public class CustomerNotFoundException : Exception
    { public CustomerNotFoundException(int id) : base($"Customer with id {id} not found.") { } }
}
