using System.Threading.Tasks;
using Project.Dev.Meta.UI.HudController;
using Project.Dev.Meta.UI.MenuController;
using Project.Dev.Meta.UI.ProgressBar;

namespace Project.Dev.Infrastructure.Factories.Interfaces
{
    public interface IUIFactorie
    {
         Task WarmUp();
         void CleanUp();
         Task<MenuController> CreateMenu();
         Task<HudController> CreateHud();
         Task<ProgressBar> CreateProgressBar();
         Task CreateUiRoot();
         Task CreateProgressBarUiRoot();

    }
}
