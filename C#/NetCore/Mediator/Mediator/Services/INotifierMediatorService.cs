using System.Collections.Generic;
using System.Linq;

namespace Mediator.Services
{
    public interface INotifierMediatorService
    {
        void Notify();
    }

    public class NotifierMediatorService : INotifierMediatorService
    {

        private readonly IEnumerable<INotifier> _notifiers;

        /// <summary>
        /// Utilizing IEnumerable pattern
        /// </summary>
        /// <param name="notifiers"></param>
        public NotifierMediatorService(IEnumerable<INotifier> notifiers)
        {
            _notifiers = notifiers;
        }

        public void Notify()
        {
            _notifiers.Where(x => x.CanRun()).ToList().ForEach(x => x.Notify());
        }
    }
}