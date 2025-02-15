using UnityEngine;

public class BasketCollector : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager for scoring

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leaf"))
        {
            // Update the score
            gameManager.AddToScore(1);

            // Make the leaf stay in the basket
            StickLeafInBasket(other.gameObject);
        }
    }

    void StickLeafInBasket(GameObject leaf)
    {
        // Parent the leaf to the basket
        leaf.transform.SetParent(transform);

        // Disable the leaf's Rigidbody to stop physics
        Rigidbody leafRb = leaf.GetComponent<Rigidbody>();
        if (leafRb != null)
        {
            leafRb.isKinematic = true; // Disable physics calculations
        }

        // Disable the leaf's collider to prevent further interaction
        Collider leafCollider = leaf.GetComponent<Collider>();
        if (leafCollider != null)
        {
            leafCollider.enabled = false;
        }

        // Position the leaf inside the basket (randomized for variety)
        leaf.transform.localPosition = new Vector3(
            Random.Range(-0.1f, 0.1f), // X-axis position
            Random.Range(-0.1f, 0.1f), // Y-axis position
            Random.Range(-0.1f, 0.1f)  // Z-axis position
        );

        // Optionally, add a slight rotation for visual variety
        leaf.transform.localRotation = Random.rotation;
    }
}
