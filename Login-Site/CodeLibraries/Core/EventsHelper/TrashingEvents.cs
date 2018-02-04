using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace NimbusFox.Login_Site.CodeLibraries.Core.EventsHelper {
    public class TrashingEvents {
        public static void RunEvents(IContentService sender, MoveEventArgs<IContent> moveEventArgs) {
            var entities = moveEventArgs.MoveInfoCollection;

            foreach (var entity in entities) {
                if (!moveEventArgs.Cancel) {
                }
            }
        }
    }
}