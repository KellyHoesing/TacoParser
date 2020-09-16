﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            if(lines.Length==0)
            {
                logger.LogError("Empty File");
            }
            if(lines.Length==1)
            {
                logger.LogWarning("Not enough Lines to determine distance");
            }
            logger.LogInfo($"Lines: {lines[0]}");


            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.-DONE
            // Create a `double` variable to store the distance-DONE
            ITrackable TacoBell1= null;
            ITrackable TacoBell2= null;
            double distance=0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`-DONE

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)-DONE?
            var locA = new TacoBell(); //not sure how to use this
            var corA = new GeoCoordinate();
            var corB = new GeoCoordinate();
            for(int i=0; i<locations.Length; i++)
            {
                corA.Latitude = locations[i].Location.Latitude;
                corA.Longitude = locations[i].Location.Longitude;
                for(int j=0; j<locations.Length; j++)
                {
                    corB.Latitude = locations[j].Location.Latitude;
                    corB.Longitude = locations[j].Location.Longitude;
                    double newDistance = corA.GetDistanceTo(corB);
                    if(newDistance>distance)
                    {
                        TacoBell1 = locations[i];
                        TacoBell2 = locations[j];
                        distance = newDistance;
                    }
                }
            }
            Console.WriteLine($"The two restaurants that are furthest apart are: {TacoBell1.Name} and {TacoBell2.Name}");
            var miles = distance * 0.000621371;
            Console.WriteLine($"The distance between these two locations is {miles} miles.");
        // Create a new corA Coordinate with your locA's lat and long

        // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

        // Create a new Coordinate with your locB's lat and long

        // Now, compare the two using `.GetDistanceTo()`, which returns a double
        // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

        // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



    }
}
}
