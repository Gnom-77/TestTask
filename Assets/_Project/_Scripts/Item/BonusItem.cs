using UnityEngine;

public class BonusItem : Item
{
    [SerializeField] private float _speedMultiplier = 2f;
    [SerializeField] private float _minDuration = 3f;
    [SerializeField] private float _maxDuration = 5f;


    public override void ApplyEffect(PlayerStats player)
    {
        float duration = RandomNumber();
        player.StartCoroutine(player.SpeedBoost(_speedMultiplier, duration));
        ItemsLogger.Instance.AddRecord($"¬з€т бонус x{_speedMultiplier} к speed на {duration}с");
        Destroy(gameObject);
    }

    private float RandomNumber()
    {
        float res = Random.Range(_minDuration, _maxDuration + 1);
        return res;
    }
}
