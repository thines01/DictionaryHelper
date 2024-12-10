using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryHelper
{
   public static partial class CDictionaryHelper
   {
      /// <summary>
      /// Creates a dictionary from an IENumerable of TValue using a user-supplied Key.
      /// The first value is chosen if duplicates are encountered.
      /// </summary>
      /// <typeparam name="TKey">User-supplied key</typeparam>
      /// <typeparam name="TValue">Generated value for the dictionary</typeparam>
      /// <param name="lst">Original list of elements</param>
      /// <param name="keySelector">User-supplied key generator method</param>
      /// <param name="dic">Dictionary to be modified with target keys and values</param>
      public static void
         ToSafeDictionary<TKey, TValue>
         (this IEnumerable<TValue> lst, Func<TValue, TKey> keySelector, ref Dictionary<TKey, TValue> dic)
         => dic = ToSafeDictionary(lst, keySelector);

      /// <summary>
      /// Returns a dictionary based on the IEnumerable and key generator provided.
      /// The first value is chosen if duplicates are encountered.
      /// </summary>
      /// <typeparam name="TKey">User-supplied key</typeparam>
      /// <typeparam name="TValue">Generated value for the dictionary</typeparam>
      /// <param name="lst">Original list of elements</param>
      /// <param name="keySelector">User-supplied key generator method</param>
      /// <returns>Dictionary</returns>
      public static Dictionary<TKey, TValue>
         ToSafeDictionary<TKey, TValue>
         (this IEnumerable<TValue> lst, Func<TValue, TKey> keySelector)
         => lst.GroupBy(keySelector).ToDictionary(grp => grp.Key, grp => grp.First());

      /// <summary>
      /// 
      /// </summary>
      /// <typeparam name="TKey"></typeparam>
      /// <typeparam name="TValue"></typeparam>
      /// <param name="lst">A collection of </param>
      /// <returns>Dictionary</returns>
      public static Dictionary<TKey, TValue>
         ToSafeDictionary<TKey, TValue>
         (this IEnumerable<KeyValuePair<TKey, TValue>> lst)
         => lst.ToLookup(k => k.Key, v => v.Value)
            .ToDictionary(k => k.Key, v => v.First());
   }
}