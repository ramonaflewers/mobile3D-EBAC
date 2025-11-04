using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSetup", menuName = "Game/Color Setup")]
public class ColorSetupSO : ScriptableObject
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
