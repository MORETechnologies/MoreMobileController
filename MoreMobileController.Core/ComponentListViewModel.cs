using System;
using System.Collections.Generic;

namespace MoreMobileController.Core
{
    public class ComponentListViewModel
    {
        IBotClient client;

        public ComponentListViewModel(IBotClient client)
        {
            this.client = client;

            Components = new List<MotorComponentViewModel>();
        }

        public List<MotorComponentViewModel> Components { get; private set; }

        public MotorComponentViewModel AddComponent()
        {
            MotorComponentViewModel componentViewModel = new MotorComponentViewModel(client);
            Components.Add(componentViewModel);

            return componentViewModel;
        }

        public void RemoveComponent(MotorComponentViewModel componentViewModel)
        {
            Components.Remove(componentViewModel);
        }
    }
}
