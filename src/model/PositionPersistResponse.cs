namespace Bredex1.src.model
{
    public class PositionPersistResponse
    {
        public PositionPersistResponse(Guid id, PositionDBData position) 
        {  
            URL = "http://localhost:5259/position/" + id;
            Position = position;
        }

        public string URL { get; }
        public PositionDBData Position { get; }
    }
}