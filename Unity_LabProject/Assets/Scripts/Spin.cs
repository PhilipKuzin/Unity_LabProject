using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private float _rotationSpeed = 3f;
    
    void Update()
    {
       transform.Rotate (0, _rotationSpeed * Time.deltaTime, 0, Space.World); 
    }
}
