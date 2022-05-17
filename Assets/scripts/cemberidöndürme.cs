using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemberidöndürme : MonoBehaviour
{
    public static float cemberdönüshizi=1f;
    
    private void Update()
    {
        transform.Rotate(0f, 0f, cemberdönüshizi);   
    }
}
