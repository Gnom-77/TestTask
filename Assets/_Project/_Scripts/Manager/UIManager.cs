using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Note UI")]
    [SerializeField] private GameObject _notePanel;
    [SerializeField] private TMP_Text _noteText;

    [SerializeField] private GameObject _endGamePanel;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _notePanel.SetActive(false);
        _endGamePanel.SetActive(false);
    }

    public void ShowNote(string text)
    {
        _noteText.text = text;
        _notePanel.SetActive(true);
    }

    public void HideNote()
    {
        _notePanel.SetActive(false);
    }

    public void ShowEndGamePanel()
    {
        _endGamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
