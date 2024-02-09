namespace Hilel_Event_Generic;

public class Client
{
    public void ClientCode()
    {
        // Для примера создается моя ультра коллекция с ивентом
        var collection = new UltraCollection<int>();
        // Добавляется ивент
        collection.OnExpandedEvent += OnResizeEvent.OnResizeEventHandler;

        for (int i = 0; i < 10; i++)
        {
            collection.Add(i + 1);
        }
    }
}