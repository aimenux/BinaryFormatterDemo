namespace App.Serializers
{
    public interface IBinarySerializer
    {
        void Serialize<T>(T obj);
        T Deserialize<T>();
    }
}