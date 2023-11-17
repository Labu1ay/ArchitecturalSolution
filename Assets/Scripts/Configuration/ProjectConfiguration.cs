using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "ProjectConfiguration", menuName = "Configuration", order = 0)]
public class ProjectConfiguration : ScriptableObject {
    [SerializeField] private Language[] _languages;
    [SerializeField] private Scenario[] _scenarios;

    public Language[] GetLanguages() => _languages;
    public Scenario[] GetScenarios() => _scenarios;
    
}

[Serializable]
public class Scenario {
    public string NameScenario;
    public AssetReferenceGameObject Enviroment;
    public Data[] Data;
}

[Serializable]
public struct Data {
    public string Key;
    public int Number;
}