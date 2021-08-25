using Core.Utilities.ElasticSearch.Models;
using Core.Utilities.Results;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ElasticSearch
{
    public interface IElasticSearch
    {
        Task<IResult> CreateNewIndexAsync(IndexModel indexModel);
        Task<IResult> InsertAsync(ElasticSearchInsertUpdateModel model);
        Task<IResult> InsertManyAsync(string indexName, object[] items);
        IReadOnlyDictionary<IndexName, IndexState> GetIndexList();

        Task<List<ElasticSearchGetModel<T>>> GetAllSearch<T>(SearchParameters parameters)
            where T : class;

        Task<List<ElasticSearchGetModel<T>>> GetSearchByField<T>(SearchByFieldsParameters fieldParameters)
            where T : class;

        Task<List<ElasticSearchGetModel<T>>> GetSearchBySimpleQueryString<T>(SearchByQueryParameters queryParameters)
            where T : class;

        Task<IResult> UpdateByElasticAsync(ElasticSearchInsertUpdateModel model);
        Task<IResult> DeleteElasticAsync(ElasticSearchModel model);

    }
}
