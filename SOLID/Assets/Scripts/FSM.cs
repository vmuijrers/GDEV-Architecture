using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public int Health { get => health; protected set => health = value; }

    void Start()
    {
        StateMachine<Enemy> machine = new StateMachine<Enemy>(this);
        IdleEnemyState idleState = new IdleEnemyState(machine);
        idleState.AddTransition(new Transition<Enemy>(
        (x) =>
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                return true;
            }
            return false;
        }, typeof(IdleEnemyState)));
        idleState.AddTransition(new Transition<Enemy>(
        (x) =>
        {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        return true;
        }
        return false;
        }, typeof(IdleEnemyState)));
        machine.AddState(idleState);
    }
}

public class StateMachine<T>
{
    private State<T> currentState;

    private Dictionary<System.Type, State<T>> stateDictionary = new Dictionary<System.Type, State<T>>();

    public T Controller { get; protected set; }

    public StateMachine(T _owner)
    {
        Controller = _owner;
    }
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
    public StateMachine<T> stateMachine { get; protected set; }
    public List<Transition<T>> transitions = new List<Transition<T>>();

    public State(StateMachine<T> stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    public virtual void AddTransition(Transition<T> transition)
    {
        transitions.Add(transition);
    }
}

public class Transition<T>
{
    public Transition(System.Predicate<T> condition, System.Type toState)
    {
        this.condition = condition;
        this.toState = toState;
    }
    public System.Predicate<T> condition;
    public System.Type toState;
}

public class EnemyState : State<Enemy>
{
    public EnemyState(StateMachine<Enemy> stateMachine) : base(stateMachine)
    {
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
        foreach (Transition<Enemy> transition in transitions)
        {
            if (transition.condition.Invoke(stateMachine.Controller))
            {
                stateMachine.SwitchState(transition.toState.GetType());
                return;
            }
        }
    }
}

public class IdleEnemyState : EnemyState
{

    public IdleEnemyState(StateMachine<Enemy> _owner) : base(_owner)
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }
}

//Enemy -> StateMachine -> EnemyState -> IdleEnemyState -> Transitions