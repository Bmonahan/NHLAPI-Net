using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
namespace NhlAPITest{
  public class peopleMessage{
        public string copyright {get;set;}
        public List<people> people {get;set;}
    }

    public class people{
        public int id {get;set;}
        public string fullName {get;set;}
        public string link {get;set;}
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string primaryNumber {get;set;}
        public string birthDate {get;set;}
        public int currentAge {get;set;}
        public string birthCity {get;set;}
        public string birthStateProvince {get;set;}
        public string birthCountry {get;set;}
        public string nationality {get;set;}
        public string height {get;set;}
        public int weight {get;set;}
        public Boolean active {get;set;}
        public Boolean alternateCaptain {get;set;}
        public Boolean captain {get;set;}
        public Boolean rookie {get;set;}
        public string shootsCatches {get;set;}
        public string rosterStatus {get;set;}
        public curTeam currentTeam {get;set;}
        public primaryPosition primaryPosition {get;set;}
    }

    public class curTeam{
        public int id {get;set;}
        public string name {get;set;}
        public string link {get;set;}

    }
    public class primaryPosition{
        public string code {get;set;}
        public string name {get;set;}
        public string type {get;set;}
        public string abbreviation {get;set;}
    }
}