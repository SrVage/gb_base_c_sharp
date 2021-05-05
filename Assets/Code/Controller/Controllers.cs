using System.Collections.Generic;
using UnityEngine;

namespace Code.Controller
{
    public sealed class Controllers:IInitialization, IExecute, ILateUpdator
    {
        private List<IInitialization> _initializationList = new List<IInitialization>();
        private List<IExecute> _executeList = new List<IExecute>();
        private List<ILateUpdator> _lateUpdatorList = new List<ILateUpdator>();

        public Controllers Add(IController controller)
        {
            if (controller is IInitialization initialization)
            {
                _initializationList.Add(initialization);
            }
            if (controller is IExecute executor)
            {
                _executeList.Add(executor);
            }

            if (controller is ILateUpdator lator)
            {
                _lateUpdatorList.Add(lator);
            }
            return this;
        }
        
        public void Initialization()
        {
            foreach (var VAR in _initializationList)
            {
                VAR.Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var VAR in _executeList)
            {
                VAR.Execute(deltaTime);
            }
        }

        public void LateUpdator(float deltaTime)
        {
            foreach (var VAR in _lateUpdatorList)
            {
                VAR.LateUpdator(deltaTime);
            }
        }
    }
}