using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
    public static Language CurrentLanguage;
    public static Scenario CurrentScenario;
    public static LoadingCurtain Curtain { get; private set; }

    public static ProjectConfiguration Configuration { get; private set; }
    [SerializeField] private ProjectConfiguration _projectConfiguration;
    
    private AllServices _services;
    
    private void Start() {
        Configuration = _projectConfiguration;
        CurrentLanguage = TryGetSavedLanguage();
        
        _services = AllServices.Container;
        RegisterService();
        
        Curtain = _services.Single<IAsset>().Instantiate(MyPath.Curtain).GetComponent<LoadingCurtain>();
        Curtain.Hide();
        
        AllServices.Container.Single<ISceneLoader>().Load(Constants.MenuName);
        
        DontDestroyOnLoad(this);
    }
    
    private void RegisterService() {
        _services.RegisterSingle<ISceneLoader>(new SceneLoader(this));
        _services.RegisterSingle<IAsset>(new AssetProvider());
    }

    private Language TryGetSavedLanguage() {
        if (PlayerPrefs.HasKey(Constants.CurrentLanguagePrefs)) {
            return (Language)PlayerPrefs.GetInt(Constants.CurrentLanguagePrefs);
        }
        else {
            return Language.RU;
        }
    }
}