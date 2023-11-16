using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {
    [SerializeField] private Text _key;
    [SerializeField] private Text _number;
    
    public void Init(string key, int number) {
        _key.text = key;
        _number.text = number.ToString();
    }
}