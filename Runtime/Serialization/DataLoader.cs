using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GordonEssentials.Serialization
{

    public static class DataLoader<T> where T : Object
    {
        public static List<T> Load(AssetLabelReference label)
        {
            List<T> result = new List<T>();
            var loadOperation = Addressables.LoadAssetsAsync<T>(label, result.Add).WaitForCompletion();

            if (result.Count == 0)
            {
                Debug.LogError($"Did not load list for {label.labelString} path");
                return null;
            }

            return result;
        }
    }
}