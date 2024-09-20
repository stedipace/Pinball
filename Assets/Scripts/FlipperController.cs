using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private HingeJoint2D leftFlipper;
    [SerializeField] private HingeJoint2D rightFlipper;

    [SerializeField] private float speed = 1000f;
    [SerializeField] private float returnSpeed = 500f;

    private void Update()
    {
        var leftInput = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S);
        var rightInput = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S);

        UpdateFlipper(leftFlipper, leftInput, -speed, returnSpeed);
        UpdateFlipper(rightFlipper, rightInput, speed, -returnSpeed);
    }

    private void UpdateFlipper(HingeJoint2D flipper, bool isActive, float activeSpeed, float restingSpeed)
    {
        var motor = flipper.motor;
        motor.motorSpeed = isActive ? activeSpeed : restingSpeed;
        flipper.motor = motor;
    }
}
