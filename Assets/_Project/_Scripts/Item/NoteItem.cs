using UnityEngine;

public class NoteItem : Item
{
    [SerializeField, TextArea] private string _noteText;

    public override void ApplyEffect(PlayerStats player)
    {
        UIManager.Instance.ShowNote(_noteText);
        ItemsLogger.Instance.AddRecord($"Взята записка: {_noteText}");
        Destroy(gameObject);
    }
}
