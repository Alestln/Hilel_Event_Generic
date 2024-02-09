namespace Hilel_Event_Generic;

// Вынес в отдельнй класс, так как в двух местах используется метод
public static class OnResizeEvent
{
    public static void OnResizeEventHandler(int capacity)
    {
        Console.WriteLine($"Для коллекции было выделено памяти под {capacity} элементов");
    }
}