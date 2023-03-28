using System;
using System.Collections.Generic;
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
    }

    public class SayaTubeVideo
    {
        public int id;
        public string title;
        public int playCount;

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
    }

    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeUser user = new SayaTubeUser("walid");
            SayaTubeVideo video1 = new SayaTubeVideo("Review Film Avengers: Endgame oleh walid");
            SayaTubeVideo video2 = new SayaTubeVideo("Review Film Spider-Man: No Way Home oleh walid");
            SayaTubeVideo video3 = new SayaTubeVideo("Review Film The Dark Knight oleh walid");
            SayaTubeVideo video4 = new SayaTubeVideo("Review Film Inception oleh walid");
            SayaTubeVideo video5 = new SayaTubeVideo("Review Film Interstellar oleh walid");
            SayaTubeVideo video6 = new SayaTubeVideo("Review Film Joker oleh walid");
            SayaTubeVideo video7 = new SayaTubeVideo("Review Film The Shawshank Redemption oleh walid");
            SayaTubeVideo video8 = new SayaTubeVideo("Review Film Fight Club oleh walid");
            SayaTubeVideo video9 = new SayaTubeVideo("Review Film The Matrix oleh walid");
            SayaTubeVideo video10 = new SayaTubeVideo("Review Film Pulp Fiction oleh walid");
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
            video6.IncreasePlayCount(600);
            video7.IncreasePlayCount(700);
            video8.IncreasePlayCount(800);
            video9.IncreasePlayCount(900);
            video10.IncreasePlayCount(1000);
        }
    }
}