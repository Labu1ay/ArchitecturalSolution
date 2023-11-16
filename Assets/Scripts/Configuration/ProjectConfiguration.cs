using System;
using UnityEngine;

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
    public GameObject Enviroment;
    public Data[] Data;
}

[Serializable]
public struct Data {
    public string Key;
    public int Number;
}

// Manuscripta
//     Inscriptor
// Lexiscribe
//     Scriptorama
// Calligraphix
//     Wordweaver
// Linguascript
//     Penscribe
// Typoquill
//     Narratex