using System.Text.Json;

namespace Hilel_Event_Generic;

public static class GetDataFromJson
{
    public static IEnumerable<T> Execute<T>(string jsonPath)
    {
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);

            IEnumerable<T> data = JsonSerializer.Deserialize<IEnumerable<T>>(json) ?? throw new NullReferenceException($"{jsonPath} is null.");

            return data;
        }

        throw new FileNotFoundException($"{jsonPath} not found.");
    }

    public static async Task<IEnumerable<T>> Execute<T>(string jsonPath, int count)
    {
        if (!File.Exists(jsonPath))
        {
            throw new FileNotFoundException($"{jsonPath} not found.");
        }

        List<T> data = new List<T>();
        var currentCount = 0;
        
        try
        {
            using FileStream fileStream = new FileStream(jsonPath, FileMode.Open);
            var dataStream = JsonSerializer.DeserializeAsyncEnumerable<T>(fileStream);
            await foreach (var item in dataStream)
            {
                if (item is not null)
                {
                    data.Add(item);
                    currentCount++;
                }

                if (currentCount == count)
                {
                    break;
                }
            }

            return data;
        }
        catch (IOException e)
        {
            Console.WriteLine($"File {jsonPath} cannot be open.\nMessage: {e.Message}");
            throw;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"File {jsonPath} cannot be deserialized.\nMessage: {e.Message}");
            throw;
        }
    }
}