using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SRWMG : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero; //시작위치, 벡터와 같게 설정

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true; //기본값 true
                                                   //기본적으로 반복 횟수는 랜덤워크 알고리즘을 실행하려는 반복 횟수가 


    public void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosiotions = RunRandomWalk();
        foreach ( var position in floorPosiotions )
        {
            Debug.Log(position);
        }
    }
    protected HashSet<Vector2Int> RunRandomWalk()
    {
        //throw new NotImplementedException();
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>(); 
        for (int i = 0; i < iterations; i++)
        {
            var path = PGA.simpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }
}
