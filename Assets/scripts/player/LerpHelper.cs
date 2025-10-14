using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    public Transform target;
    public float LerpSpeed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, LerpSpeed * Time.deltaTime);
    }
}
