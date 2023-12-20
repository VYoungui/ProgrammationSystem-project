using System.Collections.Generic;


namespace ApplicationRestorationroom.Retorationroom.model
{
    public class Head_Waiter : Sprite, IObserver<Table> 
    {
        private List<Table> tables;
        private Client client;
        

        public Head_Waiter(string spriteImg, bool state, int size, Client client) : base(spriteImg, state, size)
        {
            tables = new List<Table>();
            this.client = client;
        }

        public List<Table> Table
        {
            get => tables;
            set => tables = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int AssignTable()
        {
            foreach (var table in tables)
            {
                if (table.PlaceNumber <= client.ClientNumber)
                {
                    client.Table.PlaceNumber = client.ClientNumber;
                    return table.Number;
                    Console.Write("La table" + table.Number + "a ete attribuée à" + client.ClientNumber);
                    
                }
               
            }

            return 0;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Table value)
        {
            if (value.State == true)
                tables.Add(value);
            else
            {
                if (tables.Contains(value))
                    tables.Remove(value);
            }

            throw new NotImplementedException();
        }
    }
}