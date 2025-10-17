using UnityEngine;

public class HeightPower : PowerupBase
{
    [Header("height")]
    public float height = 2;
    public float animDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPowerup()
    {
        base.StartPowerup();
        PlayerController.Instance.ChangeHeight(height, duration, animDuration, ease);
    }


    protected override void EndPowerup()
    {
        PlayerController.Instance.ResetHeight(animDuration);
    }
}
