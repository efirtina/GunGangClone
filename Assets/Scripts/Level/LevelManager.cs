using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Transform _groundTransform;
    

    private void Awake()
    {
        Instance = this;
    }

    public float GetLevelBoundry()
    {
        return _groundTransform.localScale.x / 2;
    }
}
