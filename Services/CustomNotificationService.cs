using AntDesign;
using IdentityBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace IdentityBlazor.Services
{
    public sealed class CustomNotificationService : IDisposable
    {
        private readonly NotificationService _notificationService;
        public CustomNotificationService(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        private static RenderFragment Title(string leftTitle, string rightTitle) => (builder) =>
        {
            builder.OpenComponent<Paragraph>(0);
            builder.AddAttribute(1, "Class", "flex-between");
            builder.AddAttribute(2, "ChildContent", BuildTitle(leftTitle, rightTitle));
            builder.CloseComponent();
        };
        private static RenderFragment Alert(string messageAlert, string? descriptionAlert) => (builder) =>
        {
            builder.OpenComponent<Text>(0);
            builder.AddAttribute(1, "Strong", true);
            builder.AddAttribute(2, "ChildContent", BuildString(messageAlert));

            builder.CloseComponent();
            if (!string.IsNullOrEmpty(descriptionAlert))
            {
                builder.OpenComponent<ParagraphExpand>(3);
                builder.AddAttribute(4, "Value", descriptionAlert);
                builder.AddAttribute(5, "BreakLength", 140);
                builder.AddAttribute(6, "ButtonText", "Xem thêm");
                builder.CloseComponent();
            }
        };
        private static RenderFragment BuildString(string input) => (builder) =>
        {
            builder.AddContent(0, input);
        };
        private static RenderFragment BuildTitle(string leftTitle, string rightTitle) => (builder) =>
        {
            builder.OpenComponent<Text>(0);
            builder.AddAttribute(2, "ChildContent", BuildString(leftTitle));
            builder.CloseComponent();
            builder.OpenComponent<Text>(2);
            builder.AddAttribute(3, "Class", "notification-time");
            builder.AddAttribute(4, "ChildContent", BuildString(rightTitle));
            builder.CloseComponent();
        };
        public async Task Error(string title, string messageAlert, string? descriptionAlert = null, double? duration = null)
        {
            await _notificationService.Open(new NotificationConfig()
            {
                Message = Title(title, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                Description = Alert(messageAlert, descriptionAlert),
                NotificationType = NotificationType.Error,
                Duration = duration,
                ClassName = "ant-alert-error"
            });
        }
        public async Task Success(string title, string messageAlert, string? descriptionAlert = null, double? duration = null)
        {
            await _notificationService.Open(new NotificationConfig()
            {
                Message = Title(title, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                Description = Alert(messageAlert, descriptionAlert),
                NotificationType = NotificationType.Success,
                Duration = duration,
                ClassName = "ant-alert-success"
            });
        }
        public async Task Info(string title, string messageAlert, string? descriptionAlert = null, double? duration = null)
        {
            await _notificationService.Open(new NotificationConfig()
            {
                Message = Title(title, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                Description = Alert(messageAlert, descriptionAlert),
                NotificationType = NotificationType.Info,
                Duration = duration,
                ClassName = "ant-alert-info"
            });
        }

        public void Dispose()
        {
            // Clean up resources...
        }
    }
}
