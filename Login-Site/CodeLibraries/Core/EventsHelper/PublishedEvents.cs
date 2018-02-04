using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;

namespace NimbusFox.Login_Site.CodeLibraries.Core.EventsHelper {
    public static class PublishedEvents {
        public static void RunEvents(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs) {
            var entities = publishEventArgs.PublishedEntities;

            foreach (var entity in entities) {
            }
        }
    }
}