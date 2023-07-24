using FormsApp.Core.Models.Base;

using System.Collections.Generic;
using System.Data;

namespace FormsApp.Core.Repos.Base
{
    public interface IRepo<T>
        where T : Model
    {
        #region Methods

        /// <summary>
        /// Returns list of all the records
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Gets record for the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Updates the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        void Update(int id, T model);

        /// <summary>
        /// Updates multiple items
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="models"></param>
        void UpdateAll(List<int> ids, List<T> models);

        /// <summary>
        /// Creates the model with the specified id
        /// </summary>
        /// <param name="model"></param>
        T Create(T model);

        /// <summary>
        /// Deletes the model with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        #endregion
    }
}
