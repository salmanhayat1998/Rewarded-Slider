using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = ("New/Reward holder"))]
public class rewardHolder : ScriptableObject
{
    public List<reward> rewards = new List<reward>();
}
