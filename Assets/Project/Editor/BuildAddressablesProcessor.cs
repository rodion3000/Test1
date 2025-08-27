using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Project.Editor
{
    class BuildAddressablesProcessor
    {
        /// <summary>
        /// Run a clean build before export.
        /// </summary>
        static public void PreExport()
        {
            Debug.Log("BuildAddressablesProcessor.PreExport start");

            // Собираем AssetBundles перед Addressables
            AssetBundleBuilder.BuildAssetBundles();

            AddressableAssetSettings.CleanPlayerContent(
                AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilder);
            AddressableAssetSettings.BuildPlayerContent();
            Debug.Log("BuildAddressablesProcessor.PreExport done");
        }

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            BuildPlayerWindow.RegisterBuildPlayerHandler(BuildPlayerHandler);
        }

        private static void BuildPlayerHandler(BuildPlayerOptions options)
        {
            if (EditorUtility.DisplayDialog("Build with Addressables",
                    "Do you want to build a clean addressables before export?",
                    "Build with Addressables", "Skip"))
            {
                PreExport();
            }

            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
        }
    }
}
