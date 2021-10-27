using UnityEngine;

public class AttachVehicle : MonoBehaviour
{

    public GameObject forklift;
    public GameObject attachPoint;
    public GameObject parentExample;
    public bool onThePlatform;
    
    //Make vehicle child of platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == attachPoint)
        {
            onThePlatform = true;
            forklift.transform.SetParent(parentExample.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == attachPoint)
        {
            onThePlatform = false;
            forklift.transform.SetParent(null);
        }
    }
}
