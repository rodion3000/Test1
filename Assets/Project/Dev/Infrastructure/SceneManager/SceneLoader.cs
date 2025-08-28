using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;
using Project.Dev.Infrastructure.AssetManager;
using UnityEngine.UIElements;
using ProgressBar = Project.Dev.Meta.UI.ProgressBar.ProgressBar;

namespace Project.Dev.Infrastructure.SceneManagment
{
    public class SceneLoader
    {
        private readonly IAssetProvider _assetProvider;

        public SceneLoader(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async Task<SceneInstance> Load(SceneName sceneName,ProgressBar progressBar, CancellationToken cancellationToken = default)
        {
            var scene = await _assetProvider.LoadScene(sceneName,progressBar,cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            scene.ActivateAsync();
            return scene;
        }

        public void MoveGameObjectToScene(GameObject gameObject, SceneInstance targetScene) =>
            SceneManager.MoveGameObjectToScene(gameObject, targetScene.Scene);

        public void MoveGameObjectToScene(GameObject gameObject, Scene targetScene) =>
            SceneManager.MoveGameObjectToScene(gameObject, targetScene);
    }
}
