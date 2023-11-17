using UnityEngine;

public class Rotate : MonoBehaviour {
    [SerializeField] private Vector3 _rotateDirection;

    private void Update() => transform.Rotate(_rotateDirection * Time.deltaTime, Space.Self);
}