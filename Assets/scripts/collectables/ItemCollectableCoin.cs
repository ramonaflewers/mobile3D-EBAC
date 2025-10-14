using UnityEngine;

public class ItemCollectableCoin : collectableBase
{
    protected override void onCollect()
    {
        base.onCollect();
        //UICoinsManager.Instance.AddCoins(1);
    }
}
