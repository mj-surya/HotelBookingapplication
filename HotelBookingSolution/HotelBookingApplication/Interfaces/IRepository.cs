namespace HotelBookingApplication.Interfaces
{
    public interface IRepository<K, T>
    {
        /// <summary>
        /// Gets details w.r.t key value
        /// </summary>
        /// <param name="key">Primary key</param>
        /// <returns>Returns details of the user</returns>
        T GetById(K key);
        /// <summary>
        /// Gets all the available data in a list
        /// </summary>
        /// <returns>Returns a list of all data</returns>
        IList<T> GetAll();
        /// <summary>
        /// Adds an data into existing table
        /// </summary>
        /// <param name="entity">New data to add</param>
        /// <returns>Returns a message</returns>
        T Add(T entity);
        /// <summary>
        /// Updates the existing data
        /// </summary>
        /// <param name="entity">new data that should be updated</param>
        /// <returns>Returns a message</returns>
        T Update(T entity);
        /// <summary>
        /// Deletes a data from existing table
        /// </summary>
        /// <param name="key">Primary key</param>
        /// <returns>Returns a message</returns>
        T Delete(K key);
    }
}
