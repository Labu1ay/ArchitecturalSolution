using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    [SerializeField] private Button _startScenarioButton;

    private void Start() {
        _startScenarioButton.onClick.AddListener(() => {
            GameBootstrapper.Curtain.Show();
            GameBootstrapper.Curtain.Hide();

            AllServices services = AllServices.Container;
            
            services.Single<ISceneLoader>().Load(Constants.GameName, () => {
                services.Single<IAsset>().Instantiate(MyPath.ScenarioUI);
            });            
        });
    }
}