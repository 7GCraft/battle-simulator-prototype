using UnityEngine;

public class Unit : MonoBehaviour
{
    private void Start()
    {
        UnitSelection.Instance.units.Add(gameObject);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        UnitSelection.Instance.units.Remove(gameObject);
    }
}
