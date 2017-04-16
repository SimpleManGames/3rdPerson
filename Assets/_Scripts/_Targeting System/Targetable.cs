using UnityEngine;

public class Targetable : MonoBehaviour
{
    void Start()
    {
        TargetSystemManager.Instance.targetableObjects.Add(gameObject);
    }
}
