using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    public RotationAxes axes = RotationAxes.MouseXandY;
    private float _sensitivityHorizon = 6f;
    private float _sensitivityVertical = 6f;

    private float _minVerticalAngle = -45f;
    private float _maxVerticalAngle = 45f;

    private float _verticalRotation;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb != null )
        {
            _rb.freezeRotation = true;
        }
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHorizon, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _verticalRotation -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
            _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalAngle, _maxVerticalAngle);

            float horizontalRotation = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_verticalRotation, horizontalRotation, 0);
        }
        else 
        {
            _verticalRotation -= Input.GetAxis("Mouse Y") * _sensitivityVertical;
            _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalAngle, _maxVerticalAngle);

            float delta = Input.GetAxis("Mouse X") * _sensitivityHorizon;
            float horizontalRotation = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_verticalRotation, horizontalRotation, 0);
        }
    }
}
