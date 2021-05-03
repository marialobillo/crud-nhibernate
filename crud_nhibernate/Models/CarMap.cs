using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_nhibernate.Models
{
    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Id(c => c.CarId);
            Map(c => c.Name);
            Map(c => c.Registration);
            Table("Cars");
        }
    }
}
