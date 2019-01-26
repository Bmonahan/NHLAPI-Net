using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
namespace NhlAPITest{
  public class scheduleMessage{
        public string copyright {get;set;}
        public int totalItems {get;set;}
        public int totalEvents {get;set;}
        public int totalGames {get;set;}
        public int totalMatches {get;set;}
        public int wait {get;set;}

        public List<dates> dates {get;set;}

    }

    public class dates{
        public string date {get;set;}
        public int totalItems {get;set;}
        public int totalEvents {get;set;}
        public int totalGames {get;set;}
        public int totalMatches {get;set;}
        public List<games> games {get;set;}
        public List<events> events {get;set;}
        public List<matches> matches {get;set;}
    }
    public class games{
        public int gamePk {get;set;}
        public string link {get;set;}
        public string gameType {get;set;}
        public string season {get;set;}
        public string gameDate {get;set;}
        public status status {get;set;}
        public teams teams {get;set;}
        public venueSched venue {get;set;}
        public content content {get;set;}
    }
    public class status{
        public string abstractGameState {get;set;}
        public string codedGameState {get;set;}
        public string detailedState {get;set;}
        public string statusCode {get;set;}
        public Boolean startTimeTBD {get;set;}
    }
    public class teams{
        public homeaway away {get;set;}
        public homeaway home {get;set;}
    }
    public class homeaway{
        public leagueRecord leagueRecord {get;set;}
        public int score {get;set;}
        public team team {get;set;}
    }
    public class leagueRecord{
        public int wins {get;set;}
        public int losses {get;set;}
        public int ot {get;set;}
        public string type {get;set;}

    }
    public class team{
        public int id {get;set;}
        public string name {get;set;}
        public string link {get;set;}
    }
    public class venueSched{
        public string name {get;set;}
        public string link {get;set;}
    }
    public class content{
        public string link {get;set;}
    }
    public class events{

    }
    public class matches{

    }
}