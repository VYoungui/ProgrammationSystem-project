using System.Threading;
using System;
using System.Collections.Generic;

namespace ApplicationRestorationroom.Retorationroom.model
{

    public class Table : Sprite
    {
    private int numberPlace;
    private int tableNumber;
    private List<IObserver<Table>> observers;

    public Table(string spriteImg, bool state, int size, int numberPlace, int tableNumber) : base(spriteImg, state,
        size)
    {
        this.numberPlace = numberPlace;
        this.tableNumber = tableNumber;
        observers = new List<IObserver<Table>>();

    }

    public int PlaceNumber
    {
        get => numberPlace;
        set => numberPlace = value;
    }

    public int Number
    {
        get => tableNumber;
        set => tableNumber = value;
    }

    public bool Assign()
    {
        if(numberPlace == 0)
        {
            State = true;
        }
        return State;

        this.Notify(State);
    }



    public IDisposable Subscribe(IObserver<Table> observer)
    {
        observers.Add(observer);
        return null;
    }
    

    public void Notify(bool state)
    {
        foreach (var observer in observers)
        {
            observer.OnNext(this);
        }
    }


    }
}