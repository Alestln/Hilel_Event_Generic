using Hilel_Event_Generic.Entities;

namespace Hilel_Event_Generic;

class Program
{
    static async Task Main(string[] args)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Jsons", "customers.json");

        IEnumerable<Customer> data = Enumerable.Empty<Customer>();
        try
        {
            data = await GetDataFromJson.Execute<Customer>(path, 5);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        // Добавление покупателей к ультра коллекции
        UltraCollection<Customer> collection = new UltraCollection<Customer>();

        collection.OnExpandedEvent += OnResizeEvent.OnResizeEventHandler;
        
        foreach (var customer in data)
        {
            collection.Add(customer);
        }

        collection.OnExpandedEvent -= OnResizeEvent.OnResizeEventHandler;
        
        // Фильтрация и сортировка коллекции
        collection = collection
            .Where(c => c.FirstName.StartsWith("L", StringComparison.OrdinalIgnoreCase))
            .OrderBy(c => c.LastName).ToUltraCollection();
        
        // Вывод отфильтрованых и отсортированных данных
        foreach (var customer in collection)
        {
            Console.WriteLine(customer);
        }
        
        // Далее тот код, про который я задавал вопросы на счет срока хранения объекта
        
        // Другой разработчик создал какой-то свой класс и использует в нем ультра коллекцию с ивентом, который он не убрал
        // При выполнении клиентского кода в консоль выводится два сообщения
        Client client = new Client();
        client.ClientCode();
        
        // Сможет ли Garbage Collector почистить клиента и коллекцию от мусора?
    }
}