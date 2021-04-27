using System;
using UnityEngine;

namespace Code
{
    public class PlayerController
    {
       public Player model { get; private set; }

       public PlayerController(Player model)
       {
           this.model = model;
       }

       public void Execute()
       {
           if (Input.GetKey(KeyCode.UpArrow))
                   model.Move();
           if (Input.GetAxis("Horizontal")!=0)
               model.Rotation(Input.GetAxis("Horizontal"));
       }
    }
}