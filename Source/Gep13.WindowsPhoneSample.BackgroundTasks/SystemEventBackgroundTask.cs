﻿namespace Gep13.WindowsPhoneSample.BackgroundTasks
{
    using Gep13.WindowsPhoneSample.Core.Mappers;
    using Gep13.WindowsPhoneSample.Core.Repository;
    using Windows.ApplicationModel.Background;
    using Windows.Storage;

    public sealed class SystemEventBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();

            AutoMapperConfiguration.Configure(null);

            var jobRepository = new JobRepository();
            var jobs = jobRepository.GetJobsByJourneyId(1);

            foreach (var job in jobs)
            {
                jobRepository.UpdateJobStatus(job.Id, "ACCEPTED");
            }

            deferral.Complete();
        }
    }
}