using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media;
using Windows.System.Display;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<MusicLib> MusicList = new ObservableCollection<MusicLib>();

        public DisplayRequest appDisplayRequest { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

       
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            StorageFolder musicLib = KnownFolders.MusicLibrary;
            
            var files = await musicLib.GetFilesAsync();
            foreach (var file in files)
            {
                var musicProperties = await file.Properties.GetMusicPropertiesAsync();
                var artist = musicProperties.Artist;
                if (artist == "")
                    artist = "Artista desconocido";
                var album = musicProperties.Album;
                if (album == "")
                    album = "Unkown";
                MusicList.Add(new MusicLib { FileName = file.DisplayName, Artist = artist, Album = album, MusicFile = file });
            }

           

        }
       
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //mediaPlayer.Source = new Uri(listview.SelectedValuePath);

            var clickedItem = (MusicLib)e.ClickedItem;
            mediaPlayer.Source = MediaSource.CreateFromStorageFile(clickedItem.MusicFile);
            mediaPlayer.MediaPlayer.Play();
            //mediaPlayer.MediaPlayer.Pause();
            


        }


    }
}
