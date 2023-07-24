namespace FormsApp.Core.Interfaces
{
    public interface ITransformable<T>
        where T: class
    {
        #region Methods

        /// <summary>
        /// Provides a transformation to the specified class
        /// </summary>
        /// <returns></returns>
        T Transform();

        #endregion
    }
}
