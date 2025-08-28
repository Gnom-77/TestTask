using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private PlayerStats _stats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out var item))
        {
            item.ApplyEffect(_stats);
        }
    }
}
