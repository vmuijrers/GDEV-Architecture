using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{

    void Start()
    {
        StateMachine<Enemy> machine = new StateMachine<Enemy>();
        machine.AddState(new IdleEnemyState(machine));
    }
}

public class StateMachine<T>
{
    private State<T> currentState;

    private Dictionary<System.Type, State<T>> stateDictionary = new Dictionary<System.Type, State<T>>();


    public void SwitchState(System.Type type)
    {

    }

    public void AddState(State<T> state)
    {

    }

    public void RemoveState(State<T> state)
    {

    }
}

public abstract class State<T>
{
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}

public class EnemyState : State<Enemy>
{
    public StateMachine<Enemy> owner { get; protected set; }
    public EnemyState(StateMachine<Enemy> _owner) 
    {
        owner = _owner;
    }

    public override void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}

public class IdleEnemyState : EnemyState
{

    public IdleEnemyState(StateMachine<Enemy> _owner) : base(_owner)
    {
    }
}
