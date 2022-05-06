using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnvironment : MonoBehaviour
{
    public GameObject currentObject;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 7))
        {
            var selection = hit.transform;
            currentObject = selection.gameObject;

            if (Input.GetMouseButtonDown(0) && currentObject.layer == 7)
            {
                currentObject.GetComponent<EnvironmentHealth>().Health -= 50;
            }
        }
    }
}
