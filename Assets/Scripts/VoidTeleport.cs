using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class VoidTeleport : MonoBehaviour
{

    private GameObject currentTeleporter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
 
    }

    private void OnTriggerEnter2D(Collider2D colliosion)
    {
        if (colliosion.CompareTag("VoidTeleporter"))
        {
            currentTeleporter = colliosion.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D colliosion)
    {
        if (colliosion.CompareTag("VoidTeleporter"))
        {
            if (colliosion.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
