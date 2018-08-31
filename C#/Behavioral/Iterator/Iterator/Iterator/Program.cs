using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    /// <summary>
    /// It presents a way to access the elements of an object without exposing the underlying presentation.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var stations = new StationList();

            var stationOne = new RadioStation(98.1);
            stations.Add(stationOne);

            var stationTwo = new RadioStation(89.9);
            stations.Add(stationTwo);

            var stationThree = new RadioStation(106.1);
            stations.Add(stationThree);

            foreach (var station in stations)
            {
                Console.WriteLine($"Stations: {station.Frequency}");
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            var q = stations.FirstOrDefault(x => x.Frequency == 98.1);
            Console.WriteLine($"First station where frequency is equal to 98.1: {q?.Frequency}");
        }

        public class RadioStation
        {
            public double Frequency { get; }

            public RadioStation(double frequency)
            {
                Frequency = frequency;
            }
        }

        /// <summary>
        /// The Iterator
        /// </summary>
        public class StationList : IEnumerable<RadioStation>
        {
            private readonly List<RadioStation> stations = new List<RadioStation>();

            public RadioStation this[int index]
            {
                get => stations[index];
                set => stations.Insert(index, value);
            }

            public void Add(RadioStation station)
            {
                stations.Add(station);
            }

            public void Remove(RadioStation station)
            {
                stations.Remove(station);
            }

            public IEnumerator<RadioStation> GetEnumerator()
            {
                //Use can switch to this internal collection if you do not want to transform
                //return mStations.GetEnumerator();

                // use this if you want to transform the object before rendering
                foreach (var station in stations)
                {
                    yield return station;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}