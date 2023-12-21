// See https://aka.ms/new-console-template for more information

using controller.kitchen;
using model.kitchen;
using model.kitchen.clientOrder;
using model.kitchen.kitchenStaff;

internal class Program
{
    public static void Main(string[] args)
    {
        KitchenModel kitchenModel = new KitchenModel();
        KitchenController kitchenController = new KitchenController(kitchenModel);
        kitchenController.play();


    }
}