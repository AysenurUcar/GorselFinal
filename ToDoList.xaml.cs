
using System.Collections.ObjectModel;
using System.Text.Json;
using Firebase.Auth;
using Firebase.Database;
using GorselFinal.Modeller;

namespace GorselFinal;

public partial class ToDoList : ContentPage
{
    public ToDoList()
    {
        InitializeComponent();

        BL.LoadNotes();

        toDoList.ItemsSource = BL.Notes;
    }

    static FirebaseClient client = new FirebaseClient("https://mauiappdeneme-default-rtdb.firebaseio.com/");


    void AddNote(Notes note)
    {
        BL.AddNote(note);
    }

    private async void Edit_Clicked(object sender, EventArgs e)
    {
        var m = sender as Button;
        var note = BL.Notes.First(o => o.Id == m.CommandParameter.ToString());

        string result = await DisplayPromptAsync("Notu D�zenle", "Notunuzu giriniz: ", "Tamam", "�ptal");

        if (result != null)
        {
            note.NoteContent = result;
            BL.EditNote(note);
        }
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var m = sender as Button;
        var note = BL.Notes.First(o => o.Id == m.CommandParameter.ToString());

        bool b = await DisplayAlert("Silmeyi Onayla", $"{note.NoteContent} notu silinsin mi?", "Evet", "Hay�r");

        if (b)
        {
            BL.DeleteNote(note);

        }

    }


    private async void NoteAdd_Clicked(object sender, EventArgs e)
    {
        Notes note;

        string noteContent = await DisplayPromptAsync("Not Ekle", "Notunuzu giriniz: ", "Tamam", "�ptal");

        if (noteContent != null)
        {
            note = new Notes()
            {
                NoteContent = noteContent
            };

            AddNote(note);
        }
    }
}