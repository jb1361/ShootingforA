using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInterface : IplayerController {
   
  public float updatePosition(float x, float y)
    {
       return updatePosition(x, y);
    }
   public float updateDirection(float x, float y)
    {
       return updateDirection(x, y);
    }
    public int NewPowerUp(int i)
    {
        return NewPowerUp(i);
    }
    public int UsePowerUp(int i)
    {
       return UsePowerUp(i);
    }
    public int takeDamage(int i)
    {
       return takeDamage(i);
    }
}
