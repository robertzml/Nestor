using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Models.Entities;

namespace Nestor.Data
{
    /// <summary>
    /// 栏目Repository
    /// </summary>
    public interface IColumnRepository
    {
        Column Create(Column data);
    }
}
