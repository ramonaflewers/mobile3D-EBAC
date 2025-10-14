using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("lerp")]
    public Transform target;
    public float LerpSpeed = 1f;

    public float speed = 1f;
    public string enemyTag = "enemy";
    public string endTag = "endline";
    public GameObject endScreen;

    private bool canRun;
    private Vector3 _pos;

    void Update()
    {
        if (!canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == enemyTag)
        {
            EndGame();
        }

    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.transform.tag == endTag)
        {
            EndGame();
        }
    }

    private void EndGame() {
            canRun = false;
            endScreen.SetActive(true);
    }
    
    public void startRun() {
            canRun = true;
        }
}
