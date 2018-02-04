using System.Linq;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace Login_Site.CodeLibraries.Core.EventsHelper {
    public class SavingEvents {
        public static void RunEvents(IContentService sender, SaveEventArgs<IContent> saveEventArgs) {
            var entities = saveEventArgs.SavedEntities;

            foreach (var entity in entities) {
                if (!saveEventArgs.Cancel) {
                    AjaxGatewayCheck(entity, saveEventArgs);
                }
            }
        }

        private static void AjaxGatewayCheck(IContent entity, SaveEventArgs<IContent> eventArgs) {
            if (entity.ContentType.Alias.ToLower() == "ajaxgateway") {
                var parent = entity.Parent();
                if (parent.Children().Any(child => child.ContentType.Alias.ToLower() == "ajaxgateway") && !entity.Published) {
                    eventArgs.CancelOperation(new EventMessage("Item already Exists", "There cannot be two ajax gateways", EventMessageType.Warning));
                }
            }
        }
    }
}