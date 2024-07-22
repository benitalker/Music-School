using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MusicSchool.Service
{
    internal static class Practice
    {
        //1
        public static Func<List<string>, bool> IsStartA = (list) =>
        list.Any(c => c.ToLower().StartsWith("a"));
        //2
        public static Func<List<string>, bool> IsEmptyOrNull = (s) =>
        s.Any(string.IsNullOrWhiteSpace);
        //3
        public static Func<List<string>, bool> IsAllA = (list) =>
        list.All(c => c.ToLower().Contains("a"));
        //4
        public static Func<List<string>, List<string>> ReturnAllUperr = (list) =>
        list.Select(c => c.ToUpper()).ToList();
        //5
        public static Func<List<string>, List<string>> ReturnAllUperrQuery = (list) =>
            (from str in list select str.ToUpper()).ToList();
        //6
        public static Func<List<string>, List<string>> ReturnAllCharBigerThen3 = (list) =>
        list.Where(c => c.Length >= 3).ToList();
        //7
        public static Func<List<string>, List<string>> ReturnAllCharBigerThen3Query = (list) =>
            (from str in list where str.Length >= 3 select str).ToList();
        //8
        public static Func<List<string>, string> JoinAllToString = (list) =>
        list.Aggregate(string.Empty, (current, next) => current + " " + next);
        //9
        public static Func<List<string>, int> JoinAllToStringLenth = (list) =>
        list.Aggregate(0, (current, next) => current + next.Length);
        //10
        public static Func<List<string>, List<string>> JoinAllToStringBiggerThen3 = (list) =>
        list.Aggregate(new List<string>(), (current, next) => next.Length >= 3 ? [..current,next] : [..current]);
        //11
        public static Func<List<string>, List<int>> JoinAllLength = (list) =>
        list.Aggregate(new List<int>(), (current, next) => [..current,next.Length]);
    }
}
