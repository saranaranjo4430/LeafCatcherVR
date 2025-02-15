using UnityEngine;

public class LockBasketRotation : MonoBehaviour
{
    public Transform handTransform; // Reference to the hand (LeftHand Controller)
    private Quaternion fixedRotation; // Fixed rotation to keep basket horizontal

    void Start()
    {
        // Set the initial rotation of the basket
        fixedRotation = Quaternion.Euler(0, 0, 0); // Horizontal rotation
    }

    void LateUpdate()
    {
        if (handTransform != null)
        {
            // Keep the basket following the hand's position
            transform.position = handTransform.position;

            // Allow the basket to rotate horizontally with the hand but keep it level
            transform.rotation = Quaternion.Euler(
                0,                        // Keep the basket's X-axis rotation at 0 (no tilt)
                handTransform.rotation.eulerAngles.y, // Follow the hand's Y-axis rotation
                0                         // Keep the Z-axis rotation at 0 (no tilt)
            );
        }
    }
}
