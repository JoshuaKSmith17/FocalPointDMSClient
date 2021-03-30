using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.ViewModels.MainView.EquipmentVm
{
    class EquipmentMainViewModel : MainViewModel
    {
        public EquipmentMainViewModel() : base()
        {

            EntityType = EntityType.Equipment;

            // Sets the MainViewModel application property to this particular instance.
            Application.Current.Properties["MainViewModel"] = this;
        }
    }
}
