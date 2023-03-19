
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class helloWorld : UdonSharpBehaviour
{
    public string personName = "Greg";
    public int yearsOld = 30;
    void OnDisable()
    {
        Debug.Log(personName + " is " + yearsOld + " years old." );
    }
    void OnEnable()
    {
        Debug.Log("You're enabling him.");
    }
}
