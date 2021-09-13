public interface IDamageable
{
    float Health { get; }
    float MaxHealth { get; }
    void TakeDamage(float damage);
    event System.Action<float> OnHealthChanged;
}