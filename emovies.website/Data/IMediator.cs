using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emovies.website.Data
{
    interface IMediator
    {
        void SendIDToWriter(int ID, TableWriter tableWriter);
    }
}
