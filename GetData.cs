using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
namespace NhlAPITest
{
    class GetData
    {
        static void Main(string[] args)
        {
            updateTeamList();
            Console.WriteLine("1 - enter path manually, 2 - schedule for today");
            string code = Console.ReadLine();
            switch(code){
                case "1":
                    Console.Write("Enter path...");
                    string path = Console.ReadLine();
                    Console.WriteLine("Getting data from https://statsapi.web.nhl.com/api/v1"+path);
                    fetchData(path);
                    break;
                case "2":
                    Console.Write("Getting schedule for today...");
                    getTodaySchedule();
                    break;
            }
            Console.ReadKey();
        }

        static async void updateTeamList(){
            string baseUrl = "https://statsapi.web.nhl.com/api/v1";
            Console.WriteLine("Updating team list...");
            using (HttpClient client = new HttpClient())         
    
            using (HttpResponseMessage res = await client.GetAsync(baseUrl+"/teams"))
                    using (HttpContent content = res.Content){
                        string data = await content.ReadAsStringAsync();     
                        //var mes = JsonConvert.DeserializeObject<Message>(data);  
                        var mes = JsonConvert.DeserializeObject<Message>(data); 
                        List<idList> _data = new List<idList>();

                        int length = mes.teams.Count;
                        if (data != null){
                            for(int i = 0;i<length;i++){
                                int idTemp = mes.teams[i].id;
                                string nameTemp = mes.teams[i].name;
                                _data.Add(new idList()
                                {
                                    id = idTemp,
                                    name = nameTemp
                                });
                                // Console.WriteLine(temp);
                            }
                        }
                        string json = JsonConvert.SerializeObject(_data.ToArray());
                        System.IO.File.WriteAllText("teamlist.json", json);
                }
        }
        static async void fetchData(string path){
        //We will make a GET request to a really cool website...
            string baseUrl = "https://statsapi.web.nhl.com/api/v1";
            Match teamId = Regex.Match(path, @"/teams/(\d+)");
            Match rosterReg = Regex.Match(path,@"/teams/([0-9])/roster");
            Match divId = Regex.Match(path, @"/divisions/([0-9][0-9])");
            Match confId = Regex.Match(path, @"/conferences/([0-9])");
            Match peopleId = Regex.Match(path, @"/people/(\d+)"); 
            //Match divId = Regex.Match(path,@"/divisions/([0-9][0-9])/");
            //Console.WriteLine(teamId.Success+" "+rosterReg.Success);
            //Console.WriteLine(divId.Success);
            if((path == "/teams" || teamId.Success )&& !rosterReg.Success){
                Console.WriteLine("Getting teams...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+path))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<Message>(data); 

                            int length = mes.teams.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.teams[i].name;
                                    Console.WriteLine(temp);
                                }
                            }
                    }
            }else if(path == "/divisions"){
                Console.WriteLine("Getting divisions...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+path))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<divisionMessage>(data); 

                            int length = mes.divisions.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.divisions[i].name;
                                    Console.WriteLine(temp);
                                }
                            }
                    }
            }else if(rosterReg.Success){
                Console.WriteLine("Getting team roster...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+path))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<RosterMessage>(data); 

                            int length = mes.roster.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.roster[i];
                                    Console.WriteLine(temp.jerseyNumber+" "+temp.person.fullName+" "+temp.position.name);
                                }
                            }
                    }
            }else if(divId.Success){
                Console.WriteLine("Getting divisions...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+path))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<divMessageId>(data); 

                            int length = mes.divisions.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.divisions[i];
                                    Console.WriteLine(temp.name+" "+temp.link);
                                    
                                }
                            }
                    }
            }else if(path == "/conferences"){
                Console.WriteLine("Getting conferences...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+path))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<confMessage>(data); 

                            int length = mes.conferences.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.conferences[i].name;
                                    Console.WriteLine(temp);
                                }
                            }
                    }
            }else if(confId.Success){
                Console.WriteLine("Getting conferences...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+path))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<confMessage>(data); 

                            int length = mes.conferences.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.conferences[i].name;
                                    Console.WriteLine(temp);
                                }
                            }
                    }
            }else if(peopleId.Success){
                Console.WriteLine("Getting person...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+path))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<peopleMessage>(data); 

                            int length = mes.people.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.people[i];
                                    Console.WriteLine(temp.fullName+" "+temp.currentTeam.name);
                                }
                            }
                    }
            }else{
                Console.WriteLine("Not a valid path...");
            }
        }
        static async void getTodaySchedule(){
            string baseUrl = "https://statsapi.web.nhl.com/api/v1/";
            DateTime dateTime = DateTime.UtcNow.Date;
            string currDate = dateTime.ToString(("yyyy-MM-dd"));
            string dateUrl = baseUrl+"/schedule?date="+currDate;
            Console.WriteLine(dateUrl);
            Console.WriteLine("Getting schedule for today...");
                using (HttpClient client = new HttpClient())         
        
                using (HttpResponseMessage res = await client.GetAsync(baseUrl+"/schedule?date="+currDate))
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();     
                            //var mes = JsonConvert.DeserializeObject<Message>(data);  
                            var mes = JsonConvert.DeserializeObject<scheduleMessage>(data); 

                            int length = mes.dates[0].games.Count;
                            if (data != null){
                                for(int i = 0;i<length;i++){
                                    var temp = mes.dates[0].games[i];
                                    Console.WriteLine(mes.dates[0].date+" - "+temp.gamePk+" - "+temp.teams.home.team.name+" vs. "+temp.teams.away.team.name);
                                }
                            }
                    }
        }
}
//     public class Team{
//         public int id {get;set;}
//         public string name {get;set;}
//         public string link {get;set;}
//         public venue venue {get;set;}
//         public string abbreviation {get;set;}
//         public string teamName {get;set;}
//         public string locationName {get;set;}
//         public int firstYearOfPlay {get;set;}
//         public division division {get;set;}
//         public conference conference {get;set;}
//         public franchise franchise {get;set;}
//         public string shortName {get;set;}
//         public string officialSiteUrl {get;set;}
//         public int franchiseId {get;set;}
//         public Boolean active {get;set;}
//     }
//     public class Message{
//         public string copyright {get;set;}
//         public List<Team> teams {get;set;}
//     }

