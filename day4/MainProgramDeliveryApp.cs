class DeliveryApp
{


    static void Main()
    {
        DeliveryPlatform partner = new ZomatoPartner(); // creating an object of implementation class
        partner.PartnerName = "Zomato";

        partner.TrackOrder();
        partner.DeliveryOrder();

        IpaymentGateway payment = (IpaymentGateway)partner;
        payment.ProcessPayment();

    }
}