using UnityEngine;
using UnityEngine.UI;

public class ScenarioGame : MonoBehaviour {
    [SerializeField] private Text _scenarioName;
    [SerializeField] private Text _itemCount;
    
    [SerializeField] private RectTransform _parentContent;

    private IAsset _assetProvider;
    private bool _needUnloadResources;

    private void Start() {
        Scenario scenario = GameBootstrapper.CurrentScenario;
        _assetProvider = AllServices.Container.Single<IAsset>();
        
        _scenarioName.text = scenario.NameScenario;
        _itemCount.text = scenario.Data.Length.ToString();
            
        for (int i = 0; i < scenario.Data.Length; i++) {
            _assetProvider.Instantiate(MyPath.Item, _parentContent).GetComponent<ItemUI>().Init(scenario.Data[i].Key, scenario.Data[i].Number);
        }

        Vector2 sizeDelta = _parentContent.sizeDelta;
        sizeDelta.y *= scenario.Data.Length;
        _parentContent.sizeDelta = sizeDelta;

        if (scenario.Enviroment.editorAsset != null) {
            _assetProvider.InstantiateLoadedResources(scenario.Enviroment);
            _needUnloadResources = true;
        }
    }

    private void OnDestroy() {
       if(_needUnloadResources) _assetProvider.UnloadResources();
    }
}