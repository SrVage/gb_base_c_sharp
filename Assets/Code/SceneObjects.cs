using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code
{
    
    public class SceneObjects : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>()) return;
            print(other.GetType());
            if (other.gameObject.GetComponent<ISetDamage>() != null)
            {
                print("Damage");
                other.GetComponent<ISetDamage>().Damage();
            }
            if (other.gameObject.GetComponent<INeedGetForWin>() != null)
            {
                print("Win");
                other.GetComponent<INeedGetForWin>().GetWinBonus();
            }

            other.gameObject.SetActive(false);
        }
    }
}