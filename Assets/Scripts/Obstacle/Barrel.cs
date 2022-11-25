using TMPro;
using UnityEngine;

public class Barrel : Obstacle
{
    [SerializeField] private TextMeshPro _text;

    protected override void Start()
    {
        base.Start();
        _text.text = Health.ToString();
    }
    protected override void OnHealthUpdate()
    {
        base.OnHealthUpdate();
        _text.text = Health.ToString();
    }
}
