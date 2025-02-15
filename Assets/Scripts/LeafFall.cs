using UnityEngine;

public class LeafFall : MonoBehaviour
{
    public float fallSpeed = 1f; // Speed at which the leaf falls

    void Update()
    {
        // Move the leaf downward
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy the leaf if it falls below a certain height
        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
