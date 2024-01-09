using System;
using UnityEngine;

public class TickSystem : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;

    // Tick every 5 seconds.
    private const float TICK_TIMER_MAX = 5f;

    private int tick;
    private float tickTimer;

    // Start is called before the first frame update
    void Start()
    {
        tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tickTimer += Time.deltaTime;

        if(tickTimer >= TICK_TIMER_MAX )
        {
            tickTimer -= TICK_TIMER_MAX;
            tick++;
            
            if(OnTick != null)
            {
                OnTick(this, new OnTickEventArgs { tick = tick });
            }
        }
    }
}
