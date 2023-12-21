using model.kitchen.Observers;

namespace model.kitchen.Observables;

public interface FoodStuffsObservable
{
    public void addSubscriber(FoodStuffObserver o);
    public void notifyAll();
}