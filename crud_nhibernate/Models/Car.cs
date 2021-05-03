using System;
namespace crud_nhibernate.Models
{
    public class Car
    {
        public virtual int CarId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Registration { get; set; }

        
    }
}
