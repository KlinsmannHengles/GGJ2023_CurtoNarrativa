using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericNPCBehaviour : MonoBehaviour
{

    public bool insideItemCollider = false; // if you are in the collision of the object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && insideItemCollider)
        {
            Interaction();
        }
    }

    public abstract void Interaction();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            insideItemCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            insideItemCollider = false;
        }
    }

}
