using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class SceneConstantsEditor : EditorWindow
{
    private const string defaultClassName = "SceneConstants";
    private static string className = defaultClassName;

    [MenuItem("Tools/Create Scene Constants")]
    public static void ShowWindow()
    {
        GetWindow<SceneConstantsEditor>("Scene Constants");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create Scene Constants", EditorStyles.boldLabel);
        className = EditorGUILayout.TextField("Class Name:", className);

        if (GUILayout.Button("Create/Update Scene Constants file"))
        {
            CreateSceneConstantsClass();
        }
    }

    public static void CreateSceneConstantsClass()
    {
        string currentPath = Path.Combine("Assets", ProjectFilesEditor.scriptsFolder);
        if (!AssetDatabase.IsValidFolder(currentPath))
        {
            AssetDatabase.CreateFolder(Path.GetDirectoryName(currentPath), Path.GetFileName(currentPath));
        }

        currentPath = Path.Combine("Assets", ProjectFilesEditor.scriptsUtilityFolder);
        if (!AssetDatabase.IsValidFolder(currentPath))
        {
            AssetDatabase.CreateFolder(Path.GetDirectoryName(currentPath), Path.GetFileName(currentPath));
        }


        string classContent = GenerateClassContent();
        string filePath = Path.Combine(currentPath, $"{className}.cs");

        try
        {
            File.WriteAllText(filePath, classContent);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to write file: {ex.Message}");
            return;
        }

        AssetDatabase.Refresh();
        Debug.Log($"Successfully created {className}");
    }

    public static string GenerateClassContent()
    {
        string content = $"public static class {className}\n";
        content += "{\n";

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            int sceneIndex = i;

            content += $"    public const int {sceneName} = {sceneIndex};\n";
        }

        content += "}\n";

        return content;
    }
}
