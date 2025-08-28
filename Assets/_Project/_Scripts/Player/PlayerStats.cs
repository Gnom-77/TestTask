using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private TMP_Text _textPlayerHealthPoint;

    private float _currentHealth;
    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _currentHealth = _maxHealth;
        _textPlayerHealthPoint.text = _currentHealth.ToString();
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        _textPlayerHealthPoint.text = _currentHealth.ToString();
        if (_currentHealth <= 0)
        {
            Debug.Log("Game Over");
            UIManager.Instance.ShowEndGamePanel();
            GameObject.Destroy(gameObject);
        }
    }

    public IEnumerator SpeedBoost(float multiplier, float duration)
    {
        _movement.SetSpeed(_movement.Speed * multiplier);
        yield return new WaitForSeconds(duration);
        _movement.SetSpeed(_movement.Speed / multiplier);
    }
}
