using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetSystem.Services.Data.Contracts
{
    public interface IRatingsService
    {
        int Rate(int clinicId, string userId, int ratingValue);
    }
}
