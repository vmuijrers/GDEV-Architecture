using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorExample
{
    public class GameManager
    {

        public void Start()
        {
            Weapon fancyShotgun = new Decorator(new Shotgun(6));
            fancyShotgun.Fire();
        }
    }

    public class Decorator : Weapon
    {
        Weapon weapon;
        public Decorator(Weapon _weapon)
        {
            weapon = _weapon;
            weapon.OnFire += Sparkle;
        }

        public override void Fire()
        {
            Debug.Log("Fancy Piew");
            weapon.Fire();
        }

        private void Sparkle()
        {
            Debug.Log("Sparkle!");
        }
    }

    public abstract class Weapon
    {
        public System.Action OnFire;
        public abstract void Fire();

    }

    public class Shotgun : Weapon
    {
        private int bulletAmount;

        public Shotgun(int _numBullets)
        {
            bulletAmount = _numBullets;
        }
        public override void Fire()
        {
            for (int i = 0; i < bulletAmount; i++)
            {
                OnFire?.Invoke();
                Debug.Log("Piew");
            }
        }
    }

}

