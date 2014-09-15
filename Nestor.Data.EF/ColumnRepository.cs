using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Data;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.Data.EF
{
    public class ColumnRepository : IColumnRepository
    {
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
    }
}
