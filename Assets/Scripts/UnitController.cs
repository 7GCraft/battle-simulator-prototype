using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private Transform selectionArea;

    private List<Unit> selectedUnits;
    private Vector3 startPosition;

    private void Awake()
    {
        selectedUnits = new List<Unit>();

        selectionArea.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSelection();
        }

        if (Input.GetMouseButton(0))
        {
            AdjustSelectionAreaSize();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
        }

        if (Input.GetMouseButton(1))
        {
            List<Vector3> targetPositions = GetTargetPositions();
            int targetIndex = 0;

            foreach (Unit unit in selectedUnits)
            {
                unit.MoveTo(targetPositions[targetIndex]);
                targetIndex++;
            }
        }
    }

    private void StartSelection()
    {
        selectionArea.gameObject.SetActive(true);

        startPosition = GetMouseWorldPosition();
    }

    private void AdjustSelectionAreaSize()
    {
        Vector3 currentMousePosition = GetMouseWorldPosition();
        Vector3 lowerLeftPoint = new Vector3(
            Mathf.Min(startPosition.x, currentMousePosition.x),
            Mathf.Min(startPosition.y, currentMousePosition.y)
        );
        Vector3 upperRightPoint = new Vector3(
            Mathf.Max(startPosition.x, currentMousePosition.x),
            Mathf.Max(startPosition.y, currentMousePosition.y)
        );

        selectionArea.position = lowerLeftPoint;
        selectionArea.localScale = upperRightPoint - lowerLeftPoint;
    }

    private void SelectUnits()
    {
        selectionArea.gameObject.SetActive(false);

        Collider2D[] colliders = Physics2D.OverlapAreaAll(startPosition, GetMouseWorldPosition());

        foreach (Unit unit in selectedUnits)
        {
            unit.Deselect();
        }

        selectedUnits.Clear();

        foreach (Collider2D collider in colliders)
        {
            Unit unit = collider.GetComponent<Unit>();

            if (unit != null)
            {
                unit.Select();
                selectedUnits.Add(unit);
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 worldPosition = new Vector3(rawPosition.x, rawPosition.y, 0f);

        return worldPosition;
    }

    private List<Vector3> GetTargetPositions()
    {
        List<Vector3> targetPositions = new List<Vector3>();
        int multiplier = selectedUnits.Count / -2;
        Vector3 centre = GetMouseWorldPosition();
        int x = 0;

        if (selectedUnits.Count == 1 || selectedUnits.Count % 2 != 0)
        {
            x = 10 * multiplier;
        }
        else
        {
            x = 10 * multiplier + 5;
        }

        for (int i = 0; i < selectedUnits.Count; i++)
        {
            targetPositions.Add(new Vector3(centre.x + x, centre.y));

            x += 10;
        }

        return targetPositions;
    }
}
