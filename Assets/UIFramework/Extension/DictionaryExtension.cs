using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DictionaryExtension {

    public static TValue TryGet<TKey,TValue>(this Dictionary<TKey,TValue> dic,TKey key){
        TValue value;
        dic.TryGetValue(key,out value);
        return value;
    }
}
