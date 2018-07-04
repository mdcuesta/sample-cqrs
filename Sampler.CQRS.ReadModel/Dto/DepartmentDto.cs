using System;
using System.Collections.Generic;
using System.Text;

namespace Sampler.CQRS.ReadModel.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }
}
