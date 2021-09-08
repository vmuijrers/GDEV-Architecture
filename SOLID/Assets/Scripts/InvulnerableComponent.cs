using UnityEngine;

public class InvulnerableComponent : HealthComponent, IDamageable
{
    public override void TakeDamage(float _damage)
    {
        Debug.Log("Can't hurt me!");
    }
}