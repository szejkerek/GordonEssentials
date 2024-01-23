using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ProjectFilesEditor : EditorWindow
{
    public static string scriptsFolder = "__Scripts";
    public static List<string> folderNames = new List<string>
    {
        "_Prefabs",
        "Art",
        //"Art/2D",
        //"Art/3D",
        //"Art/Materials",
        //"Art/Materials/BasicColors",
        //"Art/Shaders",
        //"Art/VisualEffects",
        //"Audio",
        //"Editor",
        //"GameData",
        //"Plugins",
        //"Resources",
        //"Scenes",
        //"Tests",
        //"Tests/Playmode",
        //"Tests/Editor"
    };

    [MenuItem("Tools/Project Files Manager")]
    public static void ShowWindow()
    {
        GetWindow<ProjectFilesEditor>("Project Files Manager");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create Default File Structure", EditorStyles.boldLabel);
        DisplayFolderList();

        if (GUILayout.Button("Create Default File Structure"))
        {
            CreateScriptsFolder();
            CreateDefaultFileStructure();
        }
    }

    private void CreateScriptsFolder()
    {
        string scriptsFolderPath = Path.Combine("Assets", scriptsFolder);
        if (!AssetDatabase.IsValidFolder(scriptsFolderPath))
        {
            AssetDatabase.CreateFolder(Path.GetDirectoryName(scriptsFolderPath), Path.GetFileName(scriptsFolderPath));
        }
    }

    private void CreateDefaultFileStructure()
    {
        foreach (string folderName in folderNames)
        {
            CreateFolderStructure("Assets", folderName);
        }

        AssetDatabase.Refresh();
        Debug.Log("Default file structure created.");
    }

    private static void CreateFolderStructure(string basePath, string folderPath)
    {
        string[] folders = folderPath.Split('/');
        string currentPath = basePath;

        foreach (string folder in folders)
        {
            currentPath = Path.Combine(currentPath, folder);

            if (!AssetDatabase.IsValidFolder(currentPath))
            {
                AssetDatabase.CreateFolder(Path.GetDirectoryName(currentPath), Path.GetFileName(currentPath));
            }
        }
    }

    private void DisplayFolderList()
    {
        EditorGUI.indentLevel++;
        int listSize = EditorGUILayout.IntField("Folder Names Count", folderNames.Count);
        listSize = Mathf.Max(1, listSize); // Ensure list size is at least 1

        while (folderNames.Count < listSize)
        {
            folderNames.Add("New Folder");
        }

        while (folderNames.Count > listSize)
        {
            folderNames.RemoveAt(folderNames.Count - 1);
        }

        for (int i = 0; i < folderNames.Count; i++)
        {
            folderNames[i] = EditorGUILayout.TextField($"Folder Name {i + 1}:", folderNames[i]);
        }

        EditorGUI.indentLevel--;
    }
}
