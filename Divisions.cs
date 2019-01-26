using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
namespace NhlAPITest{
  public class divisionMessage{
        public string copyright {get;set;}
        public List<divisionMaster> divisions {get;set;}
    }

    public class divisionMaster{
        public int id {get;set;}
        public string name {get;set;}
        public string nameShort {get;set;}
        public string link {get;set;}
        public string abbreviation {get;set;}
        public conference conference {get;set;}
        public Boolean active {get;set;}
    }
    // For updating and creating team valid ID list

    public class idList{
        public int id {get;set;}
        public string name {get;set;}
    }

    // /divisions/:id

    public class divMessageId{
        public string copyright {get;set;}
        public List<div> divisions {get;set;}
    }

    public class div{
        public int id {get;set;}
        public string name {get;set;}
        public string link {get;set;}
        public string abbreviation {get;set;}
        public conference conference {get;set;}
        public Boolean active {get;set;}
    }
}