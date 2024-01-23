using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        string folderPath = Path.Combine("Assets", ProjectFilesEditor.scriptsFolder);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string classContent = GenerateClassContent();
        string filePath = Path.Combine(folderPath, $"{className}.cs");
        File.WriteAllText(filePath, classContent);
        AssetDatabase.Refresh();

        Debug.Log($"{className} class created at: {filePath}");
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
