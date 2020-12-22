using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO;
using Tennis.DTO.Interface;

namespace Tennis.BLL.Service
{
    public interface IGenericService<
        TBase,
        TID,
        TRead,
        TCreate,
        TUpdate>
        where TCreate : IDTO
        where TRead : IDTO
        where TUpdate : IDTO
    {
        public IEnumerator<TRead> GetAll();
        public TRead GetById(TID id);
        public void Update(TUpdate update);
        public void Create(TCreate create);
    }
}
