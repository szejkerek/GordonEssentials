using UnityEditor;
using UnityEngine;

class ProjectInitialization
{
    [MenuItem("Tools/Initialize Project", priority = 0)]
    static void DoSomething()
    {
        ProjectFilesEditor.CreateDefaultFolderStructure();
        BasicColorsEditor.CreateAllBasicColors();
        SceneConstantsEditor.CreateSceneConstantsClass();
    }
}