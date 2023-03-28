using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul6_1302213120
{
    public class SayaTubeUser
    {
        public int id;
        public List<SayaTubeVideo> uploadedVideos = new List<SayaTubeVideo>();
        public string Username;
        private string username;
        private SayaTubeVideo[] videoList = new SayaTubeVideo[8];
        private int videoCount;

        public SayaTubeUser(string username)
        {
            this.id = new Random().Next(10000, 99999);
            this.Username = username;
        }

        public int GetTotalVideoPlayCount()
        {
            int totalPlayCount = 0;
            foreach (SayaTubeVideo video in uploadedVideos)
            {
                totalPlayCount += video.playCount;
            }
            return totalPlayCount;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].title}");
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                Contract.Requires(value != null, "Nama username tidak boleh null.");
                Contract.Requires(value.Length <= 100, "Nama username tidak boleh lebih dari 100 karakter.");
                username = value;
            }
        }

        public void AddVideo(SayaTubeVideo video)
        {
            Contract.Requires(video != null, "Video yang ditambahkan tidak boleh null.");
            Contract.Requires(video.PlayCount < int.MaxValue, "Play count video melebihi batas integer maksimal.");
            videoList[videoCount++] = video;
        }

        public void PrintAllVideoPlayCount()
        {
            Contract.Ensures(videoCount <= 8, "Jumlah video maksimal yang di-print adalah 8.");
            for (int i = 0; i < videoCount; i++)
            {
                Console.WriteLine("{0}: {1}", videoList[i].Judul, videoList[i].PlayCount);
            }
        }

    }

    public class SayaTubeVideo
    {
        public int id;
        public string title;
        public int playCount;
        private string judul;

        public SayaTubeVideo(string title)
        {
            this.id = new Random().Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            this.playCount += count;
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Judul: {title}");
            Console.WriteLine($"Play Count: {playCount}");
        }

        public string Judul
        {
            get { return judul; }
            set
            {
                Contract.Requires(value != null, "Judul video tidak boleh null.");
                Contract.Requires(value.Length <= 200, "Judul video tidak boleh lebih dari 200 karakter.");
                judul = value;
            }
        }

        public int PlayCount
        {
            get { return playCount; }
            set
            {
                Contract.Requires(value >= 0, "Input play count tidak boleh negatif.");
                Contract.Requires(value + playCount <= 25000000, "Input play count melebihi batas maksimal.");
                try
                {
                    checked
                    {
                        playCount += value;
                    }
                }
                catch (OverflowException)
                {
                    throw new Exception("Jumlah play count melebihi batas maksimal.");
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeUser user = new SayaTubeUser("praktikan");
            SayaTubeVideo video1 = new SayaTubeVideo("Review Film Avengers: Endgame oleh praktikan");
            SayaTubeVideo video2 = new SayaTubeVideo("Review Film Spider-Man: No Way Home oleh praktikan");
            SayaTubeVideo video3 = new SayaTubeVideo("Review Film The Dark Knight oleh praktikan");
            SayaTubeVideo video4 = new SayaTubeVideo("Review Film Inception oleh praktikan");
            SayaTubeVideo video5 = new SayaTubeVideo("Review Film Interstellar oleh praktikan");
            SayaTubeVideo video6 = new SayaTubeVideo("Review Film Joker oleh praktikan");
            SayaTubeVideo video7 = new SayaTubeVideo("Review Film The Shawshank Redemption oleh praktikan");
            SayaTubeVideo video8 = new SayaTubeVideo("Review Film Fight Club oleh praktikan");
            SayaTubeVideo video9 = new SayaTubeVideo("Review Film The Matrix oleh praktikan");
            SayaTubeVideo video10 = new SayaTubeVideo("Review Film Pulp Fiction oleh praktikan");

            video1.PrintVideoDetails();
            video2.PrintVideoDetails();
            video3.PrintVideoDetails();
            video4.PrintVideoDetails();
            video5.PrintVideoDetails();
            video6.PrintVideoDetails();
            video7.PrintVideoDetails();
            video8.PrintVideoDetails();
            video9.PrintVideoDetails();
            video10.PrintVideoDetails();

            user.AddVideo(video1);
            user.AddVideo(video2);
            user.AddVideo(video3);
            user.AddVideo(video4);
            user.AddVideo(video5);
            user.AddVideo(video6);
            user.AddVideo(video7);
            user.AddVideo(video8);
            user.AddVideo(video9);
            user.AddVideo(video10);

            video1.IncreasePlayCount(100);
            video2.IncreasePlayCount(200);
            video3.IncreasePlayCount(300);
            video4.IncreasePlayCount(400);
            video5.IncreasePlayCount(500);

            // Menguji prekondisi
            var video = new SayaTubeVideo();
            video.Judul = "Video dengan judul lebih dari 200 karakter, seharusnya gagal";
            video.PlayCount = -100;
            var user = new SayaTubeUser();
            user.Username = null;

            // Menguji exception
            video.PlayCount = int.MaxValue;
            try
            {
                video.PlayCount = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Menguji postcondition
            user.AddVideo(new SayaTubeVideo { Judul = "Video 1", PlayCount = 100 });
            user.AddVideo(new SayaTubeVideo { Judul = "Video 2", PlayCount = 200 });
            user.AddVideo(new SayaTubeVideo { Judul = "Video 3", PlayCount = 300 });
            user.AddVideo(new SayaTubeVideo { Judul = "Video 4", PlayCount = 400 });
            user.AddVideo(new SayaTubeVideo { Judul = "Video 5", PlayCount = 500 });
            user.AddVideo(new SayaTubeVideo { Judul = "Video 6", PlayCount = 600 });
        }
    }
}