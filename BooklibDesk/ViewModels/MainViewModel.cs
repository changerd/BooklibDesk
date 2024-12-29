using BooklibDesk.Data;
using BooklibDesk.Models;
using BooklibDesk.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BooklibDesk.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _newBookTitle;
        private string _newBookAuthor;
        private int _newBookYear;

        public string NewBookTitle
        {
            get => _newBookTitle;
            set { _newBookTitle = value; OnPropertyChanged(); }
        }

        public string NewBookAuthor
        {
            get => _newBookAuthor;
            set { _newBookAuthor = value; OnPropertyChanged(); }
        }

        public int NewBookYear
        {
            get => _newBookYear;
            set { _newBookYear = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Book> Books { get; set; }
        public Book SelectedBook { get; set; }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            Books = new ObservableCollection<Book>();
            AddCommand = new RelayCommand(AddBook);
            EditCommand = new RelayCommand(EditBook, () => SelectedBook != null);
            DeleteCommand = new RelayCommand(DeleteBook, () => SelectedBook != null);

            LoadBooksFromDatabase();
        }

        private void LoadBooksFromDatabase()
        {
            using (var context = new ApplicationDbContext())
            {
                Books.Clear();
                var books = context.Books.ToList();
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
        }

        private void AddBook()
        {
            if (!string.IsNullOrWhiteSpace(NewBookTitle) &&
                !string.IsNullOrWhiteSpace(NewBookAuthor) &&
                NewBookYear > 0)
            {
                var newBook = new Book
                {
                    Title = NewBookTitle,
                    Author = NewBookAuthor,
                    Year = NewBookYear
                };

                using (var context = new ApplicationDbContext())
                {
                    context.Books.Add(newBook);
                    context.SaveChanges();
                }

                LoadBooksFromDatabase();

                NewBookTitle = string.Empty;
                NewBookAuthor = string.Empty;
                NewBookYear = 0;
            }
        }

        private void EditBook()
        {
            if (SelectedBook != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var bookToUpdate = context.Books.FirstOrDefault(b => b.Id == SelectedBook.Id);
                    if (bookToUpdate != null)
                    {
                        bookToUpdate.Title = NewBookTitle;
                        bookToUpdate.Author = NewBookAuthor;
                        bookToUpdate.Year = NewBookYear;

                        context.SaveChanges();
                    }
                }

                LoadBooksFromDatabase();
            }
        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var bookToRemove = context.Books.FirstOrDefault(b => b.Id == SelectedBook.Id);
                    if (bookToRemove != null)
                    {
                        context.Books.Remove(bookToRemove);
                        context.SaveChanges();
                    }
                }

                LoadBooksFromDatabase();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
