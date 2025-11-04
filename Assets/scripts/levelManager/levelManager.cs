using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;

    public int startingNumberOfPieces = 3;
    public int numberOfPieces = 5;
    public int endingNumberOfPieces = 1;
    public float piecesDelay = 0.3f;

    public ArtManager.ArtType artType;

    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private ArtSetupSO _currentSetup;

    private void Start()
    {
        artType = GetRandomArtType();
        _currentSetup = ArtManager.Instance.GetSetupByType(artType);

        if (_currentSetup == null)
        {
            Debug.LogError("Nenhum ArtSetupSO encontrado para o tipo: " + artType);
            return;
        }

        CreateLevelPieces();
    }

    private ArtManager.ArtType GetRandomArtType()
    {
        var values = System.Enum.GetValues(typeof(ArtManager.ArtType));
        return (ArtManager.ArtType)values.GetValue(Random.Range(0, values.Length));
    }

    private void CreateLevelPieces()
    {
        CleanPieces();

        for (int i = 0; i < startingNumberOfPieces; i++)
            SpawnPiece(levelPiecesStart);

        for (int i = 0; i < numberOfPieces; i++)
            SpawnPiece(levelPieces);

        for (int i = 0; i < endingNumberOfPieces; i++)
            SpawnPiece(levelPiecesEnd);

        ColorManager.Instance.ChangeColorBySetup(_currentSetup);
    }

    private void SpawnPiece(List<LevelPieceBase> list)
    {
        if (list.Count == 0) return;

        var piecePrefab = list[Random.Range(0, list.Count)];
        var spawned = Instantiate(piecePrefab, container);

        if (_spawnedPieces.Count > 0)
        {
            var last = _spawnedPieces[_spawnedPieces.Count - 1];
            spawned.transform.position = last.endPiece.position;
        }
        else
        {
            spawned.transform.localPosition = Vector3.zero;
        }

        foreach (var art in spawned.GetComponentsInChildren<ArtPiece>())
        {
            art.ChangePiece(_currentSetup.artPrefab);
        }

        _spawnedPieces.Add(spawned);
    }

    private void CleanPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
            Destroy(_spawnedPieces[i].gameObject);

        _spawnedPieces.Clear();
    }
}
