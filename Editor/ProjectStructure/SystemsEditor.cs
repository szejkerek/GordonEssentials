using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SystemsEditor : EditorWindow
{
    public static string prefabName { get; } = "Systems";

    [MenuItem("Tools/Create Systems Prefab")]
    public static void ShowWindow()
    {
        CreateSystemsPrefab();
    }

    public static void CreateSystemsPrefab()
    {
        string prefabPath = Path.Combine("Assets", "Resources", $"{prefabName}.prefab");

        if (!AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)))
        {
            GameObject systemsObject = new GameObject(prefabName);
            SetUpSystemsPrefab(systemsObject);
            PrefabUtility.SaveAsPrefabAsset(systemsObject, prefabPath);
            DestroyImmediate(systemsObject);
            Debug.Log($"{prefabName}.prefab created successfully.");
        }
        else
        {
            Debug.Log($"{prefabName}.prefab already exists.");
        }

        Selection.activeObject = null;
        AssetDatabase.Refresh();
    }

    private static void SetUpSystemsPrefab(GameObject prefab)
    {
        prefab.AddComponent<AudioManager>();
    }
}
