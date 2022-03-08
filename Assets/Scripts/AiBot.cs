using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiBot : MonoBehaviour
{
    public List<Skill> BotSkills;

    private void Awake()
    {
        BotSkills = new List<Skill>();
    }

    
}

