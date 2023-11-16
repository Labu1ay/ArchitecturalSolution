using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
    [SerializeField] private Button _backToMenuButton;

    private void Start() {
        _backToMenuButton.onClick.AddListener(() => {
            GameBootstrapper.Curtain.Show();
            GameBootstrapper.Curtain.Hide();
            AllServices.Container.Single<ISceneLoader>().Load(Constants.MenuName);
        });
    }
}