using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("New/Reward Item"))]
public class reward : ScriptableObject
{
    public Sprite icon;
    public int increasePerIteration = 20;
    public bool isClaimed;
}
