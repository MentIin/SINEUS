using System;
using CodeBase.Infrastructure.StaticData.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements.Dialogs
{
    public class DialogWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private GameObject _continueButtonPrefab;
        [SerializeField] private RectTransform _continueButtonContainer;
        
        private DialogNodeStaticData _nodeStaticData;
        private Action<int> _dialogCallback;
        
        public void Construct(DialogNodeStaticData nodeStaticData, Action<int> dialogCallback)
        {

            _dialogCallback = dialogCallback;
            
            Show(nodeStaticData);
        }

        private void Show(DialogNodeStaticData nodeStaticData)
        {
            _nodeStaticData = nodeStaticData;
            
            if (_nodeStaticData.HaveCallback)
            {
                _dialogCallback?.Invoke(_nodeStaticData.CallbackId);
            }
            _textMeshPro.text = _nodeStaticData.Text;



            if (_nodeStaticData.NextNodes.Length == 0)
            {
                GameObject btn = Instantiate(_continueButtonPrefab, _continueButtonContainer);
                
                btn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    OnContinue(-1);
                });
                btn.GetComponentInChildren<TextMeshProUGUI>().text = "ок";
            }
            for (int i = 0; i < _nodeStaticData.NextNodes.Length; i++)
            {
                GameObject btn = Instantiate(_continueButtonPrefab, _continueButtonContainer);

                Debug.Log(i);
                int b = i;
                btn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    OnContinue(b);
                });
                btn.GetComponentInChildren<TextMeshProUGUI>().text = nodeStaticData.NextNodes[i].ContinueButtonLabel;
            }
            
            
        }

        private void OnContinue(int id)
        {
            if (_nodeStaticData.NextNodes.Length == 0)
            {
                Destroy(this.gameObject);
                return;
            }else if (_nodeStaticData.NextNodes.Length > 0)
            {
                foreach (var btn in _continueButtonContainer.GetComponentsInChildren<Button>())
                {
                    Destroy(btn.gameObject);
                }
                Show(_nodeStaticData.NextNodes[id].NextNode);
            }
            
        }
    }
}