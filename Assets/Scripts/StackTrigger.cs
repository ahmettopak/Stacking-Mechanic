using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Worm")
        {
            StackManager.instance.PileOn(other.gameObject, true, "Untagged");
        }
    }
}
