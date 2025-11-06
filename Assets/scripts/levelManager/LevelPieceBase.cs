using UnityEngine;

public class LevelPieceBase : MonoBehaviour
{
    public Transform endPiece;

    [Range(1, 100)]
    public int rarity = 100;
}
