using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kameraicin : MonoBehaviour
{
    public Transform toppozisyonu;
    void Update()
    {
        if (toppozisyonu.position.y >= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, toppozisyonu.position.y, transform.position.z);
        }
    }
}
