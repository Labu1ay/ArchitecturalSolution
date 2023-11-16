using UnityEngine;
using UnityEngine.UI;

public class LanguageSelection : MonoBehaviour {
    [SerializeField] private Toggle[] _toggles;

    private void Start() {
        AddListeners();
    }

    private void AddListeners() {
        for (int i = 0; i < GameBootstrapper.Configuration.GetLanguages().Length; i++) {
            if (i == (int)GameBootstrapper.CurrentLanguage - 1)
                _toggles[i].isOn = true;
            
            var index = i;
            
            _toggles[i].onValueChanged.AddListener((isOn) => {
                if (isOn) SetLanguage(GameBootstrapper.Configuration.GetLanguages()[index]);
            });
        }
    }

    public void SetLanguage(Language language) {
        GameBootstrapper.CurrentLanguage = language;
        Messenger.Broadcast(MessengerKey.CHANGED_LANGUAGE);
        
        PlayerPrefs.SetInt(Constants.CurrentLanguagePrefs, (int)language);
    }
}