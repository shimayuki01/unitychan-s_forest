using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMove {
    public void run();
    public void walk(Vector2 walkVecter);
    
}
