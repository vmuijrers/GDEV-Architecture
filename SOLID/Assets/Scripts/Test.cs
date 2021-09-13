using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        EventManager.Register(EventType.ON_PLAYER_HIT, DoParticles);
        EventManager<float>.Register(EventType.ON_PLAYER_HIT, DoParticlesFancy);
    }
    private void OnDisable()
    {
        EventManager.UnRegister(EventType.ON_PLAYER_HIT, DoParticles);
        EventManager<float>.UnRegister(EventType.ON_PLAYER_HIT, DoParticlesFancy);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //EventManager.Invoke(EventType.ON_PLAYER_HIT);
            EventManager<float>.Invoke(EventType.ON_PLAYER_HIT, 3f);
        }
    }

    private void DoParticles()
    {
        Debug.Log("Particles!");
    }
    private void DoParticlesFancy(float _size)
    {
        Debug.Log("Particles are big: " + _size);
    }
}
