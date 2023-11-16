using UnityEngine;
using UnityEngine.UI;

public class ScenarioSelection : MonoBehaviour {
    [SerializeField] private Dropdown _dropdown;
    private Scenario[] _scenarios;
    
    private void Start() {
        _scenarios = GameBootstrapper.Configuration.GetScenarios();
        _dropdown.onValueChanged.AddListener(SetScenario);

        for (int i = 0; i <  _scenarios.Length; i++) {
            _dropdown.options.Add(new Dropdown.OptionData(_scenarios[i].NameScenario));
        }

        SetScenario(0);
        _dropdown.value = -1;
    }
    
    private void SetScenario(int index) => GameBootstrapper.CurrentScenario = _scenarios[index];
}