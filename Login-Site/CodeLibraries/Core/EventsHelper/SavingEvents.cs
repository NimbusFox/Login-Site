using System.Linq;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace NimbusFox.Login_Site.CodeLibraries.Core.EventsHelper {
    public class SavingEvents {
        public static void RunEvents(IContentService sender, SaveEventArgs<IContent> saveEventArgs) {
            var entities = saveEventArgs.SavedEntities;

            foreach (var entity in entities) {
                if (!saveEventArgs.Cancel) {
                }
            }
        }
    }
}