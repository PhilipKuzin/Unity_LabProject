using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHitResultBehaviour : IDamager
{
    public GameObject Shoot(Vector3 hitPlace)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.transform.position = hitPlace;

        return cube;
    }
}
