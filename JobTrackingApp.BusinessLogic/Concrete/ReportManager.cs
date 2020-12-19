using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class ReportManager: IReportService
    {
        private readonly IReportDAL _reportDal;

        public ReportManager(IReportDAL reportDal)
        {
            _reportDal = reportDal;
        }
        
        public void Add(Report entity)
        {
            _reportDal.Add(entity);
        }

        public void Delete(Report entity)
        {
            _reportDal.Delete(entity);
        }

        public void Update(Report entity)
        {
            _reportDal.Update(entity);
        }

        public Report Get(int Id)
        {
            return _reportDal.Get(Id);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }
    }
}