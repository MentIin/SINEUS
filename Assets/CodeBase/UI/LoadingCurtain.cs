using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        [SerializeField] private GameObject _containerToHide;
        [SerializeField] private TextMeshProUGUI _loadingText;
        

        public void UpdateLoading(float percent)
        {
            _progressBar.fillAmount = percent / 100;
            _loadingText.text = percent + "";
        }

        public void Show()
        {
            UpdateLoading(0);
            _containerToHide.SetActive(true);
        }

        public void Hide()
        {
            _containerToHide.SetActive(false);
        }
    }
}