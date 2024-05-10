using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SphereHitResultBehaviour : IDamager
{
    public GameObject Shoot(Vector3 hitPlace)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = hitPlace;

        return sphere;
    }
}
