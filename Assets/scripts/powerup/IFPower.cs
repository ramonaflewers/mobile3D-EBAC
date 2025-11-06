using UnityEngine;

public class IFPower : PowerupBase
{
    // IF = Invincibility Frames
    public float transparency = 0.5f;   // nível de transparência
    public float fadeDuration = 0.3f;   // duração do fade

    protected override void StartPowerup()
    {
        base.StartPowerup();
        PlayerController.Instance.SetInvincible();
        PlayerController.Instance.PowerupText("invincible");
        PlayerController.Instance.SetTransparency(transparency, fadeDuration);
    }

    protected override void EndPowerup()
    {
        base.EndPowerup();
        PlayerController.Instance.SetInvincible(false);
        PlayerController.Instance.PowerupText("");
        PlayerController.Instance.SetTransparency(1f, fadeDuration);
    }
}
