using System.Globalization;

namespace LaEscalonia.Models.Response
{
    public class Day1
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Day2
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Day3
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Day4
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Day5
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Day6
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Day7
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Information
    {
        public string temperature { get; set; }
        public string humidity { get; set; }
        public string pressure { get; set; }
    }

    public class Locality
    {
        public string name { get; set; }
    }


    public class Weather
    {
        public Information information { get; set; }
        public string DayOfWeek { get; set; }
        public Locality locality { get; set; }
        public Day1 day1 { get; set; }
        public Day2 day2 { get; set; }
        public Day3 day3 { get; set; }
        public Day4 day4 { get; set; }
        public Day5 day5 { get; set; }
        public Day6 day6 { get; set; }
        public Day7 day7 { get; set; }
        
        }
    }


