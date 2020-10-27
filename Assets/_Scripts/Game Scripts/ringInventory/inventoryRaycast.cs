using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("mouse pressed");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
