using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryItem : MonoBehaviour
{
    bool selected = false;
    bool previousSelected = false;
    float rot = 0.0f;
    float timeRemaining = 1.0f;
    float originYRotation;
    float distanceToGo;
    // Start is called before the first frame update
    void Start()
    {
        originYRotation = gameObject.transform.rotation.eulerAngles.y;
        if (name == "Cube0")
        {
            selected = true;
        }
        rot = this.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("mouse pressed");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if(hit.collider.name == this.name)
                {
                    selected = true;
                    previousSelected = true;
                }
                else
                {
                    selected = false;
                }
            }
        }
        if (selected)
        {
            //Debug.Log(gameObject.transform.rotation.eulerAngles.y);
            gameObject.transform.Rotate(new Vector3(0.0f,10 * Time.deltaTime, 0.0f));
        }
        else if(previousSelected  && (timeRemaining > 0.1f || gameObject.transform.rotation.eulerAngles.y > 1.0f))
        {
            //Debug.Log(distanceToGo * Time.deltaTime);
            
            timeRemaining -= Time.deltaTime;
            distanceToGo = gameObject.transform.rotation.eulerAngles.y - originYRotation;
            if (gameObject.transform.rotation.eulerAngles.y > 180)
            {
                gameObject.transform.Rotate(new Vector3(0.0f, (distanceToGo * Time.deltaTime) / timeRemaining, 0.0f));
            }
            else if (gameObject.transform.rotation.eulerAngles.y < 180)
            {
                gameObject.transform.Rotate(new Vector3(0.0f, (-distanceToGo * Time.deltaTime) / timeRemaining, 0.0f));
            }
        }
        else if (previousSelected)
        {
            Debug.Log("time left: " + timeRemaining);
            Debug.Log("rotation left: " + gameObject.transform.rotation.eulerAngles.y);

            timeRemaining = 1.0f;
            previousSelected = false;
        }
    }
}
