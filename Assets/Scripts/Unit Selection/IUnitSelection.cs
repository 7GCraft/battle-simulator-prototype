using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitSelection
{
    public void ClickSelect(GameObject selectedUnit);
    public void ShiftClickSelect(GameObject selectedUnit);
    public void DragSelect(GameObject selectedUnit);
    public void DeselectAll();
    public void Deselect(GameObject deselectedUnit);
}
