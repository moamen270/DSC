using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.DataAccess.Repository
{
    public class CourseInfoRepository : Repository<CourseInfo>, ICourseInfoRepository
    {
        public CourseInfoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}