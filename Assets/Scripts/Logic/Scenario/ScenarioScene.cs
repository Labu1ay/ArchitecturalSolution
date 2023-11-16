using UnityEngine;
using UnityEngine.UI;

public class ScenarioScene : MonoBehaviour {
    [SerializeField] private Text _scenarioName;
    [SerializeField] private Text _itemCount;
    
    [SerializeField] private RectTransform _parentContent;

    private void Start() {
        Scenario scenario = GameBootstrapper.CurrentScenario;
        IAsset assetProvider = AllServices.Container.Single<IAsset>();
        
        _scenarioName.text = scenario.NameScenario;
        _itemCount.text = scenario.Data.Length.ToString();
            
        for (int i = 0; i < scenario.Data.Length; i++) {
            assetProvider.Instantiate(MyPath.Item, _parentContent).GetComponent<ItemUI>().Init(scenario.Data[i].Key, scenario.Data[i].Number);
        }

        Vector2 sizeDelta = _parentContent.sizeDelta;
        sizeDelta.y *= scenario.Data.Length;
        _parentContent.sizeDelta = sizeDelta;

        //if(scenario.Enviroment != null) assetProvider.Instantiate(scenario.Enviroment);
    }
}