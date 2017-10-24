using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;

namespace Kuriimu.ViewModels
{
    public sealed class TextEditorViewModel : Screen
    {
        public TextEditorViewModel()
        {
            DisplayName = "Text Editor";
            AddEntry();
            SelectedEntry = Entries.First();
        }

        public class Entry
        {
            public string Label { get; set; }
            public string Text { get; set; }
            public Entry(string label, string text)
            {
                Label = label;
                Text = text;
            }
        }

        public ObservableCollection<Entry> Entries { get; set; } = new ObservableCollection<Entry>();

        Entry _selectedEntry;
        public Entry SelectedEntry
        {
            get => _selectedEntry;
            set
            {
                _selectedEntry = value;
                EntryText = _selectedEntry.Text;
                NotifyOfPropertyChange(() => SelectedEntry);
            }
        }

        public string EntryText
        {
            get => _selectedEntry?.Text;
            set
            {
                if (_selectedEntry == null) return;
                _selectedEntry.Text = value;
                NotifyOfPropertyChange(() => EntryText);
            }
        }

        public string EntryCount => Entries.Count + (Entries.Count > 1 ? " Entries" : " Entry");

        public void AddEntry()
        {
            Entries.Add(new Entry($"Label {Entries.Count}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
            NotifyOfPropertyChange(nameof(EntryCount));
        }
    }
}
