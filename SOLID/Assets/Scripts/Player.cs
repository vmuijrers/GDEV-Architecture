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
