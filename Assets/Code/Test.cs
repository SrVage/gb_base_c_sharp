using System;
using UnityEngine;

namespace Code
{
    public class Test:MonoBehaviour
    {
        private void Start()
        {
            var bonus = new ListOfBonus();
            for (int i = 0; i < bonus.Count; i++)
            {
                print($"{bonus[i]}");
            }
            print("+++++++++");
            var trap = new ListOfTrap();
            for (int i = 0; i < trap.Count; i++)
            {
                print($"{trap[i]}");
            }
        }
    }
}