using UnityEngine;

public class SpeedPower : PowerupBase
{
    [Header("speed up")]
    public float speed;

    protected override void StartPowerup()
    {
        base.StartPowerup();
        PlayerController.Instance.PowerupSpeed(speed);
        PlayerController.Instance.PowerupText("speeding up");
    }

    protected override void EndPowerup()
    {
        base.EndPowerup();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.PowerupText("");
    }
}
