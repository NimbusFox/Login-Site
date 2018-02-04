using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;

namespace Login_Site.CodeLibraries.Core.EventsHelper {
    public static class PublishedEvents {
        public static void RunEvents(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs) {
            var entities = publishEventArgs.PublishedEntities;

            foreach (var entity in entities) {
                AjaxGatewayCheck(entity);

            }
        }

        private static void AjaxGatewayCheck(IContent entity) {
            if (entity.ContentType.Alias.ToLower() == "site") {
                if (!entity.Children().Any(child => child.ContentType.Alias.ToLower() == "ajaxgateway")) {
                    var cs = ApplicationContext.Current.Services.ContentService;

                    var content = cs.CreateContent("API", entity.Id, "ajaxGateway");

                    cs.SaveAndPublishWithStatus(content);
                }
            }
        }
    }
}