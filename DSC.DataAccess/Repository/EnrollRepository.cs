using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.DataAccess.Repository
{
    public class EnrollRepository : Repository<Enroll>, IEnrollRepository
    {
        public EnrollRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}