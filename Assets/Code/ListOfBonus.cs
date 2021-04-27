using System;
using System.Collections;

namespace Code
{
    public sealed class ListOfBonus: IEnumerator, IEnumerable
    {
        private Bonus[] _bonus;
        private Bonus _currrentBonus;
        private int _index = -1;

        public ListOfBonus()
        {
            _bonus = UnityEngine.Object.FindObjectsOfType<Bonus>();
            
        }

        public Bonus this [int index]
        {
            get => _bonus[index];
            set => _bonus[index] = value;
        }

        public int Count => _bonus.Length;
        
        
        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public object Current { get; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
        
    }
    
    
    public sealed class ListOfTrap: IEnumerator, IEnumerable
    {
        private Trap[] _trap;
        private Trap _currrentTrap;
        private int _index = -1;

        public ListOfTrap()
        {
            _trap = UnityEngine.Object.FindObjectsOfType<Trap>();
        }

        public Trap this [int index]
        {
            get => _trap[index];
            set => _trap[index] = value;
        }

        public int Count => _trap.Length;
        
        
        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public object Current { get; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
        
    }
    
}