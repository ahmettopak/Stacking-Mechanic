using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance; //Singleton

    [SerializeField] private float distanceObject; //Üst üste dizilmiþ iki robot arasý mesafe
    [SerializeField] private Transform wormObject;
    [SerializeField] private Transform wormParent;

    private void Awake()
    {
        if (instance ==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        distanceObject = wormObject.localScale.y; //y mesafesi kadar olmalý
    }

    public void PickUp (GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if(needTag)
            {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = wormParent;
        Vector3 desPos = wormObject.localPosition;
        desPos.y += downOrUp ? distanceObject : -distanceObject;
        pickedObject.transform.localPosition = desPos;
        wormObject = pickedObject.transform;
    }
   

    public void PileOn(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
         if (needTag)
        {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = wormParent;
        Vector3 desPos = wormObject.localPosition;
        desPos.y += downOrUp ? distanceObject : -distanceObject;
        desPos.z += pickedObject.transform.localScale.z;

        pickedObject.transform.localPosition = desPos;
        wormObject = pickedObject.transform;
        

    }
}
