using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DDD.WPF.Services
{
    public sealed class MessageService : IMessageService
    {
        public MessageBoxResult Question(string message)
        {
            return MessageBox.Show(
                message,
                "問い合わせ",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Question);
        }

        public void ShowDialog(string message)
        {
            MessageBox.Show(message);
        }
    }
}
