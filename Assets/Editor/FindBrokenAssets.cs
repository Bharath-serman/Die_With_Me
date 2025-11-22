using UnityEditor;
using UnityEngine;

public class FindBrokenAssets
{
    [MenuItem("Tools/Find Missing Assets in Project")]
    public static void FindBrokenAssetsInProject()
    {
        string[] allPaths = AssetDatabase.GetAllAssetPaths();
        int missingCount = 0;

        foreach (string path in allPaths)
        {
            Object obj = AssetDatabase.LoadAssetAtPath<Object>(path);

            if (obj == null)
            {
                missingCount++;
                Debug.LogError("⚠ Missing asset at path: " + path);
            }
        }

        if (missingCount == 0)
            Debug.Log("✔ No missing assets in project!");
        else
            Debug.Log("❌ Total missing assets: " + missingCount);
    }
}
