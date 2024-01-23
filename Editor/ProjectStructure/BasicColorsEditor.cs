using UnityEditor;
using UnityEngine;


public class BasicColorsEditor : EditorWindow
{
    [MenuItem("Custom/Create Materials")]
    static void CreateMaterials()
    {
        string folderPath = "Assets/Materials/BasicColo";

        // Create the folder if it doesn't exist
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            AssetDatabase.CreateFolder("Assets", "Materials");
        }

        // Create RedMaterial
        CreateMaterial(folderPath, "RedMaterial", Color.red);

        // Create GreenMaterial
        CreateMaterial(folderPath, "GreenMaterial", Color.green);

        // Create BlueMaterial
        CreateMaterial(folderPath, "BlueMaterial", Color.blue);

        // Add more colors/materials as needed

        // Refresh the AssetDatabase to reflect changes
        AssetDatabase.Refresh();
    }

    static void CreateMaterial(string folderPath, string materialName, Color color)
    {
        // Create a new material
        Material material = new Material(Shader.Find("Standard"));
        material.color = color;

        // Save the material to the specified folder
        string materialPath = $"{folderPath}/{materialName}.mat";
        AssetDatabase.CreateAsset(material, materialPath);
    }
}
