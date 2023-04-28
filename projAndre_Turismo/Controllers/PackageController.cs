using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Models;
using projAndre_Turismo.Services;

namespace projAndre_Turismo.Controllers
{
    public class PackageController
    {
        public bool Insert(Package package)
        {
            return new PackageService().Insert(package);
        }

        public List<Package> FindAll()
        {
            return new PackageService().FindAll();
        }

        public bool Update(int Id, Package package)
        {
            return new PackageService().Update(Id, package);
        }

        public bool Delete(int Id)
        {
            return new PackageService().Delete(Id);
        }
    }
}
