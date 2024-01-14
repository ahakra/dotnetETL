namespace ServiceMesh.Entities
{
    public class ServiceInfoEntity
    {
        public string Id { get; set; }
       // public string ServiceId { get; set; }
        public string ServiceType { get; set; }
        public DateTime Timestamp { get; set; }
        // Navigation property for the related ServiceAdapters
        public ICollection<ServiceAdapterEntity>? Adapters { get; set; }
    }
}
