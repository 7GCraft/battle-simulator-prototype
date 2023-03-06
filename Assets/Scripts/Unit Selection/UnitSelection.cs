using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour, IUnitSelection
{
    public List<GameObject> units = new List<GameObject>();
    public List<GameObject> selectedUnits = new List<GameObject>();

    private static UnitSelection _instance;
    public static UnitSelection Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject selectedUnit)
    {
        throw new System.NotImplementedException();
    }

    public void ShiftClickSelect(GameObject selectedUnit)
    {
        throw new System.NotImplementedException();
    }

    public void DragSelect(GameObject selectedUnit)
    {
        throw new System.NotImplementedException();
    }

    public void DeselectAll()
    {
        throw new System.NotImplementedException();
    }

    public void Deselect(GameObject deselectedUnit)
    {
        throw new System.NotImplementedException();
    }
}
