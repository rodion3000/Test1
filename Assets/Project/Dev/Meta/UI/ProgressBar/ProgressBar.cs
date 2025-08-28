using UnityEngine;
using UnityEngine.UI;

namespace Project.Dev.Meta.UI.ProgressBar
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;


        public void SetProgress(float progress)
        {
            slider.value = progress;
            Debug.Log(slider.value);
        }

    }
}
