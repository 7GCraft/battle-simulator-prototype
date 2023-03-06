using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera cam;

    public LayerMask clickable;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private void Click()
    {
        RaycastHit2D hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics2D.Raycast(ray, out hit, Mathf.Infinity, clickable))
    }
}
