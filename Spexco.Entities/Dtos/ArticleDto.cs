using Spexco.Entities.Concrete;
using Spexco.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spexco.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
        //public override ResultStatus ResultStatus { get; set; } = ResultStatus.Success;
    }
}
