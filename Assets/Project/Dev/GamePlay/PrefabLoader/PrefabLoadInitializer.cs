using UnityEngine;

namespace Project.Dev.GamePlay.PrefabLoader
{
    public class PrefabLoadInitializer : MonoBehaviour
    {
        private const string PrefabVersionKey = "PrefabVersion";

        void Awake()
        {
            int currentVersion = PlayerPrefs.GetInt(PrefabVersionKey, 1);
            int nextVersion = currentVersion == 1 ? 2 : 1;

            PlayerPrefs.SetInt(PrefabVersionKey, nextVersion);
            PlayerPrefs.Save();
            Debug.Log("Current prefab version: " + PlayerPrefs.GetInt("PrefabVersion", 1));
        }
    }
}
