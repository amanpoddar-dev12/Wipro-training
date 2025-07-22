public abstract class DeliveryPlatform

{
    


    public string PartnerName { get; set; }

    //Non abstract Method
    public void TrackOrder()
    {
        Console.WriteLine("Order is being tracked : " + PartnerName);
    }
   //Abstracted in nature where implementation is defined by partner
    public abstract void DeliveryOrder();

}