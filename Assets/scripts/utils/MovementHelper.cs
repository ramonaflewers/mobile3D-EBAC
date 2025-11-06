using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;
    public Transform spawn;
    public float duration = 1f;
    private int _index = 0;

    private void Start() {
        if (spawn != null)
        {
            transform.position = spawn.position;
        }
        
        StartCoroutine(StartMovement());
    }

    IEnumerator StartMovement()
    {
        float time = 0;

        while (true)
        {
            var currentPosition = transform.position;
            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }

            _index++;
            if (_index >= positions.Count) _index = 0;
            time = 0;

            yield return null;
        }
    }
}
