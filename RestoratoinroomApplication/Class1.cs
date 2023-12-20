using ApplicationRestorationroom.Retorationroom.model;

namespace RestoratoinroomApplication;

public class Class1
{
    public static void Main()
    {
        Table table1 = new Table("tble image", true, 12, 10, 1);
        Table table2 = new Table("tble image", true, 12, 3, 2);
        Table table3 = new Table("tble image", true, 12, 5, 3);
        Table table4 = new Table("tble image", true, 12, 1, 4);

        Client client1 = new Client("client", true, 3, 5, "Cool", 30, 3000);

        Head_Waiter headWaiter = new Head_Waiter("image", true, 3, client1);

        headWaiter.AssignTable();


    }
}