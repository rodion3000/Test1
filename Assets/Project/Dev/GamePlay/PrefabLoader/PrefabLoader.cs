using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Dev.GamePlay.PrefabLoader
{
    public class PrefabLoader : MonoBehaviour
    {
        private const string PrefabVersionKey = "PrefabVersion";

        void Start()
        {
            int currentVersion = PlayerPrefs.GetInt(PrefabVersionKey, 1);
            string prefabAddress = currentVersion == 1 ? "PrefabLoader1" : "PrefabLoader2";

            Addressables.LoadAssetAsync<GameObject>(prefabAddress).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    Instantiate(handle.Result);
                }
                else
                {
                    Debug.LogError("Не удалось загрузить префаб");
                }
            };
        }
    }
}
