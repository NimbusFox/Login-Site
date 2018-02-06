using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;

namespace NimbusFox.Login_Site.CodeLibraries.Core.EventsHelper {
    public class UnPublishingEvents {
        public static void RunEvents(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs) {
            var entities = publishEventArgs.PublishedEntities;

            foreach (var entity in entities) {
                if (!publishEventArgs.Cancel) {
                    AjaxGatewayCheck(entity, publishEventArgs);
                }
            }
        }

        private static void AjaxGatewayCheck(IContent entity, PublishEventArgs<IContent> publishEventArgs) {
            if (!publishEventArgs.Cancel) {
                if (entity.ContentType.Alias.ToLower() == "ajaxgateway") {
                    publishEventArgs.CancelOperation(new EventMessage("Can't unpublish key node", "You cannot unpublish an ajax gateway as it will break the site", EventMessageType.Error));
                }
            }
        }
    }
}