using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    private float jumpforce = 4.5f;
    private float _speed = 1f;
    private Rigidbody _rigidbody;
    Vector3 _rotationEulerAngleVelocityRight;
    Vector3 _rotationEulerAngleVelocityLeft;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec).
        _rotationEulerAngleVelocityRight = new Vector3(0, -100, 0);
        _rotationEulerAngleVelocityLeft = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float multiplier = 1f;

        if (Input.GetKey(KeyCode.LeftShift))
            multiplier = 2f;

        if (_rigidbody.velocity.magnitude < _speed * multiplier)
        {
            float value = Input.GetAxis("Vertical");

            if (value != 0)
                _rigidbody.AddForce(0, 0, value * Time.fixedDeltaTime * 200f);

            value = Input.GetAxis("Horizontal");

            if (value != 0)
                _rigidbody.AddForce(value * Time.fixedDeltaTime * 200f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        Quaternion deltaRotationRight = Quaternion.Euler(_rotationEulerAngleVelocityRight * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotationRight);
        }

        Quaternion deltaRotationLeft = Quaternion.Euler(_rotationEulerAngleVelocityLeft * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.E))
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotationLeft);
        }
    }
}