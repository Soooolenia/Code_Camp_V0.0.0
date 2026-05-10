using System;
using UnityEngine;

public class ConstrainManager : MonoBehaviour
{
    [SerializeField] private Constrain constrainA;
    [SerializeField] private Constrain constrainB;

    public void Check()
    {
        if (constrainA.IsConstrainBroken == true && constrainB.IsConstrainBroken == true)
        {
            Debug.Log("You are dead, the monster got out!");
        }
    }
}
