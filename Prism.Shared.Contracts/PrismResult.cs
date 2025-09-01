using System.Collections.Generic;

namespace Prism.Shared.Contracts
{
    public class PrismResult
    {
        public string Message { get; set; }
        public object Payload { get; set; }

        public bool IsSuccess => Payload != null;
        public bool HasError => Payload == null;
        public string Feedback { get; set; }
        public List<string> Tags { get; set; }


        public PrismResult(string message, object payload = null)
        {
            Message = message;
            Payload = payload;
        }

        public T GetPayload<T>() where T : class => Payload as T;

        public PrismResult Clone()
        {
            return new PrismResult(Message, Payload)
            {
                Feedback = Feedback,
                Tags = Tags != null ? new List<string>(Tags) : new List<string>()
            };
        }
    }
    #region PrismResult Summary (August 31, 2025)
    // PrismResult represents a contributor-facing response envelope.
    // It carries message, payload, emotional feedback, and semantic tags.
    // The Clone() method enables tone-aware modulation without mutating the original.
    // This stub supports Sprint 2’s empathy layer and prepares Prism for traceable consequence.
    #endregion
}