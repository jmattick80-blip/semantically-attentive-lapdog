namespace GalleryDrivers.Prism.Shared.DataPackages
{
    public class PrismResult
    {
        public string Message { get; set; }
        public object Payload { get; set; }

        public bool IsSuccess => Payload != null;

        public PrismResult(string message, object payload = null)
        {
            Message = message;
            Payload = payload;
        }

        public T GetPayload<T>() where T : class => Payload as T;
    }
}