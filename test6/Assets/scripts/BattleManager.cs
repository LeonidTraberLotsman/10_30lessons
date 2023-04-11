using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public List<enemy> enemies;

    public List<spectator> spectators; 
    // Start is called before the first frame update

    public void Alarm()
    {
        foreach (spectator that_spectator in spectators)
        {
            that_spectator.Alarmed();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
