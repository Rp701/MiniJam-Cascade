using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.tag == "Drill")
       {
           Debug.Log("Here It Works");
       }
   }
}
