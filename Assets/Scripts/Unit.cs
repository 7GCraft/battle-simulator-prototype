using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject selectedIndicator;

    private UnitMovement unitMovement;

    private void Awake()
    {
        unitMovement = GetComponent<UnitMovement>();

        Deselect();
    }

    public void Select()
    {
        selectedIndicator.SetActive(true);
    }

    public void Deselect()
    {
        selectedIndicator.SetActive(false);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        unitMovement.SetMovePosition(targetPosition);
    }
}
