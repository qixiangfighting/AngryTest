﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : bird
{
    public override void showSkill()
    {
        base.showSkill();

        rg.velocity *= 2;
    }
}
