namespace AvnonDemo.Domain.Core
{
    /// <summary>
    /// Interface for entities with an Id
    /// </summary>
    public interface IId
    {
        /// <summary> 
        /// This is the Id of the object.
        /// Usually for objects persisted in the DB
        /// </summary>
        int Id { get; set; }
    }
}