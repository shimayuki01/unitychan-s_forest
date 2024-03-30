using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPlayerAction
{
    public void Cook(string cookItem_id);
    public void Walk(Vector2 walkVecter);
}
