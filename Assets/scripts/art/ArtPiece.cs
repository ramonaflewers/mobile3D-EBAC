using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    private GameObject _currentArt;

    public void ChangePiece(GameObject prefab)
    {
        if (_currentArt != null) Destroy(_currentArt);

        _currentArt = Instantiate(prefab, transform);
        _currentArt.transform.localPosition = Vector3.zero;
    }
}
