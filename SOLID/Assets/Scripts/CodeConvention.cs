using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeConvention : MonoBehaviour
{
    //Variables
    //Option 1 -> 3
    public float Health;
    private float someVal = 1f;

    //Option 2 -> ~16 <-Winner
    public float someVariableIsCool = 1f;
    private float someVariableIsCool2 = 1f;

    //Option 3 -> 2
    public float ssomeVariableIsCool2 = 1f;
    private float _someVariableIsCool2 = 1f;

    //-> 5
    public GameObject Target;

    //Functions:
    //Optie 1: -> 14 <- Winner
    public void DoSomething(float _someVal, int _arg2)
    {
        someVal = _someVal;
        //this.someVal = someVal;
    }

    // Optie 2: -> 9
    public void DoSomething2(float someVal, int arg2)
    {
        this.someVal = someVal;
    }

    //Brackets:
    //Option 1 ->18 -> Winner
    void SomeFunc()
    {
        if (true)
        {
            for (int i = 0; i < 3; i++)
            {

            }
        }
    }
    
    //Option 2 -> 4
    void SomeFunc2() {

    }

    //One liner
    //Option 1: (one rule)
    void Bla()
    {
        if (true) DoSomething(); //option 1 -> 13 -> Winner

        if (true) //option 1.5 -> 2
            DoSomething();

        if (true) { DoSomething(); } //option 2 -> 3
        if (true)//optiion =3 -> 6
        {
            DoSomething();
        }

        void OneRuler() { DoSomething(); SomeFunc2(); }
    }

    void DoSomething()
    {

    }
}


public class SomeClass
    {
        public float someFloat;
        private float someOtherFloat;

        //Properties
        //option 1 -> 3
        public float SomeFloat
        {
            get; set;
        }

        //option 2 -> 11 -> Winner
        private float playerFloat;
        public float someFloat2
        {
            get;
            set;
        }
        public float someFloat3 { get; }
        public float someFloat4 => someFloat3;
    }

    //Order Variables/Properties/Functions (Constructor, Monobehaviour, Custom) -> Winner
    //option 1 Grouping (public, private, protected)

    //option 2 
    //Variables, Properties, Functions

    //Comments
    //Option 1: boven als het over meerdere regels gaat
    //Functies alleen commenten als je een complexe functie schrijft

public interface IStartInterfaceWIthI
{

} 
