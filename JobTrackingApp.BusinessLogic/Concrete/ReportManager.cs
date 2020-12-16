using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class ReportManager: IReportService
    {
        private readonly EfReportRepository _efReportRepository;

        public ReportManager(EfReportRepository efReportRepository)
        {
            _efReportRepository = efReportRepository;
        }
        
        public void Add(Report entity)
        {
            _efReportRepository.Add(entity);
        }

        public void Delete(Report entity)
        {
            _efReportRepository.Delete(entity);
        }

        public void Update(Report entity)
        {
            _efReportRepository.Update(entity);
        }

        public Report Get(int Id)
        {
            return _efReportRepository.Get(Id);
        }

        public List<Report> GetAll()
        {
            return _efReportRepository.GetAll();
        }
    }
}