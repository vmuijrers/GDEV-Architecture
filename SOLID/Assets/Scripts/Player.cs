using UnityEngine;

public class Player : MonoBehaviour
{
    private IDamageable healthComponent;
    private ICanAttack currentWeapon;

    // Start is called before the first frame update
    private void Start()
    {
        healthComponent = GetComponent<IDamageable>();
        ObtainWeapon(GetComponent<ICanAttack>());
    }

    private void OnEnable()
    {
        KeyInputController.Instance.RegisterKey(KeyCode.Space, TakeSomeDamage);
        MouseInputController.Instance.RegisterKey(MouseInputController.MouseButtonType.Left, Attack);
    }

    private void OnDisable()
    {
        KeyInputController.Instance.UnRegisterKey(KeyCode.Space, TakeSomeDamage);
        MouseInputController.Instance.UnRegisterKey(MouseInputController.MouseButtonType.Left, Attack);
    }

    private void TakeSomeDamage()
    {
        Debug.Log("Took some damage");
        healthComponent.TakeDamage(10f);
    }

    private void ObtainWeapon(ICanAttack _weapon)
    {
        if (_weapon == null) return;
        currentWeapon = _weapon;
    }

    private void Attack()
    {
        currentWeapon.Attack();
    }
}

/*
 * original class which needs refactoring
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Health { get; private set; }
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth;

    public enum Weapon { Sword, Bow }
    public Weapon currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) TakeDamage(10);
        if (Input.GetMouseButtonDown(0)) Attack(currentWeapon);
    }

    private void Attack(Weapon weaponType)
    {
        switch (weaponType)
        {
            case Weapon.Bow:
                DoRangedAttack();
                break;

            case Weapon.Sword:
                DoMeleeAttack();
                break;
        }
    }

    private void DoMeleeAttack()
    {

    }

    private void DoRangedAttack()
    {

    }

    public void TakeDamage(float _damage)
    {
        Health -= _damage;
        healthSlider.value = Health / maxHealth;

        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
*/