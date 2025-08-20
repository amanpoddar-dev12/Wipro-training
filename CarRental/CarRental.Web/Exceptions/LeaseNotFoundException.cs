namespace CarRental.Web.Exceptions
{
    public class LeaseNotFoundException : Exception
    { public LeaseNotFoundException(int id) : base($"Lease with id {id} not found.") { } }
}
