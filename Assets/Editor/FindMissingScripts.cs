using UnityEditor;
using UnityEngine;

public class FindMissingScripts : EditorWindow
{
    [MenuItem("Tools/Find Missing Scripts")]
    public static void FindMissingScriptsInProject()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        int missingCount = 0;

        foreach (GameObject obj in allObjects)
        {
            Component[] components = obj.GetComponents<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    missingCount++;
                    Debug.LogError($"Missing script found on GameObject: {obj.name} (Component index {i})", obj);
                }
            }
        }

        if (missingCount == 0)
            Debug.Log("✔ No missing scripts found!");
        else
            Debug.Log($"⚠ Found {missingCount} objects with missing scripts!");
    }
}
