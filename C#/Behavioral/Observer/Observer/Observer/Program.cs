using System;
using System.Collections.Generic;

namespace Observer
{
    /// <summary>
    /// Defines a dependency between objects so that whenever an object changes 
    /// its state, all its dependents are notified.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            // create subscribers
            var johnDoe = new JobSeeker("John Doe");
            var janeDoe = new JobSeeker("Jane Doe");

            // create publisher and attach subscribers
            var jobPostings = new JobPostings();
            var johnDoeSubscription = jobPostings.Subscribe(johnDoe);
            jobPostings.Subscribe(janeDoe);

            // add a new job and see if subscribers get notified
            jobPostings.AddJob(new JobPost("Software Engineer"));

            // unsubscribe, notify Jane about DT role
            johnDoeSubscription.Dispose();
            jobPostings.AddJob(new JobPost("Design Technologist"));

            Console.ReadLine();
        }
    }

    /// <summary>
    /// First of all we have job seekers that need to be notified for 
    /// a job posting
    /// </summary>
    public class JobPost
    {
        public string Title { get; }

        public JobPost(string title)
        {
            Title = title;
        }
    }

    public class JobSeeker : IObserver<JobPost>
    {
        public string Name { get; }

        public JobSeeker(string name)
        {
            Name = name;
        }

        public void OnNext(JobPost value)
        {
            Console.WriteLine($"Hi {Name}! New job posted we think you'd be interested in: {value.Title}");
        }

        //Method is not being called by JobPostings class currently
        public void OnError(Exception error)
        {
            throw new NotImplementedException(nameof(error));
        }

        //Method is not being called by JobPostings class currently
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Then we have our job postings to which the job seekers will subscribe
    /// </summary>
    public class JobPostings : IObservable<JobPost>
    {
        private readonly List<IObserver<JobPost>> observers;
        private readonly List<JobPost> jobPostings;

        public JobPostings()
        {
            observers = new List<IObserver<JobPost>>();
            jobPostings = new List<JobPost>();
        }

        public IDisposable Subscribe(IObserver<JobPost> observer)
        {
            // Check whether observer is already registered. If not, add it!
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber<JobPost>(observers, observer);
        }

        private void Notify(JobPost jobPost)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(jobPost);
            }
        }

        public void AddJob(JobPost jobPost)
        {
            jobPostings.Add(jobPost);
            Notify(jobPost);
        }
    }

    internal class Unsubscriber<JobPost> : IDisposable
    {
        private readonly List<IObserver<JobPost>> observers;
        private readonly IObserver<JobPost> observer;

        internal Unsubscriber(List<IObserver<JobPost>> observers, IObserver<JobPost> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}