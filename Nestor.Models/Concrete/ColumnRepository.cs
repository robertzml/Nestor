using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Models.Entities;

namespace Nestor.Models.Concrete
{
    public class ColumnRepository
    {
        #region Method
        public Column Create(Column data)
        {
            try
            {
                NestorEntities context = new NestorEntities();

                Column result = context.Columns.Add(data);

                return result;
                //return ErrorCode.Success;
            }
            catch (Exception e)
            {
                //return ErrorCode.Exception;
                return null;
            }
        }
        #endregion //Method
    }
}
