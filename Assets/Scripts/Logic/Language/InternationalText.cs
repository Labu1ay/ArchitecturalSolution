using UnityEngine;
using UnityEngine.UI;

public class InternationalText : MonoBehaviour {
    [SerializeField] private string _ru;
    [SerializeField] private string _kz;
    [SerializeField] private string _en;

    private Text _thisText;
    private void Start() {
        _thisText = GetComponent<Text>();
        SetLanguage();
        Messenger.AddListener(MessengerKey.CHANGED_LANGUAGE, SetLanguage);
    }

    private void OnDestroy() {
        Messenger.RemoveListener(MessengerKey.CHANGED_LANGUAGE, SetLanguage);
    }

    private void SetLanguage() {
        if (GameBootstrapper.CurrentLanguage == Language.RU) {
            _thisText.text = _ru;
        }else if (GameBootstrapper.CurrentLanguage == Language.KZ) {
            _thisText.text = _kz;
        }else if (GameBootstrapper.CurrentLanguage == Language.EN) {
            _thisText.text = _en;
        }
        else {
            _thisText.text = _ru;
        }
    }
    
}