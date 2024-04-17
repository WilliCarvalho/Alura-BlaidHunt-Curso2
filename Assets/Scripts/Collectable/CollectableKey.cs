using UnityEngine;

public class CollectableKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}