// // For /teams/:id/roster
//     public class RosterMessage{
//         public string copyright {get;set;}
//         public List<RosterItems> roster {get;set;}
//         public string link {get;set;}
//     }

//     public class RosterItems{
//         public person person {get;set;}
//         public string jerseyNumber {get;set;}
//         public position position {get;set;}
//     }

//     public class person{
//         public int id {get;set;}
//         public string fullName {get;set;}
//         public string link {get;set;}
//     }

//     public class position{
//         public string code {get;set;}
//         public string name {get;set;}
//         public string type {get;set;}
//         public string abbreviation {get;set;}
//     }

//     //For teams/id || teams
//     public class venue{
//         public string name {get;set;}
//         public string link {get;set;}
//         public string city {get;set;}
//         public timeZone timeZone {get;set;}
//     }

//     public class timeZone{
//         public string id {get;set;}
//         public int offset {get;set;}
//         public string tz {get;set;}
//     }

//     public class division{
//         public int id {get;set;}
//         public string name {get;set;}
//         public string nameShort {get;set;}
//         public string link {get;set;}
//         public string abbreviation {get;set;}
//     }

//     public class conference{
//         public int id {get;set;}
//         public string name {get;set;}
//         public string link {get;set;}
//     }

//     public class franchise{
//         public int franchiseId {get;set;}
//         public string teamName {get;set;}
//         public string link {get;set;}
//     }


    //For /divisions
    // public class divisionMessage{
    //     public string copyright {get;set;}
    //     public List<divisionMaster> divisions {get;set;}
    // }

    // public class divisionMaster{
    //     public int id {get;set;}
    //     public string name {get;set;}
    //     public string nameShort {get;set;}
    //     public string link {get;set;}
    //     public string abbreviation {get;set;}
    //     public conference conference {get;set;}
    //     public Boolean active {get;set;}
    // }
    // // For updating and creating team valid ID list

    // public class idList{
    //     public int id {get;set;}
    //     public string name {get;set;}
    // }

    // // /divisions/:id

    // public class divMessageId{
    //     public string copyright {get;set;}
    //     public List<div> divisions {get;set;}
    // }

    // public class div{
    //     public int id {get;set;}
    //     public string name {get;set;}
    //     public string link {get;set;}
    //     public string abbreviation {get;set;}
    //     public conference conference {get;set;}
    //     public Boolean active {get;set;}
    // }

    // /conferences && conferences/:id
    // public class confMessage{
    //     public string copyright {get;set;}
    //     public List<conf> conferences {get;set;}
    // }

    // public class conf{
    //     public int id {get;set;}
    //     public string name {get;set;}
    //     public string link {get;set;}
    //     public string abbreviation {get;set;}
    //     public string shortName {get;set;}
    //     public Boolean active {get;set;}
    // }

    // /people/:id
    // public class peopleMessage{
    //     public string copyright {get;set;}
    //     public List<people> people {get;set;}
    // }

    // public class people{
    //     public int id {get;set;}
    //     public string fullName {get;set;}
    //     public string link {get;set;}
    //     public string firstName {get;set;}
    //     public string lastName {get;set;}
    //     public string primaryNumber {get;set;}
    //     public string birthDate {get;set;}
    //     public int currentAge {get;set;}
    //     public string birthCity {get;set;}
    //     public string birthStateProvince {get;set;}
    //     public string birthCountry {get;set;}
    //     public string nationality {get;set;}
    //     public string height {get;set;}
    //     public int weight {get;set;}
    //     public Boolean active {get;set;}
    //     public Boolean alternateCaptain {get;set;}
    //     public Boolean captain {get;set;}
    //     public Boolean rookie {get;set;}
    //     public string shootsCatches {get;set;}
    //     public string rosterStatus {get;set;}
    //     public curTeam currentTeam {get;set;}
    //     public primaryPosition primaryPosition {get;set;}
    // }

    // public class curTeam{
    //     public int id {get;set;}
    //     public string name {get;set;}
    //     public string link {get;set;}

    // }
    // public class primaryPosition{
    //     public string code {get;set;}
    //     public string name {get;set;}
    //     public string type {get;set;}
    //     public string abbreviation {get;set;}
    // }

    // /schdule?date=:date
    // public class scheduleMessage{
    //     public string copyright {get;set;}
    //     public int totalItems {get;set;}
    //     public int totalEvents {get;set;}
    //     public int totalGames {get;set;}
    //     public int totalMatches {get;set;}
    //     public int wait {get;set;}

    //     public List<dates> dates {get;set;}

    // }

    // public class dates{
    //     public string date {get;set;}
    //     public int totalItems {get;set;}
    //     public int totalEvents {get;set;}
    //     public int totalGames {get;set;}
    //     public int totalMatches {get;set;}
    //     public List<games> games {get;set;}
    //     public List<events> events {get;set;}
    //     public List<matches> matches {get;set;}
    // }
    // public class games{
    //     public int gamePk {get;set;}
    //     public string link {get;set;}
    //     public string gameType {get;set;}
    //     public string season {get;set;}
    //     public string gameDate {get;set;}
    //     public status status {get;set;}
    //     public teams teams {get;set;}
    //     public venueSched venue {get;set;}
    //     public content content {get;set;}
    // }
    // public class status{
    //     public string abstractGameState {get;set;}
    //     public string codedGameState {get;set;}
    //     public string detailedState {get;set;}
    //     public string statusCode {get;set;}
    //     public Boolean startTimeTBD {get;set;}
    // }
    // public class teams{
    //     public homeaway away {get;set;}
    //     public homeaway home {get;set;}
    // }
    // public class homeaway{
    //     public leagueRecord leagueRecord {get;set;}
    //     public int score {get;set;}
    //     public team team {get;set;}
    // }
    // public class leagueRecord{
    //     public int wins {get;set;}
    //     public int losses {get;set;}
    //     public int ot {get;set;}
    //     public string type {get;set;}

    // }
    // public class team{
    //     public int id {get;set;}
    //     public string name {get;set;}
    //     public string link {get;set;}
    // }
    // public class venueSched{
    //     public string name {get;set;}
    //     public string link {get;set;}
    // }
    // public class content{
    //     public string link {get;set;}
    // }
    // public class events{

    // }
    // public class matches{

    // }

}
