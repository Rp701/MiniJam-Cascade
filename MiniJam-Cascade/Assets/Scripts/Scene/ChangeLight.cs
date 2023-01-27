using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public Light AmbientLight;

    void Start()
    {
        AmbientLight.GetComponent<Light>();
        AmbientLight.intensity = 0.7f;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("ChangeLight");
            AmbientLight.intensity = 0.1f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("BackToLight");
            AmbientLight.intensity = 0.7f;
        }
    }


}
