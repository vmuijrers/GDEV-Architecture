using UnityEngine;

public abstract class Weapon : MonoBehaviour, ICanAttack
{
    public virtual void Attack()
    {
        Debug.Log("This attack is almost the same for every weapon");
    }
}