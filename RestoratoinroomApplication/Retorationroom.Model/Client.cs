namespace ApplicationRestorationroom.Retorationroom.model;

public class Client : Sprite
{
    private int clientNumber;
    private string type;
    private int time;
    private int money;
    private Table table;

    public Client(string spriteImg, bool state, int size, int clientNumber, string type, int time, int money) : base(spriteImg, state, size)
    {
        this.clientNumber = clientNumber;
        this.type = type;
        this.time = time;
        this.money = money;
        
    }

    public int ClientNumber
    {
        get => clientNumber;
        set => clientNumber = value;
    }

    public string Type
    {
        get => type;
        set => type = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Time
    {
        get => time;
        set => time = value;
    }

    public int Money
    {
        get => money;
        set => money = value;
    }

    public Table Table
    {
        get => table;
        set => table = value ?? throw new ArgumentNullException(nameof(value));
    }




}