using System;
using System.Collections.Generic;
using System.Text;

namespace Xyh.It.Helper.Dto
{
    public class AbpJsonResult<T>
    {
        public bool Success { get; set; }
        public string TargetUrl { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public string Error { get; set; }

        public bool __Abp { get; set; }

        public T Result { get; set; }
    }
}
