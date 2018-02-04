using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace NimbusFox.Login_Site.CodeLibraries.Core.EventsHelper {
    public class DeletingEvents {
        public static void RunEvents(IContentService sender, DeleteEventArgs<IContent> deleteEventArgs) {
            var entities = deleteEventArgs.DeletedEntities;

            foreach (var entity in entities) {
                if (!deleteEventArgs.Cancel) {
                }
            }
        }
    }
}