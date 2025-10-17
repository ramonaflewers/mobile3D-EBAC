using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
     public static PlayerController Instance { get; private set; }

    [Header("Lerp")]
    public Transform target;
    public float LerpSpeed = 1f;

    public float speed = 1f;
    public string enemyTag = "enemy";
    public string endTag = "endLine";
    public GameObject endScreen;

    private float _currentspeed;
    private Vector3 _startPosition;
    private bool canRun;
    private Vector3 _pos;

    public bool invincible = false;

    public TextMeshPro uiTextPowerup;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _currentspeed = speed;
    }

    private void Start() {
        _startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if (!canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * _currentspeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == enemyTag)
        {
            if (!invincible) EndGame();
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

    public void startRun()
    {
        canRun = true;
    }

    public void PowerupText(string s)
    {
        uiTextPowerup.text = s;
    }

    public void PowerupSpeed(float f)
    {
        _currentspeed = f;
    }

    public void ResetSpeed()
    {
        _currentspeed = speed;
    }

    public void SetInvincible(bool b = true)
    {
        invincible = b;
    }

    public void ChangeHeight(float amount, float duration, float animDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }
    
    public void ResetHeight(float animDuration)
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y, animDuration);
    }
}
