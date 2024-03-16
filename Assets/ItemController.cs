using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = 2f;

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected the item!");
            Destroy(gameObject);
        }
    }
}
