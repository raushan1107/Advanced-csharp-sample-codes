namespace EandDLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "myvideo.mp4" }; // videos..
            var videoEncoder = new VideoEncoder(); // Publisher
            var mailser = new MailService(); // subscriber
            var whatsapp = new WhatsappService(); // another subscriber
            var txt = new Text(); // another subscriber

            videoEncoder.VideoEncoded += mailser.onVideoEncoded; // if event has occured, use this service
            videoEncoder.VideoEncoded += whatsapp.onVideoEncoded;
            videoEncoder.VideoEncoded += txt.onVideoEncoded;
            videoEncoder.EnCoder(video);
            Console.WriteLine("\n\nThank you for Using Raushan's Video Encoder!");
        }
    }
}
