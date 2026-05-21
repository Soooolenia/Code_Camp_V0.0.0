using System;
using UnityEngine;

public class ConstrainManager : MonoBehaviour
{
    [SerializeField] private Constrain constrainA;
    [SerializeField] private Constrain constrainB;

    [SerializeField] private WinLoseManager winLoseManager;

    public void Check()
    {
        if (constrainA.State == ConstraintState.Broken && constrainB.State == ConstraintState.Broken)
        {
            Debug.Log("You are dead, the monster got out!");
            winLoseManager.Lose();
        }
    }
}
