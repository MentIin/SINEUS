using CodeBase.Logic.Player;
using DG.Tweening;
using Unity.Burst.Intrinsics;
using UnityEngine;
namespace CodeBase.Logic.Attacks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BoomerangBullet : MonoBehaviour
    {
        [HideInInspector] public int damage;
        [HideInInspector] public Attack parentAttack;

        [HideInInspector] public SpriteRenderer handRenderer;
        [SerializeField] private Sprite handFull;
        [SerializeField] private Sprite handEmpty;

        public float speed;
        [SerializeField] private float speedCoof = 3;

        public CircleCollider2D _collider2D;

        [SerializeField] private Transform visual;

        [HideInInspector] public Vector3 targetPos = Vector3.zero;
        private bool isTargetPos = false;
        [SerializeField] private float minDist = 0.05f;

        private Rigidbody2D rb;
        //private GameObject player;

        private bool canAttack = true;
        [SerializeField] private float attackDelay = 0.1f;
        private float timeBtwAttack;

        [SerializeField] private int lifeTime = 10;
        private void Start()
        {
            //player = FindFirstObjectByType<PlayerController>().gameObject;

            timeBtwAttack = attackDelay;

            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.freezeRotation = true;
            visual.DORotate(new Vector3(0, 0, 360), 0.1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative();
            handRenderer.sprite = handEmpty;
            OnAttack();

            Invoke("NadoelKrutitsa", lifeTime);
        }
        public void OnAttack()
        {
            rb.linearVelocity = transform.right * speed;
        }
        private void Update()
        {
            if (!isTargetPos)
            {
                if (Mathf.Abs(Vector2.Distance(transform.position, targetPos)) < minDist)
                {
                    isTargetPos = true;
                }
            }
            if (isTargetPos)
            {
                rb.linearVelocity = Vector2.zero;
                transform.position = Vector2.Lerp(transform.position, parentAttack.transform.position, speed * speedCoof * Time.deltaTime);
                if (Mathf.Abs(Vector2.Distance(transform.position, parentAttack.transform.position)) < minDist)
                {
                    NadoelKrutitsa();
                }
            }
            if (!canAttack) timeBtwAttack -= Time.deltaTime;
            if (timeBtwAttack < 0)
            {
                timeBtwAttack = attackDelay;
                canAttack=true;
            }

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (canAttack) DealDamage();
        }
        private void DealDamage()
        {

            Health health;
            foreach (var col in Physics2D.OverlapCircleAll(_collider2D.bounds.center,
                _collider2D.radius))
            {
                if (col.TryGetComponent(out health))
                {
                    if (health.Team != parentAttack.Team)
                    {
                        health.TakeDamage(damage);
                        Debug.Log("Киййа!");
                        canAttack = false;
                    }
                }
            }
        }
        private void NadoelKrutitsa()
        {
            parentAttack.GetComponent<AttackBoomerang>().StartReload();
            handRenderer.sprite = handFull;
            visual.DOKill();
            Destroy(gameObject);
        }
    }
    
}
