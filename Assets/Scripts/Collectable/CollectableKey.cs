using UnityEngine;

public class CollectableKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameManager.Instance.UpdateKeysLeft();
            Destroy(this.gameObject);
        }
    }
}