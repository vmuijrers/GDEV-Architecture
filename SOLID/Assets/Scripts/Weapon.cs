using UnityEngine;

public abstract class Weapon : MonoBehaviour, ICanAttack
{
    public abstract void Attack();
}