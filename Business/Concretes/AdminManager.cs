using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this._adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public List<Admin> GetListAll()
        {
           return _adminDal.GetListAll();
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
