
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class originReferencePlacement : UdonSharpBehaviour
{
    void Start()
    {
        //transform.position = new Vector3(0, 1, 0);
        //Transform childTransform = transform.Find("Sphere");
        //Debug.Log(childTransform.position);
        //Debug.Log(childTransform.localPosition);
        //childTransform.localPosition = new Vector3(1, 1, 1);
        //Transform childTransform = transform.Find("materialPacket");
        //Debug.Log(childTransform.position);
    }
    private void Interact()
    {
        Debug.Log(transform.GetSiblingIndex());
        Transform sphereTransform = transform.Find("Sphere");
        Transform capsuleTransform = transform.Find("Capsule");
        Transform cylinderTransform = transform.Find("Cylinder");
        Transform drootTransform = transform.Find("droot");
        int drootSiblingNumber = drootTransform.GetSiblingIndex();
        Debug.Log(drootSiblingNumber);
        if (drootSiblingNumber == 1)
            {
                Debug.Log("It's true.");
                sphereTransform.position = sphereTransform.position + new Vector3(1, 0, 0);
                capsuleTransform.position = capsuleTransform.position + new Vector3(-1, 0, 0);
                cylinderTransform.position = cylinderTransform.position + new Vector3(0, 0, 1);
                drootTransform.position = drootTransform.position + new Vector3(0, 0, -1);
            }

    }
    void Update()
    {

    }
}
