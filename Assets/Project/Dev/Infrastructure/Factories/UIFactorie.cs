using System.Threading.Tasks;
using Project.Dev.Infrastructure.AssetManager;
using Project.Dev.Infrastructure.Factories.Interfaces;
using Project.Dev.Meta.UI.HudController;
using Project.Dev.Meta.UI.MenuController;
using Project.Dev.Meta.UI.ProgressBar;
using UnityEngine;
using Zenject;

namespace Project.Dev.Infrastructure.Factories
{
    public class UIFactorie : IUIFactorie
    {
        private const string MenuPrefabId = "MenuPrefab";
        private const string HUDPrefabId = "HudPrefab";
        private const string RootUiPrefabId = "UIRootPrefab";
        private const string ProgressBarPrefabId = "ProgressBar";
        private const string ProgressBarRootPrefabId = "ProgressBarUiRoot";

        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        private Canvas _uiRoot;
        private Canvas _ProgressBarRoot;

        public UIFactorie(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public async Task WarmUp()
        {
            await _assetProvider.Load<GameObject>(key: ProgressBarRootPrefabId);
            await _assetProvider.Load<GameObject>(key: RootUiPrefabId);
            await _assetProvider.Load<GameObject>(key: HUDPrefabId);
            await _assetProvider.Load<GameObject>(key: MenuPrefabId);
            await _assetProvider.Load<GameObject>(key: ProgressBarPrefabId);
        }

        public void CleanUp()
        {
             _assetProvider.Release(key: MenuPrefabId);
             _assetProvider.Release(key: ProgressBarPrefabId);
             _assetProvider.Release(key: ProgressBarRootPrefabId);
        }

        public async Task CreateUiRoot()
        {
            var prefab = await _assetProvider.Load<GameObject>(key: RootUiPrefabId);
            _uiRoot = Object.Instantiate(prefab).GetComponent<Canvas>();
        }

        public async Task CreateProgressBarUiRoot()
        {
            var prefab = await _assetProvider.Load<GameObject>(key: ProgressBarRootPrefabId);
            _ProgressBarRoot = Object.Instantiate(prefab).GetComponent<Canvas>();
        }

        public async Task<MenuController> CreateMenu()
        {
            var prefab = await _assetProvider.Load<GameObject>(key: MenuPrefabId);
            var menu = Object.Instantiate(prefab, _uiRoot.transform).GetComponent<MenuController>();
            _container.InjectGameObject(menu.gameObject);
            return menu;
        }

        public async Task<HudController> CreateHud()
        {
            var prefab = await _assetProvider.Load<GameObject>(key: HUDPrefabId);
            var hud = Object.Instantiate(prefab, _uiRoot.transform).GetComponent<HudController>();
            _container.Inject(hud);
            return hud;
        }

        public async Task<ProgressBar> CreateProgressBar()
        {
            var prefab = await _assetProvider.Load<GameObject>(key: ProgressBarPrefabId);
            var progressBar = Object.Instantiate(prefab,_ProgressBarRoot.transform).GetComponent<ProgressBar>();
            _container.Inject(progressBar);
            return progressBar;
        }
    }
}
