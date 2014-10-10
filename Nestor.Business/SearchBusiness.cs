using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Data;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.Business
{
    /// <summary>
    /// 搜索业务类
    /// </summary>
    public class SearchBusiness
    {
        #region Method
        /// <summary>
        /// 搜索标题
        /// </summary>
        /// <param name="text">搜索文本</param>
        /// <returns></returns>
        public List<Article> SearchByTitle(string text)
        {
            ArticleRepository artcileRepository = new ArticleRepository();
            var data = artcileRepository.Get();

            var result = from r in data
                         where r.Title.Contains(text)
                         select r;

            return result.ToList();
        }
        #endregion //Method
    }
}
