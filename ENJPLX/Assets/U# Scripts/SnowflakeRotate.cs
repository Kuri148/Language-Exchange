
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SnowflakeRotate : UdonSharpBehaviour
{
    public GameObject snowFlake;
    [SerializeField] private Vector3 _rotation;

    void Update()
    {
        transform.Rotate(_rotation*Time.deltaTime);
    }
    void Start()
    {
        
    }
}
