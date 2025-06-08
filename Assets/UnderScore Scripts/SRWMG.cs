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
    private SRWD randomWalkParameters;

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
        for (int i = 0; i < randomWalkParameters.iteration; i++) 
        {
            var path = PGA.simpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);
            if (randomWalkParameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }
}
