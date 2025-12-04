using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [Header("Lerp")]
    public Transform target;
    public float LerpSpeed = 5f;

    [Header("Movement")]
    public float speed = 5f;
    public string enemyTag = "enemy";
    public string endTag = "endLine";
    public GameObject endScreen;

    [Header("Animation")]
    public AnimatorManager animatorManager;
    public ParticleSystem vfxDeath;

    private float _currentSpeed;
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
        _currentSpeed = speed;
    }

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
        transform.localScale = Vector3.zero;
        canRun = false;
        transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack);
        animatorManager.Play(AnimatorManager.AnimationType.IDLE);
    }

    void Update()
    {
        if (canRun)
        {
            transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime, Space.World);

            if (target != null)
            {
                _pos = target.position;
                _pos.y = transform.position.y;
                _pos.z = transform.position.z;
                transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(enemyTag))
        {
            if (!invincible)
            {
                EndGameByEnemy();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(endTag))
        {
            EndGameByEndLine();
        }
    }

    private void EndGameByEnemy()
    {
        canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(AnimatorManager.AnimationType.DEAD);
        if(vfxDeath != null) vfxDeath.Play();
    }

    private void EndGameByEndLine()
    {
        canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(AnimatorManager.AnimationType.IDLE);
    }

    public void StartRun()
    {
        canRun = true;
        _currentSpeed = speed;
        animatorManager.Play(AnimatorManager.AnimationType.RUN);
    }

    public void StopRun()
    {
        canRun = false;
        animatorManager.Play(AnimatorManager.AnimationType.IDLE);
    }

    public void PowerupText(string s)
    {
        uiTextPowerup.text = s;
    }

    public void PowerupSpeed(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvincible(bool b = true)
    {
        invincible = b;
    }

    public void BounceEffect(float bounceScale = 1.2f, float duration = 0.25f)
    {
        transform.DOKill();
        transform.DOScale(Vector3.one * bounceScale, duration * 0.5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(Vector3.one, duration * 0.5f)
                    .SetEase(Ease.InQuad);
            });
    }

    public void ChangeHeight(float amount, float duration, float animDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(float animDuration = 0.3f)
    {
        transform.DOMoveY(_startPosition.y, animDuration);
    }
    
    public void SetTransparency(float alpha, float duration = 0f)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            foreach (var mat in r.materials)
            {
                if (mat.HasProperty("_Color"))
                {
                    if (duration > 0f)
                    {
                        mat.DOFade(alpha, duration);
                    }
                    else
                    {
                        Color c = mat.color;
                        c.a = alpha;
                        mat.color = c;
                    }
                }
            }
        }
    }
}
