using UnityEditor;
using System.IO;
using UnityEngine;

namespace Project.Editor
{
    public static class AssetBundleBuilder
    {
        public static void BuildAssetBundles()
        {
            string path = Path.Combine(Application.streamingAssetsPath, "AssetBundles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            BuildPipeline.BuildAssetBundles(
                path,
                BuildAssetBundleOptions.None,
                EditorUserBuildSettings.activeBuildTarget // или укажите конкретную платформу
            );

            Debug.Log("AssetBundles собраны в: " + path);
        }
    }
}
