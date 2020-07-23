using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBirds : bird
{
    public override void showSkill()
    {
        base.showSkill();
        Vector3 speed = rg.velocity;
        speed.x *= -1;
        rg.velocity = speed;
    }
}
