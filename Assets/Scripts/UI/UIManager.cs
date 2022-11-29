using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _tapToPlayPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Image _progressBar;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateProgressBar(float value)
    {
        _progressBar.fillAmount = value;
    }
    public void SetActiveTapToPlayPanel(bool value)
    {
        _tapToPlayPanel.SetActive(value);
    }
    public void SetActiveWinPanel(bool value)
    {
        _winPanel.SetActive(value);
    }
    public void SetActiveLosePanel(bool value)
    {
        _losePanel.SetActive(value);
    }
}
