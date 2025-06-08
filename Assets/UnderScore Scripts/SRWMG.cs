using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SRWMG : ADG
{

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true; //�⺻�� true
                                                   //�⺻������ �ݺ� Ƚ���� ������ũ �˰����� �����Ϸ��� �ݺ� Ƚ���� 


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosiotions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPosiotions);
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
