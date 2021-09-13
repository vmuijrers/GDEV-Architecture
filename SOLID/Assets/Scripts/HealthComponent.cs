using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;
    public float Health {
        get
        {
            return health;
        }
        protected set
        {
            if (value != health)
            {
                OnHealthChanged?.Invoke(value);
            }
            health = value;
        }
    }
    [SerializeField] protected float maxHealth;
    public float MaxHealth => maxHealth;

    public event System.Action<float> OnHealthChanged;

    void Start()
    {
        Health = maxHealth;
    }

    void OnEnable()
    {
    }

    void OnDisable()
    {
    }

    private int Test()
    {
        return 0;
    }

    public virtual void TakeDamage(float _damage)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

    }
}
