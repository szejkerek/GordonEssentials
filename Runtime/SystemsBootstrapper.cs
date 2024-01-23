using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class SystemBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {  
        const string assetTag = "Systems";

        try
        {
            Object.DontDestroyOnLoad(Addressables.InstantiateAsync(assetTag).WaitForCompletion());
        }
        catch (System.Exception e)
        {
            Debug.Log($"Key '{assetTag}' not found in Addressable Assets. {e.Message}");
        }
    }

}
