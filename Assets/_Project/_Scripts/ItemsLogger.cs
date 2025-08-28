using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ItemsLogger : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _text;

    private List<string> _log = new List<string>();
    private string _filePath;

    public static ItemsLogger Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _filePath = Path.Combine(Application.persistentDataPath, "ItemsLogger.txt");
        _panel.SetActive(false);

        if (File.Exists(_filePath))
        {
            string[] lines = File.ReadAllLines(_filePath);
            _log.AddRange(lines);
        }
    }

    public void AddRecord(string message)
    {
        string entry = $"{System.DateTime.Now:HH:mm:ss} - {message}";
        _log.Add(entry);

        // сохранить в файл
        File.WriteAllLines(_filePath, _log);
    }

    public void ToggleLog()
    {
        if (_panel.activeSelf)
        {
            _panel.SetActive(false);
        }
        else
        {
            RefreshUI();
            _panel.SetActive(true);
        }
    }

    private void RefreshUI()
    {
        _text.text = string.Join("\n", _log);
    }

}
