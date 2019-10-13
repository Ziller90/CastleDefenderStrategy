using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class CustomSceneStarter : Editor
{
#if UNITY_EDITOR

    [MenuItem("Tools/Play From Scene/Set Main Scene", false, 0)]
    public static void SetScene()
    {
        SceneAsset playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorSceneManager.GetActiveScene().path);
        if (playModeStartScene != null)
            EditorSceneManager.playModeStartScene = playModeStartScene;
        else
            Debug.Log("Scene not saved!");
    }

    [MenuItem("Tools/Play From Scene/Unset Main Scene", false, 1)]
    public static void UnsetScene()
    {
        EditorSceneManager.playModeStartScene = null;
    }

    [MenuItem("Tools/Play From Scene/Unset Main Scene", true, 1)]
    public static bool UnsetSceneValidate()
    {
        return EditorSceneManager.playModeStartScene != null;
    }
#endif

}
