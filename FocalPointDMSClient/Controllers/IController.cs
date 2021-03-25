using System.Data;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Controllers
{
    interface IController
    {
        public DataTable BuildTable();
        public void UpdateRecord(IDbObject item);
    }
}
