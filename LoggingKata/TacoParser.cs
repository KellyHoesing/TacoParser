using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ',' -DONE
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong - DONE
            if (cells.Length < 3)
            {
                // Log that and return null -DONE?
                // Do not fail if one record parsing fails, return null -DONE?
                logger.LogInfo("Array contains fewer than 3 lines");
                return null; // TODO Implement -DONE
            }

            // grab the latitude from your array at index 0 -DONE
            var latitude = double.Parse(cells[0]);
            // grab the longitude from your array at index 1 -DONE
            var longitude = double.Parse(cells[1]);
            // grab the name from your array at index 2 -DONE
            var name = cells[2];

            // You're going to need to parse your string as a `double` -DONE
            // which is similar to parsing a string as an `int` -DONE

            // You'll need to create a TacoBell class-DONE
            // that conforms to ITrackable-DONE

            // Then, you'll need an instance of the TacoBell class-DONE
            // With the name and point set correctly-DONE
            var shop = new TacoBell();
            shop.Name = name;
            shop.Location =new Point() {Latitude=latitude, Longitude=longitude};

            // Then, return the instance of your TacoBell class-DONE
            // Since it conforms to ITrackable-DONE
            return shop;
        }
    }
}