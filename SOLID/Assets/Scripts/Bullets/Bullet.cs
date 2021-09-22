using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float maxLife;
    public float MaxLife { get=> maxLife; private set => maxLife = value; }

    private float lifeTime;
    public float LifeTime {
        get => lifeTime;
        set
        {
            if(lifeTime != value)
            {
                OnBulletLifeChanged?.Invoke(lifeTime, value);
            }
            lifeTime = value;
        }
    }

    public event System.Action<float, float> OnBulletLifeChanged;


    private BulletModifier[] modifiers;
    void Start()
    {
        maxLife = 10f;
        lifeTime = maxLife;

        modifiers = GetComponents<BulletModifier>();

    }

    // Update is called once per frame
    void Update()
    {
        LoseLife();
    }

    public virtual void LoseLife()
    {
        //Bullet bullet =  d
        //foreach(var item in modifiers)
        //{
        //    bullet = item.UpdateLife(bullet);
        //}

        LifeTime -= Time.deltaTime;
    }
}

public abstract class BulletModifier
{
    public abstract void UpdateLife();
}

public class BulletSplitter : BulletModifier
{

    private Bullet decoratedBullet;
    public BulletSplitter(Bullet _bullet)
    {
        decoratedBullet = _bullet;
        decoratedBullet.OnBulletLifeChanged += SplitOnHalfLife;
    }

    public void SplitOnHalfLife(float oldValue, float newValue)
    {
        if(oldValue > 0.5f * decoratedBullet.MaxLife && newValue <= 0.5f * decoratedBullet.MaxLife)
        {
            //Split();
        }
    }

    public void LoseLife()
    {
        if(decoratedBullet.LifeTime > decoratedBullet.MaxLife * 0.5f &&
            decoratedBullet.LifeTime < decoratedBullet.MaxLife * 0.5f)
        {

        }
        decoratedBullet.LoseLife();
    }

    public override void UpdateLife()
    {
        LoseLife();
    }

}