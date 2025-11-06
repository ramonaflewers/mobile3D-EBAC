using UnityEngine;

public class PowerupBase : collectableBase
{
    public float duration;

    protected override void onCollect()
    {
        base.onCollect();
        StartPowerup();
        PlayerController.Instance.BounceEffect();
    }

    protected virtual void StartPowerup()
    {
        Invoke(nameof(EndPowerup), duration);
        
    }

    protected virtual void EndPowerup()
    {
        PlayerController.Instance.PowerupText("");   
    }
}
