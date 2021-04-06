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
            RecordDeleteCommand = new DeleteEquipmentCommand();

        }
    }
}
