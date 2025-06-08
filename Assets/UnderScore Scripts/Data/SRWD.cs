using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleRandomWalkParameters_", menuName = "PCG/SimpleRAndomWalkData")]

public class SRWD : ScriptableObject
{
    public int iteration = 10, walkLength = 10;
    public bool startRandomlyEachIteration = true;
}
