using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This item can be taken 
public class SimpleItem : Item
{
    public override void Interaction()
    {
        PlayerGeneral.Instance.AddItemToInventory(this.gameObject);
        this.gameObject.SetActive(false);
    }

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
}
