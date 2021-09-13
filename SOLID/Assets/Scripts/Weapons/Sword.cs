using UnityEngine;

public class Sword : Weapon
{
    public override void Attack()
    {
        Debug.Log("Attacked with a sword!");
        DoSomehting(34f);
    }

    public void DoSomehting(float _Arg1)
    {

    }

    public void DoSomehting(int _Arg1)
    {

    }
}