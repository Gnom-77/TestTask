using UnityEngine;

public class DamageItem : Item
{
    [SerializeField] private float _damage = 20f;

    public override void ApplyEffect(PlayerStats player)
    {
        player.TakeDamage(_damage);
        ItemsLogger.Instance.AddRecord($"Взят урон. было потеряно {_damage} HP");
        Destroy(gameObject);
    }
}
