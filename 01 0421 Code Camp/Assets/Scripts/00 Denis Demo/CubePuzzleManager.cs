using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CubePuzzleManager : MonoBehaviour
{
    [SerializeField] List<RotatingCube> rotatingCubes;

    private void Awake()
    {
        // add all cubes to list (if not already in list)

        foreach (var cube in FindObjectsByType<RotatingCube>(FindObjectsSortMode.None))
        {
            if (!rotatingCubes.Contains(cube))
            {
                rotatingCubes.Add(cube);
            }
        }
    }

    public void CheckCubes()
    {
        foreach (var cube in rotatingCubes)
        {
            if (!cube.IsTargetReached) return;
        }
        Debug.Log("All cubes reached target!");
    }
}
