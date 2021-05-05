using System;
using UnityEngine;

namespace Code
{
    public sealed class PlayerController:IExecute
    {
        public event Action DestroyPlayer;
        private Player model;

       public PlayerController(GameObject model)
       {
           this.Model = model.GetComponent<Player>();
       }

       public Player Model
       {
           get => model;
           set => model = value;
       }

       public void Execute(float deltaTime)
       {
           if (model==null) return;
           if (model.HP<=0) EndOfGame();
           if (Input.GetKey(KeyCode.UpArrow))
                   Model.Move();
           if (Input.GetAxis("Horizontal")!=0)
               Model.Rotation(Input.GetAxis("Horizontal"));
       }
       
       private void EndOfGame() //завершение игры
       {
           DestroyPlayer?.Invoke();
           GameObject.Destroy(Model);
       }
    }
}