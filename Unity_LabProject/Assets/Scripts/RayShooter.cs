using System;
using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private IDamager _damager;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    public void Initizlize(IDamager damager)
    {
        _damager = damager;
    }

    private void Shoot()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(10);
            else
                StartCoroutine(SphereIndicator(hit.point));
        }
    }

    private IEnumerator SphereIndicator(Vector3 point)
    {
        GameObject obj = _damager.Shoot(point);

        yield return new WaitForSeconds(1);

        Destroy(obj);
    }
}
