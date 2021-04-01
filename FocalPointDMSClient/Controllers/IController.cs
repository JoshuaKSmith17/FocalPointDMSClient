using System.Data;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Controllers
{
    interface IController
    {
        public DataTable GetAllRecords();
        public void UpdateRecord(DbObject item);
    }
}
