using System.Collections.Generic;

namespace DictionaryHelper
{
   /// <summary>
   /// Returns a default value from a Dictionary
   /// when the searched-for value is not found.
   /// </summary>
   public static partial class CDictionaryHelper
   {
      /// <summary>
      /// Returns a default value from the Dictionary
      /// when the searched-for value is not found.
      /// </summary>
      /// <typeparam name="TValue">TDictionary</typeparam>
      /// <typeparam name="Tk">TKey</typeparam>
      /// <typeparam name="Tv">TValue</typeparam>
      /// <param name="source">Dictionary</param>
      /// <param name="item">item sought</param>
      /// <returns>The value of the type returned by the Dictionary or the default.</returns>
      public static Tv EnsuredValue<T, Tk, Tv>(this T source, Tk item) where T: Dictionary<Tk, Tv>
      {
         return (source.ContainsKey(item) ? source[item] : default(Tv));
      }
   }
}
