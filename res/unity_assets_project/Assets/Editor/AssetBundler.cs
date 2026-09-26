using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Rogue Command\\BepInEx\\plugins", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}