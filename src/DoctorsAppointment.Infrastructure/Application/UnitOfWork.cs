using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Infrastructure.Application
{
    public interface UnitOfWork
    {
        void Commit();
    }
}
