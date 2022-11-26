using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _tapToPlayPanel;
    [SerializeField] private Image _progressBar;

    private void Awake()
    {
        Instance = this;
    }

    public void SetActiveTapToPlayPanel(bool value)
    {
        _tapToPlayPanel.SetActive(value);
    }

    public void UpdateProgressBar(float value)
    {
        _progressBar.fillAmount = value;
    }
}
