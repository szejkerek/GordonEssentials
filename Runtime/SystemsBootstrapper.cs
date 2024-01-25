using UnityEngine;

public static class SystemBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        try
        {
            Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load(SystemsEditor.prefabName)));
        }
        catch
        {
            Debug.LogWarning("Consider creating Systems asset using 'Tools/Create Systems Prefab' button");
        }
    }

}
