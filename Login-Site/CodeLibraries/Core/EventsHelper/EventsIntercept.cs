using NimbusFox.Login_Site.CodeLibraries.Core.EventsHelper;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace NimbusFox.Login_Site.CodeLibraries.Core.EventsHelper {
    public class EventsIntercept : ApplicationEventHandler {
        public EventsIntercept() {
            ContentService.Saving += OnSave;
            ContentService.Published += OnPublished;
            ContentService.Deleting += OnDeleting;
            ContentService.Trashing += OnTrashing;
            ContentService.UnPublishing += OnUnPublishing;
        }

        private static void OnUnPublishing(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs) {
            UnPublishingEvents.RunEvents(sender, publishEventArgs);
        }

        private static void OnTrashing(IContentService sender, MoveEventArgs<IContent> moveEventArgs) {
            TrashingEvents.RunEvents(sender, moveEventArgs);
        }

        private static void OnDeleting(IContentService sender, DeleteEventArgs<IContent> deleteEventArgs) {
            DeletingEvents.RunEvents(sender, deleteEventArgs);
        }

        private static void OnPublished(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs) {
            PublishedEvents.RunEvents(sender, publishEventArgs);
        }

        private static void OnSave(IContentService sender, SaveEventArgs<IContent> saveEventArgs) {
            SavingEvents.RunEvents(sender, saveEventArgs);
        }
    }
}