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


    [MenuItem("Tools/PassTheLevel", false, 1)]
    public static void Win()
    {
        GameObject.Find("WinManager").GetComponent<WinScript>().MomomentaryWin();
    }
    [MenuItem("Tools/SetPlayerProgress/Level_1", false, 1)]
    public static void Setprogress_1Level()
    {
        PlayerStats.CampaignProgressIndex = 1;
    }
    [MenuItem("Tools/SetPlayerProgress/Level_2", false, 1)]
    public static void Setprogress_2Level()
    {
        PlayerStats.CampaignProgressIndex = 2;
    }
    [MenuItem("Tools/SetPlayerProgress/Level_3", false, 1)]
    public static void Setprogress_3Level()
    {
        PlayerStats.CampaignProgressIndex = 3;
    }
    [MenuItem("Tools/SetPlayerProgress/Level_4", false, 1)]
    public static void Setprogress_4Level()
    {
        PlayerStats.CampaignProgressIndex = 4;
    }
    [MenuItem("Tools/SetPlayerProgress/Level_5", false, 1)]
    public static void Setprogress_5Level()
    {
        PlayerStats.CampaignProgressIndex = 5;
    }
    [MenuItem("Tools/SetPlayerProgress/Level_6", false, 1)]
    public static void Setprogress_6Level()
    {
        PlayerStats.CampaignProgressIndex = 6;
    }
    [MenuItem("Tools/SetPlayerProgress/Level_7", false, 1)]
    public static void Setprogress_7Level()
    {
        PlayerStats.CampaignProgressIndex = 7;
    }
    [MenuItem("Tools/SetPlayerProgress/Level_8", false, 1)]
    public static void Setprogress_8Level()
    {
        PlayerStats.CampaignProgressIndex = 8;
    }

#endif

}
