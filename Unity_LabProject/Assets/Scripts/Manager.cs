using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private RayShooter _shooter;

    private void Awake()
    {
        _shooter.Initizlize(new SphereHitResultBehaviour());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _shooter.Initizlize(new CubeHitResultBehaviour());
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            _shooter.Initizlize(new SphereHitResultBehaviour());
        }

    }
}
