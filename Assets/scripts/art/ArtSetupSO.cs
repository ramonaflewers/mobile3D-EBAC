using UnityEngine;
using System.Collections.Generic; // se você usar listas


[CreateAssetMenu(fileName = "ArtSetupSO", menuName = "Art/ArtSetupSO")]
public class ArtSetupSO : ScriptableObject
{
    public ArtManager.ArtType artType;
    public GameObject artPrefab;

    public Color color;
}
