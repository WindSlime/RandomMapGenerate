using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADG : MonoBehaviour
{
    [SerializeField]
    protected TMV tilemapVisualizer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
