using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
namespace NhlAPITest{
public class Team{
        public int id {get;set;}
        public string name {get;set;}
        public string link {get;set;}
        public venue venue {get;set;}
        public string abbreviation {get;set;}
        public string teamName {get;set;}
        public string locationName {get;set;}
        public int firstYearOfPlay {get;set;}
        public division division {get;set;}
        public conference conference {get;set;}
        public franchise franchise {get;set;}
        public string shortName {get;set;}
        public string officialSiteUrl {get;set;}
        public int franchiseId {get;set;}
        public Boolean active {get;set;}
    }
    public class Message{
        public string copyright {get;set;}
        public List<Team> teams {get;set;}
    }
    public class RosterMessage{
        public string copyright {get;set;}
        public List<RosterItems> roster {get;set;}
        public string link {get;set;}
    }

    public class RosterItems{
        public person person {get;set;}
        public string jerseyNumber {get;set;}
        public position position {get;set;}
    }

    public class person{
        public int id {get;set;}
        public string fullName {get;set;}
        public string link {get;set;}
    }

    public class position{
        public string code {get;set;}
        public string name {get;set;}
        public string type {get;set;}
        public string abbreviation {get;set;}
    }

    //For teams/id || teams
    public class venue{
        public string name {get;set;}
        public string link {get;set;}
        public string city {get;set;}
        public timeZone timeZone {get;set;}
    }

    public class timeZone{
        public string id {get;set;}
        public int offset {get;set;}
        public string tz {get;set;}
    }

    public class division{
        public int id {get;set;}
        public string name {get;set;}
        public string nameShort {get;set;}
        public string link {get;set;}
        public string abbreviation {get;set;}
    }

    public class conference{
        public int id {get;set;}
        public string name {get;set;}
        public string link {get;set;}
    }

    public class franchise{
        public int franchiseId {get;set;}
        public string teamName {get;set;}
        public string link {get;set;}
    }
}