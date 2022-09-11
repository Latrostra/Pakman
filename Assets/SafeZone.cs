using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                collision.gameObject.GetComponent<Health>().isSafe = true;
            }
        }
    }
    public void OnTriggerStay(Collider collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                collision.gameObject.GetComponent<Health>().isSafe = true;
            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                collision.gameObject.GetComponent<Health>().isSafe = false;
            }
        }
    }
}
