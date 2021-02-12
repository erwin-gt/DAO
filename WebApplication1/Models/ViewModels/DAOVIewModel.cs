using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class DAOVIewModel
    {
        public IEnumerable<DAO> dao { get; set }
        public DAO DAOList { get; set; }
    }
}
