namespace Magnus.Futbot.Database
{
    internal class BackgroundWorker : BackgroundService
    {
        private readonly AddProfilesWorker _addProfilesWorker;
        private readonly PlayersWorker _playersWorker;

        public BackgroundWorker(AddProfilesWorker addProfilesWorker,
            PlayersWorker playersWorker)
        {
            _addProfilesWorker = addProfilesWorker;
            _playersWorker = playersWorker;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var task1 = Task.Run(async () =>
            {
                await _addProfilesWorker.ExecuteAsync(stoppingToken);
            }, stoppingToken);

            var task2 = Task.Run(async () =>
            {
                await _playersWorker.ExecuteAsync(stoppingToken);
            }, stoppingToken);

            Task.WaitAll(new Task[] { task1, task2 }, cancellationToken: stoppingToken);

            return task1;
        }
    }
}
