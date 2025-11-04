using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    [Header("Materiais que serão afetados pelos ScriptableObjects")]
    public List<Material> materials;

    /// <summary>
    /// Aplica a cor do ScriptableObject apenas nos materiais da lista
    /// </summary>
    public void ChangeColorBySetup(ArtSetupSO setup)
    {
        if (setup == null) return;

        foreach (var mat in materials)
        {
            mat.color = setup.color;
        }
    }
}
