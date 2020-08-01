using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity = 1;
    public float accelerationSpeed = .5f;
    public float deccelerationSpeed = 1f;
    public float maxSpeed;
    private float forwardSpeed;
    private float rightSpeed;
    private bool goingForward;
    private bool goingBackward;
    private bool goingRight;
    private bool goingLeft;
    private MouseLook mouseLook;
    private Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        mouseLook = new MouseLook();
        playerCamera = GetComponentInChildren<Camera>();
        mouseLook.Init(transform, playerCamera.transform, mouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Forward"))
        {
            goingForward = true;
        }
        else if (Input.GetButtonUp("Forward"))
        {
            goingForward = false;
        }
        if (Input.GetButtonDown("Backward"))
        {
            goingBackward = true;
        }
        else if (Input.GetButtonUp("Backward"))
        {
            goingBackward = false;
        }
        if (Input.GetButtonDown("Right"))
        {
            goingRight = true;
        }
        else if (Input.GetButtonUp("Right"))
        {
            goingRight = false;
        }

        if (Input.GetButtonDown("Left"))
        {
            goingLeft = true;
        }
        else if (Input.GetButtonUp("Left"))
        {
            goingLeft = false;
        }
        if (Input.GetButtonDown("Down"))
        {
            if (!GetComponent<AntiGravable>().gravApplied)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.position += this.transform.up * -.2f);
            }
        }

        Vector3 forward = this.gameObject.transform.forward.normalized;
        forwardSpeed = ApplyDirectionLogic(forward, goingForward, goingBackward, forwardSpeed);
        Vector3 right = this.gameObject.transform.right.normalized;
        rightSpeed = ApplyDirectionLogic(right, goingRight, goingLeft, rightSpeed);

        mouseLook.LookRotation(transform, playerCamera.transform);

    }

    float ApplyDirectionLogic(Vector3 direction, bool positiveAcceleration, bool negativeAcceleration, float speed)
    {
        if (positiveAcceleration)
        {
            speed = ApplyAcceleration(direction, 1, speed, accelerationSpeed);
        }
        else if (negativeAcceleration)
        {
            speed = ApplyAcceleration(direction, -1, speed, accelerationSpeed);
        }

        else
        {
            if (speed > 0)
            {

                speed = ApplyAcceleration(direction, -1, speed, deccelerationSpeed);

            }
            else if (speed < 0)
            {
                speed = ApplyAcceleration(direction, 1, speed, deccelerationSpeed);
            }

        }
        return speed;
    }
    float ApplyAcceleration(Vector3 direction, int positiveOrNegative, float speed, float acceleration)
    {

        if ((positiveOrNegative > 0 && speed < maxSpeed) || (positiveOrNegative < 0 && speed > -maxSpeed))
        {

            speed += (positiveOrNegative * acceleration);

        }
        Vector3 v3 = direction * speed;
        GetComponent<Rigidbody>().AddForce(v3);
        return speed;
    }
}