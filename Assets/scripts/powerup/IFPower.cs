using UnityEngine;

public class IFPower : PowerupBase
{
    //IF stands for invincibility frames


    protected override void StartPowerup()
    {
        base.StartPowerup();
        PlayerController.Instance.SetInvincible();
        PlayerController.Instance.PowerupText("invincible");
    }

    protected override void EndPowerup()
    {
        base.EndPowerup();
        PlayerController.Instance.SetInvincible(false);
        PlayerController.Instance.PowerupText("");
    }
}
