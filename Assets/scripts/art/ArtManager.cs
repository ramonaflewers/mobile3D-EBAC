using System.Collections.Generic;
using UnityEngine;

public class ArtManager : MonoBehaviour
{
    public static ArtManager Instance;

    public List<ArtSetupSO> artSetups;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public ArtSetupSO GetSetupByType(ArtType artType)
    {
        return artSetups.Find(a => a.artType == artType);
    }

    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        TYPE_03
    }
}
