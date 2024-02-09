using Hilel_Event_Generic.Entities;

namespace Hilel_Event_Generic;

public static class LinqExtension
{
    public static UltraCollection<T> ToUltraCollection<T>(this IEnumerable<T> source)
    {
        UltraCollection<T> ultraCollection = new UltraCollection<T>(source);
        
        return ultraCollection;
    }
}