using System;
using System.Collections.Generic;
using System.Text;
using static AutoMapper.Internal.ExpressionFactory;

namespace Tennis.BLL.Interface
{
    public interface IMemberService : IGenericService<Member, int>
    {
    }
}
