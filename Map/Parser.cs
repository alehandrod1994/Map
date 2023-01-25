using System;

namespace Map
{
    public abstract class Parser
    {
        public static Rating GetRating(string value)
        {
            Rating rating;

            switch (value)
            {
                case "***":
                    rating = Rating.High;
                    break;

                case "**":
                    rating = Rating.Medium;
                    break;

                case "*":
                    rating = Rating.Low;
                    break;

                default:
                    rating = Rating.Low;
                    break;
            }

            return rating;
        }

        public static string GetValue(Rating rating)
        {
            string value = "";

            switch (rating)
            {
                case Rating.High:
                    value = "***";
                    break;

                case Rating.Medium:
                    value = "**";
                    break;

                case Rating.Low:
                    value = "*";
                    break;
            }

            return value;
        }
    }
}
