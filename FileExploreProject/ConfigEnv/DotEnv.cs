namespace FileExploreProject.ConfigEnv
{
    public class DotEnv
    {
        public string Load()
        {
            var root = Directory.GetCurrentDirectory();
            var path = Path.Combine(root, ".env");

            DotNetEnv.Env.Load(path);
            string message = Environment.GetEnvironmentVariable("NAME");
            return message;
        }
    }
}
