using System.Text;
using System.Text.Json.Serialization;

namespace Hilel_Event_Generic.Entities;

public class Customer
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }
    
    [JsonPropertyName("order")]
    public IEnumerable<Product> Order { get; set; }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        foreach (var product in Order)
        {
            builder.Append($"{product.Title} - {product.Price} грн\n");
        }

        return $"\nИмя: {FirstName}\nФамилия: {LastName}\nАдрес: {Address}\nЗаказ на {Order.Sum(o => o.Price)} грн:\n{builder}";
    }
}